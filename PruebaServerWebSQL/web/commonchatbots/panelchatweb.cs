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
namespace GeneXus.Programs.commonchatbots {
   public class panelchatweb : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public panelchatweb( )
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

      public panelchatweb( IGxContext context )
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

      public void execute( string aP0_Instance )
      {
         this.AV5Instance = aP0_Instance;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Instance");
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
               gxfirstwebparm = GetFirstPar( "Instance");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Instance");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsent") == 0 )
            {
               nRC_GXsfl_12 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."));
               nGXsfl_12_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."));
               sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridsent_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsent") == 0 )
            {
               subGridsent_Rows = (int)(NumberUtil.Val( GetPar( "subGridsent_Rows"), "."));
               AV11UserId = (Guid)(StringUtil.StrToGuid( GetPar( "UserId")));
               AV5Instance = GetPar( "Instance");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
               GxWebStd.gx_hidden_field( context, "GRIDSENT_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Collapsed), 1, 0, ".", "")));
               GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_Message", AV8NotificationInfo.gxTpr_Message);
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
               AV5Instance = gxfirstwebparm;
               AssignAttri("", false, "AV5Instance", AV5Instance);
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
            return "panelchatweb_Execute" ;
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
         PA6N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6N2( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2023124957517", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("commonchatbots.panelchatweb.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV5Instance))}, new string[] {"Instance"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSTANCE", AV5Instance);
         GxWebStd.gx_hidden_field( context, "vWEBCLIENT", StringUtil.RTrim( AV12WebClient));
         GxWebStd.gx_hidden_field( context, "GXCHATMESSAGETYPE", StringUtil.RTrim( A271GXChatMessageType));
         GxWebStd.gx_hidden_field( context, "GXCHATMESSAGEID", A267GXChatMessageId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV8NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV8NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "vUSERID", AV11UserId.ToString());
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSENT_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Collapsed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_Message", AV8NotificationInfo.gxTpr_Message);
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
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Webcomponent == null ) )
         {
            WebComp_Webcomponent.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE6N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6N2( ) ;
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
         return formatLink("commonchatbots.panelchatweb.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV5Instance))}, new string[] {"Instance"})  ;
      }

      public override string GetPgmname( )
      {
         return "CommonChatbots.PanelChatWeb" ;
      }

      public override string GetPgmdesc( )
      {
         return "Web Chat" ;
      }

      protected void WB6N0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 col-sm-4", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-3 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divChattable_Internalname, 1, 0, "px", 0, "px", "CFChatTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridsentContainer.SetIsFreestyle(true);
            GridsentContainer.SetWrapped(nGXWrapped);
            if ( GridsentContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridsentContainer"+"DivS\" data-gxgridid=\"12\">") ;
               sStyleString = "";
               if ( subGridsent_Collapsed != 0 )
               {
                  sStyleString += "display:none;";
               }
               GxWebStd.gx_table_start( context, subGridsent_Internalname, subGridsent_Internalname, "", "CFMessages", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridsentContainer.AddObjectProperty("GridName", "Gridsent");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridsentContainer = new GXWebGrid( context);
               }
               else
               {
                  GridsentContainer.Clear();
               }
               GridsentContainer.SetIsFreestyle(true);
               GridsentContainer.SetWrapped(nGXWrapped);
               GridsentContainer.AddObjectProperty("GridName", "Gridsent");
               GridsentContainer.AddObjectProperty("Header", subGridsent_Header);
               GridsentContainer.AddObjectProperty("Class", StringUtil.RTrim( "CFMessages"));
               GridsentContainer.AddObjectProperty("Class", "CFMessages");
               GridsentContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Backcolorstyle), 1, 0, ".", "")));
               GridsentContainer.AddObjectProperty("CmpContext", "");
               GridsentContainer.AddObjectProperty("InMasterPage", "false");
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentColumn.AddObjectProperty("Value", A272GXChatMessageMessage);
               GridsentColumn.AddObjectProperty("Class", StringUtil.RTrim( edtGXChatMessageMessage_Class));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentColumn.AddObjectProperty("Value", context.convertURL( A274GXChatMessageImage));
               GridsentColumn.AddObjectProperty("Class", StringUtil.RTrim( edtGXChatMessageImage_Class));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsentColumn.AddObjectProperty("Value", context.localUtil.TToC( A270GXChatMessageDate, 10, 12, 0, 3, "/", ":", " "));
               GridsentColumn.AddObjectProperty("Class", StringUtil.RTrim( edtGXChatMessageDate_Class));
               GridsentContainer.AddColumnProperties(GridsentColumn);
               GridsentContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Selectedindex), 4, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Allowselection), 1, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Selectioncolor), 9, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Allowhovering), 1, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Hoveringcolor), 9, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Allowcollapsing), 1, 0, ".", "")));
               GridsentContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridsentContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsentContainer.AddObjectProperty("GRIDSENT_nEOF", GRIDSENT_nEOF);
               GridsentContainer.AddObjectProperty("GRIDSENT_nFirstRecordOnPage", GRIDSENT_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsentContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsent", GridsentContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsentContainerData", GridsentContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsentContainerData"+"V", GridsentContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsentContainerData"+"V"+"\" value='"+GridsentContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_34_6N2( true) ;
         }
         else
         {
            wb_table1_34_6N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_34_6N2e( bool wbgen )
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
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsentContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridsentContainer.AddObjectProperty("GRIDSENT_nEOF", GRIDSENT_nEOF);
                  GridsentContainer.AddObjectProperty("GRIDSENT_nFirstRecordOnPage", GRIDSENT_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsentContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsent", GridsentContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsentContainerData", GridsentContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsentContainerData"+"V", GridsentContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsentContainerData"+"V"+"\" value='"+GridsentContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6N2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
            }
            Form.Meta.addItem("description", "Web Chat", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6N0( ) ;
      }

      protected void WS6N2( )
      {
         START6N2( ) ;
         EVT6N2( ) ;
      }

      protected void EVT6N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'SEND'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Send' */
                              E116N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.ENUMERATEDEVENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E126N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.BOTEVENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E136N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Onmessage_gx1 */
                              E146N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSENTPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDSENTPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsent_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsent_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsent_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsent_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRIDSENT.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_12_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A272GXChatMessageMessage = cgiGet( edtGXChatMessageMessage_Internalname);
                              A274GXChatMessageImage = cgiGet( edtGXChatMessageImage_Internalname);
                              n274GXChatMessageImage = false;
                              AssignProp("", false, edtGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), !bGXsfl_12_Refreshing);
                              AssignProp("", false, edtGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
                              A270GXChatMessageDate = context.localUtil.CToT( cgiGet( edtGXChatMessageDate_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E156N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSENT.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E166N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E146N2 ();
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
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E146N2 ();
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 27 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0027" + sEvtType;
                           OldWebcomponent = cgiGet( sCmpCtrl);
                           if ( ( StringUtil.Len( OldWebcomponent) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWebcomponent";
                              WebComp_GX_Process_Component = OldWebcomponent;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess("W0027", sEvtType, sEvt);
                           }
                           nGXsfl_12_webc_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           WebCompHandler = "Webcomponent";
                           WebComp_GX_Process_Component = OldWebcomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6N2( )
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

      protected void PA6N2( )
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
               GX_FocusControl = edtavSend_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsent_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGridsent_Islastpage==1)&&(nGXsfl_12_idx+1>subGridsent_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsentContainer)) ;
         /* End function gxnrGridsent_newrow */
      }

      protected void gxgrGridsent_refresh( int subGridsent_Rows ,
                                           Guid AV11UserId ,
                                           string AV5Instance )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSENT_nCurrentRecord = 0;
         RF6N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsent_refresh */
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
      }

      public void Refresh( )
      {
         GRIDSENT_nFirstRecordOnPage = 0;
         GRIDSENT_nCurrentRecord = 0;
         GXCCtl = "GRIDSENT_nFirstRecordOnPage_" + sGXsfl_12_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF6N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF6N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsentContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = (int)(1+GRIDSENT_nFirstRecordOnPage);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridsentContainer.AddObjectProperty("GridName", "Gridsent");
         GridsentContainer.AddObjectProperty("CmpContext", "");
         GridsentContainer.AddObjectProperty("InMasterPage", "false");
         GridsentContainer.AddObjectProperty("Class", StringUtil.RTrim( "CFMessages"));
         GridsentContainer.AddObjectProperty("Class", "CFMessages");
         GridsentContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsentContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsentContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsent_Backcolorstyle), 1, 0, ".", "")));
         GridsentContainer.PageSize = subGridsent_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_Component) != 0 )
               {
                  WebComp_Webcomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(GRIDSENT_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGridsent_fnc_Recordsperpage( )+1);
            /* Using cursor H006N2 */
            pr_default.execute(0, new Object[] {AV11UserId, AV5Instance, GXPagingFrom2, GXPagingTo2});
            nGXsfl_12_idx = (int)(1+GRIDSENT_nFirstRecordOnPage);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRIDSENT_nCurrentRecord < subGridsent_fnc_Recordsperpage( ) ) ) )
            {
               A271GXChatMessageType = H006N2_A271GXChatMessageType[0];
               A267GXChatMessageId = (Guid)((Guid)(H006N2_A267GXChatMessageId[0]));
               A273GXChatMessageInstance = H006N2_A273GXChatMessageInstance[0];
               A268GXChatUserId = (Guid)((Guid)(H006N2_A268GXChatUserId[0]));
               A270GXChatMessageDate = H006N2_A270GXChatMessageDate[0];
               A40000GXChatMessageImage_GXI = H006N2_A40000GXChatMessageImage_GXI[0];
               n40000GXChatMessageImage_GXI = H006N2_n40000GXChatMessageImage_GXI[0];
               AssignProp("", false, edtGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), !bGXsfl_12_Refreshing);
               AssignProp("", false, edtGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
               A272GXChatMessageMessage = H006N2_A272GXChatMessageMessage[0];
               A274GXChatMessageImage = H006N2_A274GXChatMessageImage[0];
               n274GXChatMessageImage = H006N2_n274GXChatMessageImage[0];
               AssignProp("", false, edtGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), !bGXsfl_12_Refreshing);
               AssignProp("", false, edtGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
               E166N2 ();
               pr_default.readNext(0);
            }
            GRIDSENT_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDSENT_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB6N0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6N2( )
      {
      }

      protected int subGridsent_fnc_Pagecount( )
      {
         GRIDSENT_nRecordCount = subGridsent_fnc_Recordcount( );
         if ( ((int)((GRIDSENT_nRecordCount) % (subGridsent_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDSENT_nRecordCount/ (decimal)(subGridsent_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDSENT_nRecordCount/ (decimal)(subGridsent_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridsent_fnc_Recordcount( )
      {
         /* Using cursor H006N3 */
         pr_default.execute(1, new Object[] {AV11UserId, AV5Instance});
         GRIDSENT_nRecordCount = H006N3_AGRIDSENT_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRIDSENT_nRecordCount) ;
      }

      protected int subGridsent_fnc_Recordsperpage( )
      {
         return (int)(6*1) ;
      }

      protected int subGridsent_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDSENT_nFirstRecordOnPage/ (decimal)(subGridsent_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridsent_firstpage( )
      {
         GRIDSENT_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsent_nextpage( )
      {
         GRIDSENT_nRecordCount = subGridsent_fnc_Recordcount( );
         if ( ( GRIDSENT_nRecordCount >= subGridsent_fnc_Recordsperpage( ) ) && ( GRIDSENT_nEOF == 0 ) )
         {
            GRIDSENT_nFirstRecordOnPage = (long)(GRIDSENT_nFirstRecordOnPage+subGridsent_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRIDSENT_nEOF == 1 )
         {
            GRIDSENT_nFirstRecordOnPage = GRIDSENT_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsentContainer.AddObjectProperty("GRIDSENT_nFirstRecordOnPage", GRIDSENT_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSENT_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsent_previouspage( )
      {
         if ( GRIDSENT_nFirstRecordOnPage >= subGridsent_fnc_Recordsperpage( ) )
         {
            GRIDSENT_nFirstRecordOnPage = (long)(GRIDSENT_nFirstRecordOnPage-subGridsent_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsent_lastpage( )
      {
         GRIDSENT_nRecordCount = subGridsent_fnc_Recordcount( );
         if ( GRIDSENT_nRecordCount > subGridsent_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSENT_nRecordCount) % (subGridsent_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSENT_nFirstRecordOnPage = (long)(GRIDSENT_nRecordCount-subGridsent_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSENT_nFirstRecordOnPage = (long)(GRIDSENT_nRecordCount-((int)((GRIDSENT_nRecordCount) % (subGridsent_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSENT_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsent_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSENT_nFirstRecordOnPage = (long)(subGridsent_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSENT_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSENT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E156N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV8NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_12"), ",", "."));
            GRIDSENT_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRIDSENT_nFirstRecordOnPage"), ",", "."));
            GRIDSENT_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRIDSENT_nEOF"), ",", "."));
            subGridsent_Collapsed = (short)(context.localUtil.CToN( cgiGet( "GRIDSENT_Collapsed"), ",", "."));
            /* Read variables values. */
            AV9Send = cgiGet( edtavSend_Internalname);
            AssignAttri("", false, "AV9Send", AV9Send);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E156N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E156N2( )
      {
         /* Start Routine */
         returnInSub = false;
         divWebcomponenttable_Class = "CFCollapseWebComponent";
         AssignProp("", false, divWebcomponenttable_Internalname, "Class", divWebcomponenttable_Class, !bGXsfl_12_Refreshing);
         AV12WebClient = AV14WebNotification.gxTpr_Clientid;
         AssignAttri("", false, "AV12WebClient", AV12WebClient);
         GXt_guid1 = (Guid)(AV11UserId);
         GXt_guid2 = (Guid)(GXt_guid1);
         new GeneXus.Programs.commonchatbots.getuserid(context ).execute( out  GXt_guid2) ;
         GXt_guid1 = (Guid)((Guid)(GXt_guid2));
         AV11UserId = (Guid)(GXt_guid1);
         AssignAttri("", false, "AV11UserId", AV11UserId.ToString());
      }

      protected void E116N2( )
      {
         /* 'Send' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Send)) )
         {
            /* Execute user subroutine: 'SENDMESSAGE' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      private void E166N2( )
      {
         /* Gridsent_Load Routine */
         returnInSub = false;
         divWebcomponenttable_Class = "CFWebComponent";
         AssignProp("", false, divWebcomponenttable_Internalname, "Class", divWebcomponenttable_Class, !bGXsfl_12_Refreshing);
         edtGXChatMessageDate_Class = "ReadonlyCFDate";
         edtGXChatMessageImage_Class = "CFResponseMessageImageHidden";
         if ( StringUtil.StrCmp(A271GXChatMessageType, "U") == 0 )
         {
            divWebcomponenttable_Class = "CFCollapseWebComponent";
            AssignProp("", false, divWebcomponenttable_Internalname, "Class", divWebcomponenttable_Class, !bGXsfl_12_Refreshing);
            divGridmessagestable_Class = "CFSendMessageTable";
            AssignProp("", false, divGridmessagestable_Internalname, "Class", divGridmessagestable_Class, !bGXsfl_12_Refreshing);
            edtGXChatMessageMessage_Class = "ReadonlyCFSendMessage";
         }
         else if ( ( StringUtil.StrCmp(A271GXChatMessageType, "R") == 0 ) || ( StringUtil.StrCmp(A271GXChatMessageType, "RI") == 0 ) )
         {
            divWebcomponenttable_Class = "CFCollapseWebComponent";
            AssignProp("", false, divWebcomponenttable_Internalname, "Class", divWebcomponenttable_Class, !bGXsfl_12_Refreshing);
            divGridmessagestable_Class = "CFResponseMessageTable";
            AssignProp("", false, divGridmessagestable_Internalname, "Class", divGridmessagestable_Class, !bGXsfl_12_Refreshing);
            edtGXChatMessageMessage_Class = "ReadonlyCFResponseMessage";
            if ( StringUtil.StrCmp(A271GXChatMessageType, "RI") == 0 )
            {
               edtGXChatMessageImage_Class = "CFResponseMessageImage";
            }
         }
         else if ( StringUtil.StrCmp(A271GXChatMessageType, "RP") == 0 )
         {
            GXt_char3 = AV13WebComponentLink;
            new GeneXus.Programs.commonchatbots.getwebcomponentbyid(context ).execute(  A267GXChatMessageId, out  GXt_char3) ;
            AV13WebComponentLink = GXt_char3;
            /* Object Property */
            gxDynCompUrl = AV13WebComponentLink;
            if ( ! IsSameComponent( WebComp_Webcomponent_Component, gxDynCompUrl) )
            {
               WebComp_Webcomponent = getWebComponent(GetType(), "GeneXus.Programs", gxDynCompUrl, new Object[] {context} );
               WebComp_Webcomponent.ComponentInit();
               WebComp_Webcomponent.Name = "gxDynCompUrl";
               WebComp_Webcomponent_Component = gxDynCompUrl;
            }
            else
            {
               WebComp_Webcomponent.setparmsfromurl(gxDynCompUrl);
            }
            if ( StringUtil.Len( WebComp_Webcomponent_Component) != 0 )
            {
               WebComp_Webcomponent.setjustcreated();
               WebComp_Webcomponent.componentprepare(new Object[] {(string)"W0027",(string)sGXsfl_12_idx});
               WebComp_Webcomponent.componentbind(new Object[] {});
            }
            divWebcomponenttable_Class = "CFWebComponent";
            AssignProp("", false, divWebcomponenttable_Internalname, "Class", divWebcomponenttable_Class, !bGXsfl_12_Refreshing);
            divGridmessagestable_Class = "CFResponseMessageTableComponent";
            AssignProp("", false, divGridmessagestable_Internalname, "Class", divGridmessagestable_Class, !bGXsfl_12_Refreshing);
            edtGXChatMessageMessage_Class = "CFResponseMessage";
         }
         else
         {
            divWebcomponenttable_Class = "CFCollapseWebComponent";
            AssignProp("", false, divWebcomponenttable_Internalname, "Class", divWebcomponenttable_Class, !bGXsfl_12_Refreshing);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRIDSENT_nCurrentRecord = (long)(GRIDSENT_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            context.DoAjaxLoad(12, GridsentRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E146N2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8NotificationInfo.gxTpr_Id, "ChatbotMessage") == 0 )
         {
            GRIDSENT_nFirstRecordOnPage = 0;
            GRIDSENT_nCurrentRecord = 0;
            GXCCtl = "GRIDSENT_nFirstRecordOnPage_" + sGXsfl_12_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSENT_nFirstRecordOnPage), 15, 0, ".", "")));
            gxgrGridsent_refresh( subGridsent_Rows, AV11UserId, AV5Instance) ;
         }
         else if ( StringUtil.StrCmp(AV8NotificationInfo.gxTpr_Id, "ChatbotError") == 0 )
         {
            AV7Messages.FromJSonString(AV8NotificationInfo.gxTpr_Message, null);
            GXt_boolean4 = AV10ShowErrorsInUI;
            new GeneXus.Programs.commonchatbots.errorhandling(context ).execute( ref  AV7Messages, out  GXt_boolean4) ;
            AV10ShowErrorsInUI = GXt_boolean4;
            if ( AV10ShowErrorsInUI )
            {
               AV17GXV1 = 1;
               while ( AV17GXV1 <= AV7Messages.Count )
               {
                  AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV17GXV1));
                  GX_msglist.addItem(AV6Message.gxTpr_Description);
                  AV17GXV1 = (int)(AV17GXV1+1);
               }
            }
         }
      }

      protected void E126N2( )
      {
         /* GlobalEvents_Enumeratedevent Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SENDMESSAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E136N2( )
      {
         /* GlobalEvents_Botevent Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SENDMESSAGE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'SENDMESSAGE' Routine */
         returnInSub = false;
         new GeneXus.Programs.commonchatbots.sendmessage(context).executeSubmit(  AV5Instance,  "Web",  AV9Send,  "",  AV12WebClient) ;
         AV9Send = "";
         AssignAttri("", false, "AV9Send", AV9Send);
      }

      protected void wb_table1_34_6N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTexttable_Internalname, tblTexttable_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_12_idx + "',0)\"";
            ClassString = "CFSendMessageVariable";
            StyleString = "";
            ClassString = "CFSendMessageVariable";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSend_Internalname, AV9Send, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtavSend_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CommonChatbots\\PanelChatWeb.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "CFSendBtn";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSend_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(12), 2, 0)+","+"null"+");", "", bttSend_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SEND\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\PanelChatWeb.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_34_6N2e( true) ;
         }
         else
         {
            wb_table1_34_6N2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5Instance = (string)getParm(obj,0);
         AssignAttri("", false, "AV5Instance", AV5Instance);
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
         PA6N2( ) ;
         WS6N2( ) ;
         WE6N2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Webcomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_Component) != 0 )
            {
               WebComp_Webcomponent.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023124957551", true, true);
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
         context.AddJavascriptSource("commonchatbots/panelchatweb.js", "?2023124957551", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtGXChatMessageMessage_Internalname = "GXCHATMESSAGEMESSAGE_"+sGXsfl_12_idx;
         edtGXChatMessageImage_Internalname = "GXCHATMESSAGEIMAGE_"+sGXsfl_12_idx;
         edtGXChatMessageDate_Internalname = "GXCHATMESSAGEDATE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtGXChatMessageMessage_Internalname = "GXCHATMESSAGEMESSAGE_"+sGXsfl_12_fel_idx;
         edtGXChatMessageImage_Internalname = "GXCHATMESSAGEIMAGE_"+sGXsfl_12_fel_idx;
         edtGXChatMessageDate_Internalname = "GXCHATMESSAGEDATE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB6N0( ) ;
         if ( ( 6 * 1 == 0 ) || ( nGXsfl_12_idx - GRIDSENT_nFirstRecordOnPage <= subGridsent_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsentRow = GXWebRow.GetNew(context,GridsentContainer);
            if ( subGridsent_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsent_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsent_Class, "") != 0 )
               {
                  subGridsent_Linesclass = subGridsent_Class+"Odd";
               }
            }
            else if ( subGridsent_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsent_Backstyle = 0;
               subGridsent_Backcolor = subGridsent_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsent_Class, "") != 0 )
               {
                  subGridsent_Linesclass = subGridsent_Class+"Uniform";
               }
            }
            else if ( subGridsent_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsent_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsent_Class, "") != 0 )
               {
                  subGridsent_Linesclass = subGridsent_Class+"Odd";
               }
               subGridsent_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGridsent_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsent_Backstyle = 1;
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
               {
                  subGridsent_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsent_Class, "") != 0 )
                  {
                     subGridsent_Linesclass = subGridsent_Class+"Even";
                  }
               }
               else
               {
                  subGridsent_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGridsent_Class, "") != 0 )
                  {
                     subGridsent_Linesclass = subGridsent_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridsentContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGridsent_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridmessagestable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divGridmessagestable_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridsentRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtGXChatMessageMessage_Internalname,(string)"GXChat Message Message",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
            /* Multiple line edit */
            ClassString = edtGXChatMessageMessage_Class;
            StyleString = "";
            ClassString = edtGXChatMessageMessage_Class;
            StyleString = "";
            GridsentRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtGXChatMessageMessage_Internalname,(string)A272GXChatMessageMessage,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2097152",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridsentRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"GXChat Message Image",(string)"col-sm-3 CFResponseMessageImageLabel",(short)0,(bool)true,(string)""});
            /* Static Bitmap Variable */
            ClassString = edtGXChatMessageImage_Class;
            StyleString = "";
            A274GXChatMessageImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000GXChatMessageImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.PathToRelativeUrl( A274GXChatMessageImage));
            GridsentRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtGXChatMessageImage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A274GXChatMessageImage_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divWebcomponenttable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divWebcomponenttable_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* WebComponent */
            if ( ( StringUtil.StrCmp(WebCompHandler, "Webcomponent") == 0 ) && ( NumberUtil.Val( sGXsfl_12_idx, ".") == Convert.ToDecimal( nGXsfl_12_webc_idx )) )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.setjustcreated();
                  WebComp_GX_Process.componentprepare(new Object[] {(string)"W0027",(string)sGXsfl_12_idx});
                  WebComp_GX_Process.componentbind(new Object[] {});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_GX_Process )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW00-1"+"");
                  WebComp_GX_Process.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               GxWebStd.gx_hidden_field( context, "W0027"+sGXsfl_12_idx, StringUtil.RTrim( WebComp_GX_Process_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0027"+sGXsfl_12_idx+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( "W0027"+sGXsfl_12_idx, cgiGet( "_EventName"), 1) != 0 ) )
                  {
                     if ( 1 != 0 )
                     {
                        if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                        {
                           WebComp_GX_Process.componentstart();
                        }
                     }
                  }
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent), StringUtil.Lower( WebComp_GX_Process_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0027"+sGXsfl_12_idx);
                  }
                  WebComp_GX_Process.componentdraw();
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent), StringUtil.Lower( WebComp_GX_Process_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GxWebStd.gx_hidden_field( context, "W0027"+sGXsfl_12_idx, StringUtil.RTrim( WebComp_Webcomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0027"+sGXsfl_12_idx+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_Component) != 0 )
               {
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( "W0027"+sGXsfl_12_idx, cgiGet( "_EventName"), 1) != 0 ) )
                  {
                     if ( 1 != 0 )
                     {
                        if ( StringUtil.Len( WebComp_Webcomponent_Component) != 0 )
                        {
                           WebComp_Webcomponent.componentstart();
                        }
                     }
                  }
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent), StringUtil.Lower( WebComp_Webcomponent_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0027"+sGXsfl_12_idx);
                  }
                  WebComp_Webcomponent.componentdraw();
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent), StringUtil.Lower( WebComp_Webcomponent_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            WebComp_Webcomponent_Component = "";
            WebComp_Webcomponent.componentjscripts();
            GridsentRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Webcomponent"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridsentRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridsentRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtGXChatMessageDate_Internalname,(string)"GXChat Message Date",(string)"col-sm-3 ReadonlyCFDateLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = edtGXChatMessageDate_Class;
            GridsentRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtGXChatMessageDate_Internalname,context.localUtil.TToC( A270GXChatMessageDate, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A270GXChatMessageDate, "99/99/99 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtGXChatMessageDate_Jsonclick,(short)0,(string)edtGXChatMessageDate_Class,(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)21,(string)"chr",(short)1,(string)"row",(short)21,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridsentRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            send_integrity_lvl_hashes6N2( ) ;
            /* End of Columns property logic. */
            GridsentContainer.AddRow(GridsentRow);
            nGXsfl_12_idx = ((subGridsent_Islastpage==1)&&(nGXsfl_12_idx+1>subGridsent_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtGXChatMessageMessage_Internalname = "GXCHATMESSAGEMESSAGE";
         edtGXChatMessageImage_Internalname = "GXCHATMESSAGEIMAGE";
         divWebcomponenttable_Internalname = "WEBCOMPONENTTABLE";
         edtGXChatMessageDate_Internalname = "GXCHATMESSAGEDATE";
         divGridmessagestable_Internalname = "GRIDMESSAGESTABLE";
         edtavSend_Internalname = "vSEND";
         bttSend_Internalname = "SEND";
         tblTexttable_Internalname = "TEXTTABLE";
         divChattable_Internalname = "CHATTABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridsent_Internalname = "GRIDSENT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtGXChatMessageDate_Jsonclick = "";
         subGridsent_Class = "CFMessages";
         edtavSend_Enabled = 1;
         divGridmessagestable_Class = "Table";
         divWebcomponenttable_Class = "CFCollapseWebComponent";
         subGridsent_Allowcollapsing = 1;
         edtGXChatMessageDate_Class = "ReadonlyCFDate";
         edtGXChatMessageImage_Class = "CFResponseMessageImage";
         edtGXChatMessageMessage_Class = "Attribute";
         subGridsent_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Web Chat";
         subGridsent_Collapsed = 0;
         subGridsent_Rows = 6;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDSENT_nFirstRecordOnPage'},{av:'GRIDSENT_nEOF'},{av:'subGridsent_Rows',ctrl:'GRIDSENT',prop:'Rows'},{av:'AV11UserId',fld:'vUSERID',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'SEND'","{handler:'E116N2',iparms:[{av:'AV9Send',fld:'vSEND',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''},{av:'AV12WebClient',fld:'vWEBCLIENT',pic:''}]");
         setEventMetadata("'SEND'",",oparms:[{av:'AV12WebClient',fld:'vWEBCLIENT',pic:''},{av:'AV9Send',fld:'vSEND',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]}");
         setEventMetadata("GRIDSENT.LOAD","{handler:'E166N2',iparms:[{av:'A271GXChatMessageType',fld:'GXCHATMESSAGETYPE',pic:''},{av:'A267GXChatMessageId',fld:'GXCHATMESSAGEID',pic:''}]");
         setEventMetadata("GRIDSENT.LOAD",",oparms:[{av:'divWebcomponenttable_Class',ctrl:'WEBCOMPONENTTABLE',prop:'Class'},{av:'edtGXChatMessageDate_Class',ctrl:'GXCHATMESSAGEDATE',prop:'Class'},{av:'edtGXChatMessageImage_Class',ctrl:'GXCHATMESSAGEIMAGE',prop:'Class'},{av:'divGridmessagestable_Class',ctrl:'GRIDMESSAGESTABLE',prop:'Class'},{av:'edtGXChatMessageMessage_Class',ctrl:'GXCHATMESSAGEMESSAGE',prop:'Class'},{ctrl:'WEBCOMPONENT'}]}");
         setEventMetadata("GLOBALEVENTS.ENUMERATEDEVENT","{handler:'E126N2',iparms:[{av:'AV9Send',fld:'vSEND',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''},{av:'AV12WebClient',fld:'vWEBCLIENT',pic:''}]");
         setEventMetadata("GLOBALEVENTS.ENUMERATEDEVENT",",oparms:[{av:'AV12WebClient',fld:'vWEBCLIENT',pic:''},{av:'AV9Send',fld:'vSEND',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]}");
         setEventMetadata("GLOBALEVENTS.BOTEVENT","{handler:'E136N2',iparms:[{av:'AV9Send',fld:'vSEND',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''},{av:'AV12WebClient',fld:'vWEBCLIENT',pic:''}]");
         setEventMetadata("GLOBALEVENTS.BOTEVENT",",oparms:[{av:'AV12WebClient',fld:'vWEBCLIENT',pic:''},{av:'AV9Send',fld:'vSEND',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E146N2',iparms:[{av:'GRIDSENT_nFirstRecordOnPage'},{av:'GRIDSENT_nEOF'},{av:'subGridsent_Rows',ctrl:'GRIDSENT',prop:'Rows'},{av:'AV11UserId',fld:'vUSERID',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''},{av:'AV8NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[]}");
         setEventMetadata("GRIDSENT_FIRSTPAGE","{handler:'subgridsent_firstpage',iparms:[{av:'GRIDSENT_nFirstRecordOnPage'},{av:'GRIDSENT_nEOF'},{av:'subGridsent_Rows',ctrl:'GRIDSENT',prop:'Rows'},{av:'AV11UserId',fld:'vUSERID',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]");
         setEventMetadata("GRIDSENT_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDSENT_PREVPAGE","{handler:'subgridsent_previouspage',iparms:[{av:'GRIDSENT_nFirstRecordOnPage'},{av:'GRIDSENT_nEOF'},{av:'subGridsent_Rows',ctrl:'GRIDSENT',prop:'Rows'},{av:'AV11UserId',fld:'vUSERID',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]");
         setEventMetadata("GRIDSENT_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDSENT_NEXTPAGE","{handler:'subgridsent_nextpage',iparms:[{av:'GRIDSENT_nFirstRecordOnPage'},{av:'GRIDSENT_nEOF'},{av:'subGridsent_Rows',ctrl:'GRIDSENT',prop:'Rows'},{av:'AV11UserId',fld:'vUSERID',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]");
         setEventMetadata("GRIDSENT_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDSENT_LASTPAGE","{handler:'subgridsent_lastpage',iparms:[{av:'GRIDSENT_nFirstRecordOnPage'},{av:'GRIDSENT_nEOF'},{av:'subGridsent_Rows',ctrl:'GRIDSENT',prop:'Rows'},{av:'AV11UserId',fld:'vUSERID',pic:''},{av:'AV5Instance',fld:'vINSTANCE',pic:''}]");
         setEventMetadata("GRIDSENT_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Gxchatmessagedate',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         wcpOAV5Instance = "";
         AV8NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV11UserId = (Guid)(Guid.Empty);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12WebClient = "";
         A271GXChatMessageType = "";
         A267GXChatMessageId = (Guid)(Guid.Empty);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridsentContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridsent_Header = "";
         GridsentColumn = new GXWebColumn();
         A272GXChatMessageMessage = "";
         A274GXChatMessageImage = "";
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40000GXChatMessageImage_GXI = "";
         OldWebcomponent = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         GXCCtl = "";
         gxDynCompUrl = "";
         WebComp_Webcomponent_Component = "";
         scmdbuf = "";
         H006N2_A271GXChatMessageType = new string[] {""} ;
         H006N2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         H006N2_A273GXChatMessageInstance = new string[] {""} ;
         H006N2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         H006N2_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         H006N2_A40000GXChatMessageImage_GXI = new string[] {""} ;
         H006N2_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         H006N2_A272GXChatMessageMessage = new string[] {""} ;
         H006N2_A274GXChatMessageImage = new string[] {""} ;
         H006N2_n274GXChatMessageImage = new bool[] {false} ;
         A273GXChatMessageInstance = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         H006N3_AGRIDSENT_nRecordCount = new long[1] ;
         AV9Send = "";
         AV14WebNotification = new GeneXus.Core.genexus.server.SdtSocket(context);
         GXt_guid1 = (Guid)(Guid.Empty);
         GXt_guid2 = (Guid)(Guid.Empty);
         AV13WebComponentLink = "";
         GXt_char3 = "";
         GridsentRow = new GXWebRow();
         AV7Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         TempTags = "";
         bttSend_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridsent_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.panelchatweb__default(),
            new Object[][] {
                new Object[] {
               H006N2_A271GXChatMessageType, H006N2_A267GXChatMessageId, H006N2_A273GXChatMessageInstance, H006N2_A268GXChatUserId, H006N2_A270GXChatMessageDate, H006N2_A40000GXChatMessageImage_GXI, H006N2_n40000GXChatMessageImage_GXI, H006N2_A272GXChatMessageMessage, H006N2_A274GXChatMessageImage, H006N2_n274GXChatMessageImage
               }
               , new Object[] {
               H006N3_AGRIDSENT_nRecordCount
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRIDSENT_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short subGridsent_Collapsed ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridsent_Backcolorstyle ;
      private short subGridsent_Allowselection ;
      private short subGridsent_Allowhovering ;
      private short subGridsent_Allowcollapsing ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGridsent_Backstyle ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int subGridsent_Rows ;
      private int subGridsent_Selectedindex ;
      private int subGridsent_Selectioncolor ;
      private int subGridsent_Hoveringcolor ;
      private int nGXsfl_12_webc_idx=0 ;
      private int subGridsent_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV17GXV1 ;
      private int edtavSend_Enabled ;
      private int idxLst ;
      private int subGridsent_Backcolor ;
      private int subGridsent_Allbackcolor ;
      private long GRIDSENT_nFirstRecordOnPage ;
      private long GRIDSENT_nCurrentRecord ;
      private long GRIDSENT_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_12_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV12WebClient ;
      private string A271GXChatMessageType ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divChattable_Internalname ;
      private string sStyleString ;
      private string subGridsent_Internalname ;
      private string subGridsent_Header ;
      private string edtGXChatMessageMessage_Class ;
      private string edtGXChatMessageImage_Class ;
      private string edtGXChatMessageDate_Class ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtGXChatMessageMessage_Internalname ;
      private string edtGXChatMessageImage_Internalname ;
      private string edtGXChatMessageDate_Internalname ;
      private string OldWebcomponent ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string edtavSend_Internalname ;
      private string GXCCtl ;
      private string gxDynCompUrl ;
      private string WebComp_Webcomponent_Component ;
      private string scmdbuf ;
      private string divWebcomponenttable_Class ;
      private string divWebcomponenttable_Internalname ;
      private string divGridmessagestable_Class ;
      private string divGridmessagestable_Internalname ;
      private string GXt_char3 ;
      private string tblTexttable_Internalname ;
      private string TempTags ;
      private string bttSend_Internalname ;
      private string bttSend_Jsonclick ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGridsent_Class ;
      private string subGridsent_Linesclass ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtGXChatMessageDate_Jsonclick ;
      private DateTime A270GXChatMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n274GXChatMessageImage ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000GXChatMessageImage_GXI ;
      private bool returnInSub ;
      private bool AV10ShowErrorsInUI ;
      private bool GXt_boolean4 ;
      private bool A274GXChatMessageImage_IsBlob ;
      private bool bDynCreated_GX_Process ;
      private string A272GXChatMessageMessage ;
      private string AV5Instance ;
      private string wcpOAV5Instance ;
      private string A40000GXChatMessageImage_GXI ;
      private string A273GXChatMessageInstance ;
      private string AV9Send ;
      private string AV13WebComponentLink ;
      private string A274GXChatMessageImage ;
      private Guid AV11UserId ;
      private Guid A267GXChatMessageId ;
      private Guid A268GXChatUserId ;
      private Guid GXt_guid1 ;
      private Guid GXt_guid2 ;
      private GXWebComponent WebComp_Webcomponent ;
      private GXWebGrid GridsentContainer ;
      private GXWebRow GridsentRow ;
      private GXWebColumn GridsentColumn ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private string[] H006N2_A271GXChatMessageType ;
      private Guid[] H006N2_A267GXChatMessageId ;
      private string[] H006N2_A273GXChatMessageInstance ;
      private Guid[] H006N2_A268GXChatUserId ;
      private DateTime[] H006N2_A270GXChatMessageDate ;
      private string[] H006N2_A40000GXChatMessageImage_GXI ;
      private bool[] H006N2_n40000GXChatMessageImage_GXI ;
      private string[] H006N2_A272GXChatMessageMessage ;
      private string[] H006N2_A274GXChatMessageImage ;
      private bool[] H006N2_n274GXChatMessageImage ;
      private long[] H006N3_AGRIDSENT_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtMessages_Message> AV7Messages ;
      private GXWebForm Form ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV8NotificationInfo ;
      private GeneXus.Core.genexus.server.SdtSocket AV14WebNotification ;
   }

   public class panelchatweb__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006N2;
          prmH006N2 = new Object[] {
          new ParDef("@AV11UserId",GXType.UniqueIdentifier,256,0) ,
          new ParDef("@AV5Instance",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH006N3;
          prmH006N3 = new Object[] {
          new ParDef("@AV11UserId",GXType.UniqueIdentifier,256,0) ,
          new ParDef("@AV5Instance",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006N2", "SELECT [GXChatMessageType], [GXChatMessageId], [GXChatMessageInstance], [GXChatUserId], [GXChatMessageDate], [GXChatMessageImage_GXI], [GXChatMessageMessage], [GXChatMessageImage] FROM [GXChatMessage] WHERE ([GXChatUserId] = @AV11UserId) AND ([GXChatMessageInstance] = @AV5Instance) ORDER BY [GXChatMessageDate] DESC  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006N2,7, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006N3", "SELECT COUNT(*) FROM [GXChatMessage] WHERE ([GXChatUserId] = @AV11UserId) AND ([GXChatMessageInstance] = @AV5Instance) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006N3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(6));
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
