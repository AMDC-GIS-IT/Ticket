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
   public class deptogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public deptogeneral( )
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

      public deptogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CentrodecostoId ,
                           short aP2_DepartamentoId ,
                           string aP3_TabCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV6CentrodecostoId = aP1_CentrodecostoId;
         this.AV7DepartamentoId = aP2_DepartamentoId;
         this.AV9TabCode = aP3_TabCode;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
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
                  AV6CentrodecostoId = GetPar( "CentrodecostoId");
                  AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
                  AV7DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
                  AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
                  AV9TabCode = GetPar( "TabCode");
                  AssignAttri(sPrefix, false, "AV9TabCode", AV9TabCode);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV6CentrodecostoId,(short)AV7DepartamentoId,(string)AV9TabCode});
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
            PA622( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS622( ) ;
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
            context.SendWebValue( "General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188103377", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("deptogeneral.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV6CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(AV7DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(AV9TabCode))}, new string[] {"Gx_mode","CentrodecostoId","DepartamentoId","TabCode"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6CentrodecostoId", wcpOAV6CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9TabCode", StringUtil.RTrim( wcpOAV9TabCode));
         GxWebStd.gx_hidden_field( context, sPrefix+"CENTRODECOSTOID", A259CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCENTRODECOSTOID", AV6CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"DEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A260DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABCODE", StringUtil.RTrim( AV9TabCode));
      }

      protected void RenderHtmlCloseForm622( )
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
            if ( ! ( WebComp_Transactioncomponent == null ) )
            {
               WebComp_Transactioncomponent.componentjscripts();
            }
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
         return "DeptoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "General" ;
      }

      protected void WB620( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "deptogeneral.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_622( true) ;
         }
         else
         {
            wb_table1_15_622( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_622e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopBorder", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0029"+"", StringUtil.RTrim( WebComp_Transactioncomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0029"+""+"\""+((WebComp_Transactioncomponent_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTransactioncomponent), StringUtil.Lower( WebComp_Transactioncomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0029"+"");
                  }
                  WebComp_Transactioncomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTransactioncomponent), StringUtil.Lower( WebComp_Transactioncomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
         }
         wbLoad = true;
      }

      protected void START622( )
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
               Form.Meta.addItem("description", "General", 0) ;
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
               STRUP620( ) ;
            }
         }
      }

      protected void WS622( )
      {
         START622( ) ;
         EVT622( ) ;
      }

      protected void EVT622( )
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
                                 STRUP620( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP620( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11622 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP620( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12622 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP620( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13622 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP620( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14622 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP620( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15622 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP620( ) ;
                              }
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
                                 STRUP620( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 29 )
                        {
                           OldTransactioncomponent = cgiGet( sPrefix+"W0029");
                           if ( ( StringUtil.Len( OldTransactioncomponent) == 0 ) || ( StringUtil.StrCmp(OldTransactioncomponent, WebComp_Transactioncomponent_Component) != 0 ) )
                           {
                              WebComp_Transactioncomponent = getWebComponent(GetType(), "GeneXus.Programs", OldTransactioncomponent, new Object[] {context} );
                              WebComp_Transactioncomponent.ComponentInit();
                              WebComp_Transactioncomponent.Name = "OldTransactioncomponent";
                              WebComp_Transactioncomponent_Component = OldTransactioncomponent;
                           }
                           if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
                           {
                              WebComp_Transactioncomponent.componentprocess(sPrefix+"W0029", "", sEvt);
                           }
                           WebComp_Transactioncomponent_Component = OldTransactioncomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE622( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm622( ) ;
            }
         }
      }

      protected void PA622( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         send_integrity_hashes( ) ;
         RF622( ) ;
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

      protected void RF622( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12622 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Transactioncomponent_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
               {
                  WebComp_Transactioncomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15622 ();
            WB620( ) ;
         }
      }

      protected void send_integrity_lvl_hashes622( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP620( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11622 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV6CentrodecostoId = cgiGet( sPrefix+"wcpOAV6CentrodecostoId");
            wcpOAV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DepartamentoId"), ".", ","));
            wcpOAV9TabCode = cgiGet( sPrefix+"wcpOAV9TabCode");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11622 ();
         if (returnInSub) return;
      }

      protected void E11622( )
      {
         /* Start Routine */
         returnInSub = false;
         imgUpdate_Tooltiptext = "Actualizar";
         AssignProp(sPrefix, false, imgUpdate_Internalname, "Tooltiptext", imgUpdate_Tooltiptext, true);
         imgDelete_Tooltiptext = "";
         AssignProp(sPrefix, false, imgDelete_Internalname, "Tooltiptext", imgDelete_Tooltiptext, true);
      }

      protected void E12622( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV12ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV13ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Depto";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Depto";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "";
         AV12ActivityList.Add(AV13ActivityListItem, 0);
         AV13ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "Depto";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "Depto";
         AV13ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "";
         AV12ActivityList.Add(AV13ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV12ActivityList) ;
         AV17GXLvl26 = 0;
         /* Using cursor H00622 */
         pr_datastore2.execute(0, new Object[] {AV6CentrodecostoId, AV7DepartamentoId});
         while ( (pr_datastore2.getStatus(0) != 101) )
         {
            A260DepartamentoId = H00622_A260DepartamentoId[0];
            A259CentrodecostoId = H00622_A259CentrodecostoId[0];
            AV17GXLvl26 = 1;
            if ( ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) && ((SdtK2BActivityList_K2BActivityListItem)AV12ActivityList.Item(1)).gxTpr_Isauthorized )
            {
               imgUpdate_Visible = 1;
               AssignProp(sPrefix, false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            }
            else
            {
               imgUpdate_Visible = 0;
               AssignProp(sPrefix, false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            }
            if ( ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) && ((SdtK2BActivityList_K2BActivityListItem)AV12ActivityList.Item(2)).gxTpr_Isauthorized )
            {
               imgDelete_Visible = 1;
               AssignProp(sPrefix, false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            }
            else
            {
               imgDelete_Visible = 0;
               AssignProp(sPrefix, false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_datastore2.close(0);
         if ( AV17GXLvl26 == 0 )
         {
            imgUpdate_Visible = 0;
            AssignProp(sPrefix, false, imgUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUpdate_Visible), 5, 0), true);
            imgDelete_Visible = 0;
            AssignProp(sPrefix, false, imgDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDelete_Visible), 5, 0), true);
         }
         WebComp_Transactioncomponent_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0029"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Transactioncomponent_Visible), 5, 0), true);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Transactioncomponent = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Transactioncomponent_Component), StringUtil.Lower( "Depto")) != 0 )
         {
            WebComp_Transactioncomponent = getWebComponent(GetType(), "GeneXus.Programs", "depto", new Object[] {context} );
            WebComp_Transactioncomponent.ComponentInit();
            WebComp_Transactioncomponent.Name = "Depto";
            WebComp_Transactioncomponent_Component = "Depto";
         }
         if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
         {
            WebComp_Transactioncomponent.setjustcreated();
            WebComp_Transactioncomponent.componentprepare(new Object[] {(string)sPrefix+"W0029",(string)"",(string)Gx_mode,(string)AV6CentrodecostoId,(short)AV7DepartamentoId});
            WebComp_Transactioncomponent.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Transactioncomponent )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0029"+"");
            WebComp_Transactioncomponent.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E13622( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         new k2bgettrncontextbyname(context ).execute(  "Depto", out  AV11TrnContext) ;
         GXt_char1 = "";
         new k2bgetcallerurl(context ).execute( out  GXt_char1) ;
         AV11TrnContext.gxTpr_Callerurl = GXt_char1;
         AV11TrnContext.gxTpr_Returnmode = "Popup";
         new k2bsettrncontextbyname(context ).execute(  "Depto",  AV11TrnContext) ;
         CallWebObject(formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(AV6CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(AV7DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim("General"))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E14622( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         new k2bgettrncontextbyname(context ).execute(  "Depto", out  AV11TrnContext) ;
         GXt_char1 = "";
         new k2bgetcallerurl(context ).execute( out  GXt_char1) ;
         AV11TrnContext.gxTpr_Callerurl = GXt_char1;
         AV11TrnContext.gxTpr_Returnmode = "Popup";
         new k2bsettrncontextbyname(context ).execute(  "Depto",  AV11TrnContext) ;
         CallWebObject(formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(AV6CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(AV7DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim("General"))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E15622( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_15_622( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "K2BTableActionsRightContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='Section_Basic_TextAlign_Right'>") ;
            wb_table2_18_622( true) ;
         }
         else
         {
            wb_table2_18_622( false) ;
         }
         return  ;
      }

      protected void wb_table2_18_622e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_622e( true) ;
         }
         else
         {
            wb_table1_15_622e( false) ;
         }
      }

      protected void wb_table2_18_622( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblK2btableactionsrightcontainer_Internalname, tblK2btableactionsrightcontainer_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgUpdate_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUpdate_Visible, 1, "K2BT_UpdateAction", imgUpdate_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgUpdate_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DeptoGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgDelete_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDelete_Visible, 1, "K2BT_DeleteAction", imgDelete_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgDelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DeptoGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_18_622e( true) ;
         }
         else
         {
            wb_table2_18_622e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV6CentrodecostoId = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
         AV7DepartamentoId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
         AV9TabCode = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV9TabCode", AV9TabCode);
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
         PA622( ) ;
         WS622( ) ;
         WE622( ) ;
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
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV6CentrodecostoId = (string)((string)getParm(obj,1));
         sCtrlAV7DepartamentoId = (string)((string)getParm(obj,2));
         sCtrlAV9TabCode = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA622( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "deptogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA622( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV6CentrodecostoId = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
            AV7DepartamentoId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
            AV9TabCode = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV9TabCode", AV9TabCode);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV6CentrodecostoId = cgiGet( sPrefix+"wcpOAV6CentrodecostoId");
         wcpOAV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7DepartamentoId"), ".", ","));
         wcpOAV9TabCode = cgiGet( sPrefix+"wcpOAV9TabCode");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV6CentrodecostoId, wcpOAV6CentrodecostoId) != 0 ) || ( AV7DepartamentoId != wcpOAV7DepartamentoId ) || ( StringUtil.StrCmp(AV9TabCode, wcpOAV9TabCode) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV6CentrodecostoId = AV6CentrodecostoId;
         wcpOAV7DepartamentoId = AV7DepartamentoId;
         wcpOAV9TabCode = AV9TabCode;
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
         sCtrlAV6CentrodecostoId = cgiGet( sPrefix+"AV6CentrodecostoId_CTRL");
         if ( StringUtil.Len( sCtrlAV6CentrodecostoId) > 0 )
         {
            AV6CentrodecostoId = cgiGet( sCtrlAV6CentrodecostoId);
            AssignAttri(sPrefix, false, "AV6CentrodecostoId", AV6CentrodecostoId);
         }
         else
         {
            AV6CentrodecostoId = cgiGet( sPrefix+"AV6CentrodecostoId_PARM");
         }
         sCtrlAV7DepartamentoId = cgiGet( sPrefix+"AV7DepartamentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV7DepartamentoId) > 0 )
         {
            AV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7DepartamentoId), ".", ","));
            AssignAttri(sPrefix, false, "AV7DepartamentoId", StringUtil.LTrimStr( (decimal)(AV7DepartamentoId), 4, 0));
         }
         else
         {
            AV7DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7DepartamentoId_PARM"), ".", ","));
         }
         sCtrlAV9TabCode = cgiGet( sPrefix+"AV9TabCode_CTRL");
         if ( StringUtil.Len( sCtrlAV9TabCode) > 0 )
         {
            AV9TabCode = cgiGet( sCtrlAV9TabCode);
            AssignAttri(sPrefix, false, "AV9TabCode", AV9TabCode);
         }
         else
         {
            AV9TabCode = cgiGet( sPrefix+"AV9TabCode_PARM");
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
         PA622( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS622( ) ;
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
         WS622( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6CentrodecostoId_PARM", AV6CentrodecostoId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6CentrodecostoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6CentrodecostoId_CTRL", StringUtil.RTrim( sCtrlAV6CentrodecostoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7DepartamentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DepartamentoId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7DepartamentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7DepartamentoId_CTRL", StringUtil.RTrim( sCtrlAV7DepartamentoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9TabCode_PARM", StringUtil.RTrim( AV9TabCode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9TabCode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9TabCode_CTRL", StringUtil.RTrim( sCtrlAV9TabCode));
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
         WE622( ) ;
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
         if ( ! ( WebComp_Transactioncomponent == null ) )
         {
            WebComp_Transactioncomponent.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Transactioncomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Transactioncomponent_Component) != 0 )
            {
               WebComp_Transactioncomponent.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188103413", true, true);
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
         context.AddJavascriptSource("deptogeneral.js", "?2024188103413", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgUpdate_Internalname = sPrefix+"UPDATE";
         imgDelete_Internalname = sPrefix+"DELETE";
         tblK2btableactionsrightcontainer_Internalname = sPrefix+"K2BTABLEACTIONSRIGHTCONTAINER";
         tblTable4_Internalname = sPrefix+"TABLE4";
         divTable2_Internalname = sPrefix+"TABLE2";
         divTable3_Internalname = sPrefix+"TABLE3";
         divTable1_Internalname = sPrefix+"TABLE1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         imgDelete_Visible = 1;
         imgUpdate_Visible = 1;
         imgDelete_Tooltiptext = "";
         imgUpdate_Tooltiptext = "Actualizar";
         WebComp_Transactioncomponent_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0029"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Transactioncomponent_Visible), 5, 0), true);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A259CentrodecostoId',fld:'CENTRODECOSTOID',pic:''},{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'A260DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZ9'},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'imgUpdate_Visible',ctrl:'UPDATE',prop:'Visible'},{av:'imgDelete_Visible',ctrl:'DELETE',prop:'Visible'},{ctrl:'TRANSACTIONCOMPONENT',prop:'Visible'},{ctrl:'TRANSACTIONCOMPONENT'}]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13622',iparms:[{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14622',iparms:[{av:'AV6CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV7DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
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
         wcpOGx_mode = "";
         wcpOAV6CentrodecostoId = "";
         wcpOAV9TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A259CentrodecostoId = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         WebComp_Transactioncomponent_Component = "";
         OldTransactioncomponent = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV13ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         scmdbuf = "";
         H00622_A260DepartamentoId = new short[1] ;
         H00622_A259CentrodecostoId = new string[] {""} ;
         AV11TrnContext = new SdtK2BTrnContext(context);
         GXt_char1 = "";
         sStyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgUpdate_Jsonclick = "";
         imgDelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV6CentrodecostoId = "";
         sCtrlAV7DepartamentoId = "";
         sCtrlAV9TabCode = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.deptogeneral__datastore2(),
            new Object[][] {
                new Object[] {
               H00622_A260DepartamentoId, H00622_A259CentrodecostoId
               }
            }
         );
         WebComp_Transactioncomponent = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV7DepartamentoId ;
      private short wcpOAV7DepartamentoId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A260DepartamentoId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV17GXLvl26 ;
      private short nGXWrapped ;
      private int WebComp_Transactioncomponent_Visible ;
      private int imgUpdate_Visible ;
      private int imgDelete_Visible ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV9TabCode ;
      private string wcpOGx_mode ;
      private string wcpOAV9TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable3_Internalname ;
      private string WebComp_Transactioncomponent_Component ;
      private string OldTransactioncomponent ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string imgUpdate_Tooltiptext ;
      private string imgUpdate_Internalname ;
      private string imgDelete_Tooltiptext ;
      private string imgDelete_Internalname ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTable4_Internalname ;
      private string tblK2btableactionsrightcontainer_Internalname ;
      private string TempTags ;
      private string sImgUrl ;
      private string imgUpdate_Jsonclick ;
      private string imgDelete_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV6CentrodecostoId ;
      private string sCtrlAV7DepartamentoId ;
      private string sCtrlAV9TabCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Transactioncomponent ;
      private string AV6CentrodecostoId ;
      private string wcpOAV6CentrodecostoId ;
      private string A259CentrodecostoId ;
      private GXWebComponent WebComp_Transactioncomponent ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore2 ;
      private short[] H00622_A260DepartamentoId ;
      private string[] H00622_A259CentrodecostoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV12ActivityList ;
      private SdtK2BTrnContext AV11TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV13ActivityListItem ;
   }

   public class deptogeneral__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00622;
          prmH00622 = new Object[] {
          new ParDef("@AV6CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@AV7DepartamentoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00622", "SELECT [DepartamentoId], [CentrodecostoId] FROM dbo.[Depto] WHERE [CentrodecostoId] = @AV6CentrodecostoId and [DepartamentoId] = @AV7DepartamentoId ORDER BY [CentrodecostoId], [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00622,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

}
