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
   public class gx0060 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0060( )
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

      public gx0060( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pSatisfaccionId )
      {
         this.AV13pSatisfaccionId = 0 ;
         executePrivate();
         aP0_pSatisfaccionId=this.AV13pSatisfaccionId;
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
            gxfirstwebparm = GetFirstPar( "pSatisfaccionId");
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
               gxfirstwebparm = GetFirstPar( "pSatisfaccionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSatisfaccionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
               sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
               AV6cSatisfaccionId = (long)(NumberUtil.Val( GetPar( "cSatisfaccionId"), "."));
               AV7cSatisfaccionFecha = context.localUtil.ParseDateParm( GetPar( "cSatisfaccionFecha"));
               AV9cSatisfaccionResueltoId = (short)(NumberUtil.Val( GetPar( "cSatisfaccionResueltoId"), "."));
               AV10cSatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( GetPar( "cSatisfaccionTecnicoProblemaId"), "."));
               AV11cSatisfaccionTecnicoCompetenteId = (short)(NumberUtil.Val( GetPar( "cSatisfaccionTecnicoCompetenteId"), "."));
               AV12cSatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( GetPar( "cSatisfaccionTecnicoProfesionalismoId"), "."));
               AV15cSatisfaccionTiempoId = (short)(NumberUtil.Val( GetPar( "cSatisfaccionTiempoId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId) ;
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
               AV13pSatisfaccionId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV13pSatisfaccionId), 10, 0));
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
            return "gx0060_Execute" ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA0C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0C2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188224274", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSatisfaccionId,10,0))}, new string[] {"pSatisfaccionId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSatisfaccionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONFECHA", context.localUtil.Format(AV7cSatisfaccionFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONRESUELTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cSatisfaccionResueltoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONTECNICOPROBLEMAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cSatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONTECNICOCOMPETENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cSatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONTECNICOPROFESIONALISMOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cSatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSATISFACCIONTIEMPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cSatisfaccionTiempoId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPSATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pSatisfaccionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfaccionidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfaccionfechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONRESUELTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfaccionresueltoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONTECNICOPROBLEMAIDFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfacciontecnicoproblemaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONTECNICOCOMPETENTEIDFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfacciontecnicocompetenteidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONTECNICOPROFESIONALISMOIDFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfacciontecnicoprofesionalismoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONTIEMPOIDFILTERCONTAINER_Class", StringUtil.RTrim( divSatisfacciontiempoidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0C2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSatisfaccionId,10,0))}, new string[] {"pSatisfaccionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0060" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Satisfaccion" ;
      }

      protected void WB0C0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSatisfaccionidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfaccionidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfaccionidfilter_Internalname, "Id", "", "", lblLblsatisfaccionidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfaccionid_Internalname, "Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsatisfaccionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSatisfaccionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCsatisfaccionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSatisfaccionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cSatisfaccionId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfaccionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsatisfaccionid_Visible, edtavCsatisfaccionid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divSatisfaccionfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfaccionfechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfaccionfechafilter_Internalname, "Fecha", "", "", lblLblsatisfaccionfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120c1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfaccionfecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCsatisfaccionfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCsatisfaccionfecha_Internalname, context.localUtil.Format(AV7cSatisfaccionFecha, "99/99/9999"), context.localUtil.Format( AV7cSatisfaccionFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfaccionfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCsatisfaccionfecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divSatisfaccionresueltoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfaccionresueltoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfaccionresueltoidfilter_Internalname, "Satisfaccion Resuelto Id", "", "", lblLblsatisfaccionresueltoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfaccionresueltoid_Internalname, "Satisfaccion Resuelto Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsatisfaccionresueltoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cSatisfaccionResueltoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsatisfaccionresueltoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cSatisfaccionResueltoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cSatisfaccionResueltoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfaccionresueltoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsatisfaccionresueltoid_Visible, edtavCsatisfaccionresueltoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divSatisfacciontecnicoproblemaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfacciontecnicoproblemaidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfacciontecnicoproblemaidfilter_Internalname, "Satisfaccion Tecnico Problema Id", "", "", lblLblsatisfacciontecnicoproblemaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfacciontecnicoproblemaid_Internalname, "Satisfaccion Tecnico Problema Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsatisfacciontecnicoproblemaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cSatisfaccionTecnicoProblemaId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsatisfacciontecnicoproblemaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cSatisfaccionTecnicoProblemaId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cSatisfaccionTecnicoProblemaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfacciontecnicoproblemaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsatisfacciontecnicoproblemaid_Visible, edtavCsatisfacciontecnicoproblemaid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divSatisfacciontecnicocompetenteidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfacciontecnicocompetenteidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfacciontecnicocompetenteidfilter_Internalname, "Satisfaccion Tecnico Competente Id", "", "", lblLblsatisfacciontecnicocompetenteidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfacciontecnicocompetenteid_Internalname, "Satisfaccion Tecnico Competente Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsatisfacciontecnicocompetenteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cSatisfaccionTecnicoCompetenteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsatisfacciontecnicocompetenteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cSatisfaccionTecnicoCompetenteId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cSatisfaccionTecnicoCompetenteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfacciontecnicocompetenteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsatisfacciontecnicocompetenteid_Visible, edtavCsatisfacciontecnicocompetenteid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divSatisfacciontecnicoprofesionalismoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfacciontecnicoprofesionalismoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfacciontecnicoprofesionalismoidfilter_Internalname, "Satisfaccion Tecnico Profesionalismo Id", "", "", lblLblsatisfacciontecnicoprofesionalismoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfacciontecnicoprofesionalismoid_Internalname, "Satisfaccion Tecnico Profesionalismo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsatisfacciontecnicoprofesionalismoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cSatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsatisfacciontecnicoprofesionalismoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cSatisfaccionTecnicoProfesionalismoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cSatisfaccionTecnicoProfesionalismoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfacciontecnicoprofesionalismoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsatisfacciontecnicoprofesionalismoid_Visible, edtavCsatisfacciontecnicoprofesionalismoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divSatisfacciontiempoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSatisfacciontiempoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsatisfacciontiempoidfilter_Internalname, "Satisfaccion Tiempo Id", "", "", lblLblsatisfacciontiempoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsatisfacciontiempoid_Internalname, "Satisfaccion Tiempo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsatisfacciontiempoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cSatisfaccionTiempoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsatisfacciontiempoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15cSatisfaccionTiempoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV15cSatisfaccionTiempoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsatisfacciontiempoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsatisfacciontiempoid_Visible, edtavCsatisfacciontiempoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180c1_client"+"'", TempTags, "", 2, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Encuesta:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSatisfaccionFecha_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A144SatisfaccionHora, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0C2( )
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
            Form.Meta.addItem("description", "Selection List Satisfaccion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0C0( ) ;
      }

      protected void WS0C2( )
      {
         START0C2( ) ;
         EVT0C2( ) ;
      }

      protected void EVT0C2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtSatisfaccionId_Internalname), ".", ","));
                              A32SatisfaccionFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSatisfaccionFecha_Internalname), 0));
                              A8SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionResueltoId_Internalname), ".", ","));
                              A9SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProblemaId_Internalname), ".", ","));
                              A10SatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoCompetenteId_Internalname), ".", ","));
                              A144SatisfaccionHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtSatisfaccionHora_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csatisfaccionid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONID"), ".", ",") != Convert.ToDecimal( AV6cSatisfaccionId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csatisfaccionfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCSATISFACCIONFECHA"), 0) != AV7cSatisfaccionFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csatisfaccionresueltoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONRESUELTOID"), ".", ",") != Convert.ToDecimal( AV9cSatisfaccionResueltoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csatisfacciontecnicoproblemaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTECNICOPROBLEMAID"), ".", ",") != Convert.ToDecimal( AV10cSatisfaccionTecnicoProblemaId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csatisfacciontecnicocompetenteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTECNICOCOMPETENTEID"), ".", ",") != Convert.ToDecimal( AV11cSatisfaccionTecnicoCompetenteId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csatisfacciontecnicoprofesionalismoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTECNICOPROFESIONALISMOID"), ".", ",") != Convert.ToDecimal( AV12cSatisfaccionTecnicoProfesionalismoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csatisfacciontiempoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTIEMPOID"), ".", ",") != Convert.ToDecimal( AV15cSatisfaccionTiempoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210C2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE0C2( )
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

      protected void PA0C2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cSatisfaccionId ,
                                        DateTime AV7cSatisfaccionFecha ,
                                        short AV9cSatisfaccionResueltoId ,
                                        short AV10cSatisfaccionTecnicoProblemaId ,
                                        short AV11cSatisfaccionTecnicoCompetenteId ,
                                        short AV12cSatisfaccionTecnicoProfesionalismoId ,
                                        short AV15cSatisfaccionTiempoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SATISFACCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")));
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
         RF0C2( ) ;
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

      protected void RF0C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cSatisfaccionFecha ,
                                                 AV9cSatisfaccionResueltoId ,
                                                 AV10cSatisfaccionTecnicoProblemaId ,
                                                 AV11cSatisfaccionTecnicoCompetenteId ,
                                                 AV12cSatisfaccionTecnicoProfesionalismoId ,
                                                 AV15cSatisfaccionTiempoId ,
                                                 A32SatisfaccionFecha ,
                                                 A8SatisfaccionResueltoId ,
                                                 A9SatisfaccionTecnicoProblemaId ,
                                                 A10SatisfaccionTecnicoCompetenteId ,
                                                 A11SatisfaccionTecnicoProfesionalismoId ,
                                                 A12SatisfaccionTiempoId ,
                                                 AV6cSatisfaccionId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H000C2 */
            pr_default.execute(0, new Object[] {AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A12SatisfaccionTiempoId = H000C2_A12SatisfaccionTiempoId[0];
               A11SatisfaccionTecnicoProfesionalismoId = H000C2_A11SatisfaccionTecnicoProfesionalismoId[0];
               A14TicketId = H000C2_A14TicketId[0];
               A144SatisfaccionHora = H000C2_A144SatisfaccionHora[0];
               A10SatisfaccionTecnicoCompetenteId = H000C2_A10SatisfaccionTecnicoCompetenteId[0];
               A9SatisfaccionTecnicoProblemaId = H000C2_A9SatisfaccionTecnicoProblemaId[0];
               A8SatisfaccionResueltoId = H000C2_A8SatisfaccionResueltoId[0];
               A32SatisfaccionFecha = H000C2_A32SatisfaccionFecha[0];
               A7SatisfaccionId = H000C2_A7SatisfaccionId[0];
               /* Execute user event: Load */
               E200C2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0C0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0C2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SATISFACCIONID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cSatisfaccionFecha ,
                                              AV9cSatisfaccionResueltoId ,
                                              AV10cSatisfaccionTecnicoProblemaId ,
                                              AV11cSatisfaccionTecnicoCompetenteId ,
                                              AV12cSatisfaccionTecnicoProfesionalismoId ,
                                              AV15cSatisfaccionTiempoId ,
                                              A32SatisfaccionFecha ,
                                              A8SatisfaccionResueltoId ,
                                              A9SatisfaccionTecnicoProblemaId ,
                                              A10SatisfaccionTecnicoCompetenteId ,
                                              A11SatisfaccionTecnicoProfesionalismoId ,
                                              A12SatisfaccionTiempoId ,
                                              AV6cSatisfaccionId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         /* Using cursor H000C3 */
         pr_default.execute(1, new Object[] {AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId});
         GRID1_nRecordCount = H000C3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSatisfaccionId, AV7cSatisfaccionFecha, AV9cSatisfaccionResueltoId, AV10cSatisfaccionTecnicoProblemaId, AV11cSatisfaccionTecnicoCompetenteId, AV12cSatisfaccionTecnicoProfesionalismoId, AV15cSatisfaccionTiempoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsatisfaccionid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsatisfaccionid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSATISFACCIONID");
               GX_FocusControl = edtavCsatisfaccionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSatisfaccionId = 0;
               AssignAttri("", false, "AV6cSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV6cSatisfaccionId), 10, 0));
            }
            else
            {
               AV6cSatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtavCsatisfaccionid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV6cSatisfaccionId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCsatisfaccionfecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "vCSATISFACCIONFECHA");
               GX_FocusControl = edtavCsatisfaccionfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cSatisfaccionFecha = DateTime.MinValue;
               AssignAttri("", false, "AV7cSatisfaccionFecha", context.localUtil.Format(AV7cSatisfaccionFecha, "99/99/9999"));
            }
            else
            {
               AV7cSatisfaccionFecha = context.localUtil.CToD( cgiGet( edtavCsatisfaccionfecha_Internalname), 2);
               AssignAttri("", false, "AV7cSatisfaccionFecha", context.localUtil.Format(AV7cSatisfaccionFecha, "99/99/9999"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsatisfaccionresueltoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsatisfaccionresueltoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSATISFACCIONRESUELTOID");
               GX_FocusControl = edtavCsatisfaccionresueltoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cSatisfaccionResueltoId = 0;
               AssignAttri("", false, "AV9cSatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(AV9cSatisfaccionResueltoId), 4, 0));
            }
            else
            {
               AV9cSatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( edtavCsatisfaccionresueltoid_Internalname), ".", ","));
               AssignAttri("", false, "AV9cSatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(AV9cSatisfaccionResueltoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicoproblemaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicoproblemaid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSATISFACCIONTECNICOPROBLEMAID");
               GX_FocusControl = edtavCsatisfacciontecnicoproblemaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cSatisfaccionTecnicoProblemaId = 0;
               AssignAttri("", false, "AV10cSatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV10cSatisfaccionTecnicoProblemaId), 4, 0));
            }
            else
            {
               AV10cSatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicoproblemaid_Internalname), ".", ","));
               AssignAttri("", false, "AV10cSatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV10cSatisfaccionTecnicoProblemaId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicocompetenteid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicocompetenteid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSATISFACCIONTECNICOCOMPETENTEID");
               GX_FocusControl = edtavCsatisfacciontecnicocompetenteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cSatisfaccionTecnicoCompetenteId = 0;
               AssignAttri("", false, "AV11cSatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(AV11cSatisfaccionTecnicoCompetenteId), 4, 0));
            }
            else
            {
               AV11cSatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicocompetenteid_Internalname), ".", ","));
               AssignAttri("", false, "AV11cSatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(AV11cSatisfaccionTecnicoCompetenteId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicoprofesionalismoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicoprofesionalismoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSATISFACCIONTECNICOPROFESIONALISMOID");
               GX_FocusControl = edtavCsatisfacciontecnicoprofesionalismoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cSatisfaccionTecnicoProfesionalismoId = 0;
               AssignAttri("", false, "AV12cSatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(AV12cSatisfaccionTecnicoProfesionalismoId), 4, 0));
            }
            else
            {
               AV12cSatisfaccionTecnicoProfesionalismoId = (short)(context.localUtil.CToN( cgiGet( edtavCsatisfacciontecnicoprofesionalismoid_Internalname), ".", ","));
               AssignAttri("", false, "AV12cSatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(AV12cSatisfaccionTecnicoProfesionalismoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontiempoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsatisfacciontiempoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSATISFACCIONTIEMPOID");
               GX_FocusControl = edtavCsatisfacciontiempoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cSatisfaccionTiempoId = 0;
               AssignAttri("", false, "AV15cSatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(AV15cSatisfaccionTiempoId), 4, 0));
            }
            else
            {
               AV15cSatisfaccionTiempoId = (short)(context.localUtil.CToN( cgiGet( edtavCsatisfacciontiempoid_Internalname), ".", ","));
               AssignAttri("", false, "AV15cSatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(AV15cSatisfaccionTiempoId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONID"), ".", ",") != Convert.ToDecimal( AV6cSatisfaccionId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCSATISFACCIONFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV7cSatisfaccionFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONRESUELTOID"), ".", ",") != Convert.ToDecimal( AV9cSatisfaccionResueltoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTECNICOPROBLEMAID"), ".", ",") != Convert.ToDecimal( AV10cSatisfaccionTecnicoProblemaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTECNICOCOMPETENTEID"), ".", ",") != Convert.ToDecimal( AV11cSatisfaccionTecnicoCompetenteId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTECNICOPROFESIONALISMOID"), ".", ",") != Convert.ToDecimal( AV12cSatisfaccionTecnicoProfesionalismoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSATISFACCIONTIEMPOID"), ".", ",") != Convert.ToDecimal( AV15cSatisfaccionTiempoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E190C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190C2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Satisfaccion", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200C2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pSatisfaccionId = A7SatisfaccionId;
         AssignAttri("", false, "AV13pSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV13pSatisfaccionId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pSatisfaccionId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pSatisfaccionId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pSatisfaccionId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV13pSatisfaccionId), 10, 0));
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
         PA0C2( ) ;
         WS0C2( ) ;
         WE0C2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188224418", true, true);
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
         context.AddJavascriptSource("gx0060.js", "?2024188224419", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtSatisfaccionId_Internalname = "SATISFACCIONID_"+sGXsfl_84_idx;
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA_"+sGXsfl_84_idx;
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID_"+sGXsfl_84_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_84_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_84_idx;
         edtSatisfaccionHora_Internalname = "SATISFACCIONHORA_"+sGXsfl_84_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtSatisfaccionId_Internalname = "SATISFACCIONID_"+sGXsfl_84_fel_idx;
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA_"+sGXsfl_84_fel_idx;
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID_"+sGXsfl_84_fel_idx;
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID_"+sGXsfl_84_fel_idx;
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID_"+sGXsfl_84_fel_idx;
         edtSatisfaccionHora_Internalname = "SATISFACCIONHORA_"+sGXsfl_84_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0C0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtSatisfaccionFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtSatisfaccionFecha_Internalname, "Link", edtSatisfaccionFecha_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionFecha_Internalname,context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"),context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSatisfaccionFecha_Link,(string)"",(string)"",(string)"",(string)edtSatisfaccionFecha_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionResueltoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A8SatisfaccionResueltoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionResueltoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoProblemaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SatisfaccionTecnicoProblemaId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoProblemaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionTecnicoCompetenteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SatisfaccionTecnicoCompetenteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionTecnicoCompetenteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSatisfaccionHora_Internalname,context.localUtil.TToC( A144SatisfaccionHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A144SatisfaccionHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSatisfaccionHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0C2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblsatisfaccionidfilter_Internalname = "LBLSATISFACCIONIDFILTER";
         edtavCsatisfaccionid_Internalname = "vCSATISFACCIONID";
         divSatisfaccionidfiltercontainer_Internalname = "SATISFACCIONIDFILTERCONTAINER";
         lblLblsatisfaccionfechafilter_Internalname = "LBLSATISFACCIONFECHAFILTER";
         edtavCsatisfaccionfecha_Internalname = "vCSATISFACCIONFECHA";
         divSatisfaccionfechafiltercontainer_Internalname = "SATISFACCIONFECHAFILTERCONTAINER";
         lblLblsatisfaccionresueltoidfilter_Internalname = "LBLSATISFACCIONRESUELTOIDFILTER";
         edtavCsatisfaccionresueltoid_Internalname = "vCSATISFACCIONRESUELTOID";
         divSatisfaccionresueltoidfiltercontainer_Internalname = "SATISFACCIONRESUELTOIDFILTERCONTAINER";
         lblLblsatisfacciontecnicoproblemaidfilter_Internalname = "LBLSATISFACCIONTECNICOPROBLEMAIDFILTER";
         edtavCsatisfacciontecnicoproblemaid_Internalname = "vCSATISFACCIONTECNICOPROBLEMAID";
         divSatisfacciontecnicoproblemaidfiltercontainer_Internalname = "SATISFACCIONTECNICOPROBLEMAIDFILTERCONTAINER";
         lblLblsatisfacciontecnicocompetenteidfilter_Internalname = "LBLSATISFACCIONTECNICOCOMPETENTEIDFILTER";
         edtavCsatisfacciontecnicocompetenteid_Internalname = "vCSATISFACCIONTECNICOCOMPETENTEID";
         divSatisfacciontecnicocompetenteidfiltercontainer_Internalname = "SATISFACCIONTECNICOCOMPETENTEIDFILTERCONTAINER";
         lblLblsatisfacciontecnicoprofesionalismoidfilter_Internalname = "LBLSATISFACCIONTECNICOPROFESIONALISMOIDFILTER";
         edtavCsatisfacciontecnicoprofesionalismoid_Internalname = "vCSATISFACCIONTECNICOPROFESIONALISMOID";
         divSatisfacciontecnicoprofesionalismoidfiltercontainer_Internalname = "SATISFACCIONTECNICOPROFESIONALISMOIDFILTERCONTAINER";
         lblLblsatisfacciontiempoidfilter_Internalname = "LBLSATISFACCIONTIEMPOIDFILTER";
         edtavCsatisfacciontiempoid_Internalname = "vCSATISFACCIONTIEMPOID";
         divSatisfacciontiempoidfiltercontainer_Internalname = "SATISFACCIONTIEMPOIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSatisfaccionId_Internalname = "SATISFACCIONID";
         edtSatisfaccionFecha_Internalname = "SATISFACCIONFECHA";
         edtSatisfaccionResueltoId_Internalname = "SATISFACCIONRESUELTOID";
         edtSatisfaccionTecnicoProblemaId_Internalname = "SATISFACCIONTECNICOPROBLEMAID";
         edtSatisfaccionTecnicoCompetenteId_Internalname = "SATISFACCIONTECNICOCOMPETENTEID";
         edtSatisfaccionHora_Internalname = "SATISFACCIONHORA";
         edtTicketId_Internalname = "TICKETID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtTicketId_Jsonclick = "";
         edtSatisfaccionHora_Jsonclick = "";
         edtSatisfaccionTecnicoCompetenteId_Jsonclick = "";
         edtSatisfaccionTecnicoProblemaId_Jsonclick = "";
         edtSatisfaccionResueltoId_Jsonclick = "";
         edtSatisfaccionFecha_Jsonclick = "";
         edtSatisfaccionId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtSatisfaccionFecha_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCsatisfacciontiempoid_Jsonclick = "";
         edtavCsatisfacciontiempoid_Enabled = 1;
         edtavCsatisfacciontiempoid_Visible = 1;
         edtavCsatisfacciontecnicoprofesionalismoid_Jsonclick = "";
         edtavCsatisfacciontecnicoprofesionalismoid_Enabled = 1;
         edtavCsatisfacciontecnicoprofesionalismoid_Visible = 1;
         edtavCsatisfacciontecnicocompetenteid_Jsonclick = "";
         edtavCsatisfacciontecnicocompetenteid_Enabled = 1;
         edtavCsatisfacciontecnicocompetenteid_Visible = 1;
         edtavCsatisfacciontecnicoproblemaid_Jsonclick = "";
         edtavCsatisfacciontecnicoproblemaid_Enabled = 1;
         edtavCsatisfacciontecnicoproblemaid_Visible = 1;
         edtavCsatisfaccionresueltoid_Jsonclick = "";
         edtavCsatisfaccionresueltoid_Enabled = 1;
         edtavCsatisfaccionresueltoid_Visible = 1;
         edtavCsatisfaccionfecha_Jsonclick = "";
         edtavCsatisfaccionfecha_Enabled = 1;
         edtavCsatisfaccionid_Jsonclick = "";
         edtavCsatisfaccionid_Enabled = 1;
         edtavCsatisfaccionid_Visible = 1;
         divSatisfacciontiempoidfiltercontainer_Class = "AdvancedContainerItem";
         divSatisfacciontecnicoprofesionalismoidfiltercontainer_Class = "AdvancedContainerItem";
         divSatisfacciontecnicocompetenteidfiltercontainer_Class = "AdvancedContainerItem";
         divSatisfacciontecnicoproblemaidfiltercontainer_Class = "AdvancedContainerItem";
         divSatisfaccionresueltoidfiltercontainer_Class = "AdvancedContainerItem";
         divSatisfaccionfechafiltercontainer_Class = "AdvancedContainerItem";
         divSatisfaccionidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Satisfaccion";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSatisfaccionId',fld:'vCSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cSatisfaccionFecha',fld:'vCSATISFACCIONFECHA',pic:''},{av:'AV9cSatisfaccionResueltoId',fld:'vCSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'AV10cSatisfaccionTecnicoProblemaId',fld:'vCSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV11cSatisfaccionTecnicoCompetenteId',fld:'vCSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'AV12cSatisfaccionTecnicoProfesionalismoId',fld:'vCSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'AV15cSatisfaccionTiempoId',fld:'vCSATISFACCIONTIEMPOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180C1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLSATISFACCIONIDFILTER.CLICK","{handler:'E110C1',iparms:[{av:'divSatisfaccionidfiltercontainer_Class',ctrl:'SATISFACCIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONIDFILTER.CLICK",",oparms:[{av:'divSatisfaccionidfiltercontainer_Class',ctrl:'SATISFACCIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsatisfaccionid_Visible',ctrl:'vCSATISFACCIONID',prop:'Visible'}]}");
         setEventMetadata("LBLSATISFACCIONFECHAFILTER.CLICK","{handler:'E120C1',iparms:[{av:'divSatisfaccionfechafiltercontainer_Class',ctrl:'SATISFACCIONFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONFECHAFILTER.CLICK",",oparms:[{av:'divSatisfaccionfechafiltercontainer_Class',ctrl:'SATISFACCIONFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLSATISFACCIONRESUELTOIDFILTER.CLICK","{handler:'E130C1',iparms:[{av:'divSatisfaccionresueltoidfiltercontainer_Class',ctrl:'SATISFACCIONRESUELTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONRESUELTOIDFILTER.CLICK",",oparms:[{av:'divSatisfaccionresueltoidfiltercontainer_Class',ctrl:'SATISFACCIONRESUELTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsatisfaccionresueltoid_Visible',ctrl:'vCSATISFACCIONRESUELTOID',prop:'Visible'}]}");
         setEventMetadata("LBLSATISFACCIONTECNICOPROBLEMAIDFILTER.CLICK","{handler:'E140C1',iparms:[{av:'divSatisfacciontecnicoproblemaidfiltercontainer_Class',ctrl:'SATISFACCIONTECNICOPROBLEMAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONTECNICOPROBLEMAIDFILTER.CLICK",",oparms:[{av:'divSatisfacciontecnicoproblemaidfiltercontainer_Class',ctrl:'SATISFACCIONTECNICOPROBLEMAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsatisfacciontecnicoproblemaid_Visible',ctrl:'vCSATISFACCIONTECNICOPROBLEMAID',prop:'Visible'}]}");
         setEventMetadata("LBLSATISFACCIONTECNICOCOMPETENTEIDFILTER.CLICK","{handler:'E150C1',iparms:[{av:'divSatisfacciontecnicocompetenteidfiltercontainer_Class',ctrl:'SATISFACCIONTECNICOCOMPETENTEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONTECNICOCOMPETENTEIDFILTER.CLICK",",oparms:[{av:'divSatisfacciontecnicocompetenteidfiltercontainer_Class',ctrl:'SATISFACCIONTECNICOCOMPETENTEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsatisfacciontecnicocompetenteid_Visible',ctrl:'vCSATISFACCIONTECNICOCOMPETENTEID',prop:'Visible'}]}");
         setEventMetadata("LBLSATISFACCIONTECNICOPROFESIONALISMOIDFILTER.CLICK","{handler:'E160C1',iparms:[{av:'divSatisfacciontecnicoprofesionalismoidfiltercontainer_Class',ctrl:'SATISFACCIONTECNICOPROFESIONALISMOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONTECNICOPROFESIONALISMOIDFILTER.CLICK",",oparms:[{av:'divSatisfacciontecnicoprofesionalismoidfiltercontainer_Class',ctrl:'SATISFACCIONTECNICOPROFESIONALISMOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsatisfacciontecnicoprofesionalismoid_Visible',ctrl:'vCSATISFACCIONTECNICOPROFESIONALISMOID',prop:'Visible'}]}");
         setEventMetadata("LBLSATISFACCIONTIEMPOIDFILTER.CLICK","{handler:'E170C1',iparms:[{av:'divSatisfacciontiempoidfiltercontainer_Class',ctrl:'SATISFACCIONTIEMPOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSATISFACCIONTIEMPOIDFILTER.CLICK",",oparms:[{av:'divSatisfacciontiempoidfiltercontainer_Class',ctrl:'SATISFACCIONTIEMPOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsatisfacciontiempoid_Visible',ctrl:'vCSATISFACCIONTIEMPOID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210C2',iparms:[{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pSatisfaccionId',fld:'vPSATISFACCIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSatisfaccionId',fld:'vCSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cSatisfaccionFecha',fld:'vCSATISFACCIONFECHA',pic:''},{av:'AV9cSatisfaccionResueltoId',fld:'vCSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'AV10cSatisfaccionTecnicoProblemaId',fld:'vCSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV11cSatisfaccionTecnicoCompetenteId',fld:'vCSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'AV12cSatisfaccionTecnicoProfesionalismoId',fld:'vCSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'AV15cSatisfaccionTiempoId',fld:'vCSATISFACCIONTIEMPOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSatisfaccionId',fld:'vCSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cSatisfaccionFecha',fld:'vCSATISFACCIONFECHA',pic:''},{av:'AV9cSatisfaccionResueltoId',fld:'vCSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'AV10cSatisfaccionTecnicoProblemaId',fld:'vCSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV11cSatisfaccionTecnicoCompetenteId',fld:'vCSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'AV12cSatisfaccionTecnicoProfesionalismoId',fld:'vCSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'AV15cSatisfaccionTiempoId',fld:'vCSATISFACCIONTIEMPOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSatisfaccionId',fld:'vCSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cSatisfaccionFecha',fld:'vCSATISFACCIONFECHA',pic:''},{av:'AV9cSatisfaccionResueltoId',fld:'vCSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'AV10cSatisfaccionTecnicoProblemaId',fld:'vCSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV11cSatisfaccionTecnicoCompetenteId',fld:'vCSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'AV12cSatisfaccionTecnicoProfesionalismoId',fld:'vCSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'AV15cSatisfaccionTiempoId',fld:'vCSATISFACCIONTIEMPOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSatisfaccionId',fld:'vCSATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'AV7cSatisfaccionFecha',fld:'vCSATISFACCIONFECHA',pic:''},{av:'AV9cSatisfaccionResueltoId',fld:'vCSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'AV10cSatisfaccionTecnicoProblemaId',fld:'vCSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'AV11cSatisfaccionTecnicoCompetenteId',fld:'vCSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'AV12cSatisfaccionTecnicoProfesionalismoId',fld:'vCSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'AV15cSatisfaccionTiempoId',fld:'vCSATISFACCIONTIEMPOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CSATISFACCIONFECHA","{handler:'Validv_Csatisfaccionfecha',iparms:[]");
         setEventMetadata("VALIDV_CSATISFACCIONFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Ticketid',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cSatisfaccionFecha = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsatisfaccionidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsatisfaccionfechafilter_Jsonclick = "";
         lblLblsatisfaccionresueltoidfilter_Jsonclick = "";
         lblLblsatisfacciontecnicoproblemaidfilter_Jsonclick = "";
         lblLblsatisfacciontecnicocompetenteidfilter_Jsonclick = "";
         lblLblsatisfacciontecnicoprofesionalismoidfilter_Jsonclick = "";
         lblLblsatisfacciontiempoidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Linkselection_GXI = "";
         scmdbuf = "";
         H000C2_A12SatisfaccionTiempoId = new short[1] ;
         H000C2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         H000C2_A14TicketId = new long[1] ;
         H000C2_A144SatisfaccionHora = new DateTime[] {DateTime.MinValue} ;
         H000C2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         H000C2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         H000C2_A8SatisfaccionResueltoId = new short[1] ;
         H000C2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         H000C2_A7SatisfaccionId = new long[1] ;
         H000C3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0060__default(),
            new Object[][] {
                new Object[] {
               H000C2_A12SatisfaccionTiempoId, H000C2_A11SatisfaccionTecnicoProfesionalismoId, H000C2_A14TicketId, H000C2_A144SatisfaccionHora, H000C2_A10SatisfaccionTecnicoCompetenteId, H000C2_A9SatisfaccionTecnicoProblemaId, H000C2_A8SatisfaccionResueltoId, H000C2_A32SatisfaccionFecha, H000C2_A7SatisfaccionId
               }
               , new Object[] {
               H000C3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV9cSatisfaccionResueltoId ;
      private short AV10cSatisfaccionTecnicoProblemaId ;
      private short AV11cSatisfaccionTecnicoCompetenteId ;
      private short AV12cSatisfaccionTecnicoProfesionalismoId ;
      private short AV15cSatisfaccionTiempoId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCsatisfaccionid_Enabled ;
      private int edtavCsatisfaccionid_Visible ;
      private int edtavCsatisfaccionfecha_Enabled ;
      private int edtavCsatisfaccionresueltoid_Enabled ;
      private int edtavCsatisfaccionresueltoid_Visible ;
      private int edtavCsatisfacciontecnicoproblemaid_Enabled ;
      private int edtavCsatisfacciontecnicoproblemaid_Visible ;
      private int edtavCsatisfacciontecnicocompetenteid_Enabled ;
      private int edtavCsatisfacciontecnicocompetenteid_Visible ;
      private int edtavCsatisfacciontecnicoprofesionalismoid_Enabled ;
      private int edtavCsatisfacciontecnicoprofesionalismoid_Visible ;
      private int edtavCsatisfacciontiempoid_Enabled ;
      private int edtavCsatisfacciontiempoid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long AV13pSatisfaccionId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cSatisfaccionId ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divSatisfaccionidfiltercontainer_Class ;
      private string divSatisfaccionfechafiltercontainer_Class ;
      private string divSatisfaccionresueltoidfiltercontainer_Class ;
      private string divSatisfacciontecnicoproblemaidfiltercontainer_Class ;
      private string divSatisfacciontecnicocompetenteidfiltercontainer_Class ;
      private string divSatisfacciontecnicoprofesionalismoidfiltercontainer_Class ;
      private string divSatisfacciontiempoidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSatisfaccionidfiltercontainer_Internalname ;
      private string lblLblsatisfaccionidfilter_Internalname ;
      private string lblLblsatisfaccionidfilter_Jsonclick ;
      private string edtavCsatisfaccionid_Internalname ;
      private string TempTags ;
      private string edtavCsatisfaccionid_Jsonclick ;
      private string divSatisfaccionfechafiltercontainer_Internalname ;
      private string lblLblsatisfaccionfechafilter_Internalname ;
      private string lblLblsatisfaccionfechafilter_Jsonclick ;
      private string edtavCsatisfaccionfecha_Internalname ;
      private string edtavCsatisfaccionfecha_Jsonclick ;
      private string divSatisfaccionresueltoidfiltercontainer_Internalname ;
      private string lblLblsatisfaccionresueltoidfilter_Internalname ;
      private string lblLblsatisfaccionresueltoidfilter_Jsonclick ;
      private string edtavCsatisfaccionresueltoid_Internalname ;
      private string edtavCsatisfaccionresueltoid_Jsonclick ;
      private string divSatisfacciontecnicoproblemaidfiltercontainer_Internalname ;
      private string lblLblsatisfacciontecnicoproblemaidfilter_Internalname ;
      private string lblLblsatisfacciontecnicoproblemaidfilter_Jsonclick ;
      private string edtavCsatisfacciontecnicoproblemaid_Internalname ;
      private string edtavCsatisfacciontecnicoproblemaid_Jsonclick ;
      private string divSatisfacciontecnicocompetenteidfiltercontainer_Internalname ;
      private string lblLblsatisfacciontecnicocompetenteidfilter_Internalname ;
      private string lblLblsatisfacciontecnicocompetenteidfilter_Jsonclick ;
      private string edtavCsatisfacciontecnicocompetenteid_Internalname ;
      private string edtavCsatisfacciontecnicocompetenteid_Jsonclick ;
      private string divSatisfacciontecnicoprofesionalismoidfiltercontainer_Internalname ;
      private string lblLblsatisfacciontecnicoprofesionalismoidfilter_Internalname ;
      private string lblLblsatisfacciontecnicoprofesionalismoidfilter_Jsonclick ;
      private string edtavCsatisfacciontecnicoprofesionalismoid_Internalname ;
      private string edtavCsatisfacciontecnicoprofesionalismoid_Jsonclick ;
      private string divSatisfacciontiempoidfiltercontainer_Internalname ;
      private string lblLblsatisfacciontiempoidfilter_Internalname ;
      private string lblLblsatisfacciontiempoidfilter_Jsonclick ;
      private string edtavCsatisfacciontiempoid_Internalname ;
      private string edtavCsatisfacciontiempoid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtSatisfaccionFecha_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtSatisfaccionId_Internalname ;
      private string edtSatisfaccionFecha_Internalname ;
      private string edtSatisfaccionResueltoId_Internalname ;
      private string edtSatisfaccionTecnicoProblemaId_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteId_Internalname ;
      private string edtSatisfaccionHora_Internalname ;
      private string edtTicketId_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSatisfaccionId_Jsonclick ;
      private string edtSatisfaccionFecha_Jsonclick ;
      private string edtSatisfaccionResueltoId_Jsonclick ;
      private string edtSatisfaccionTecnicoProblemaId_Jsonclick ;
      private string edtSatisfaccionTecnicoCompetenteId_Jsonclick ;
      private string edtSatisfaccionHora_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private DateTime A144SatisfaccionHora ;
      private DateTime AV7cSatisfaccionFecha ;
      private DateTime A32SatisfaccionFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV18Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000C2_A12SatisfaccionTiempoId ;
      private short[] H000C2_A11SatisfaccionTecnicoProfesionalismoId ;
      private long[] H000C2_A14TicketId ;
      private DateTime[] H000C2_A144SatisfaccionHora ;
      private short[] H000C2_A10SatisfaccionTecnicoCompetenteId ;
      private short[] H000C2_A9SatisfaccionTecnicoProblemaId ;
      private short[] H000C2_A8SatisfaccionResueltoId ;
      private DateTime[] H000C2_A32SatisfaccionFecha ;
      private long[] H000C2_A7SatisfaccionId ;
      private long[] H000C3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pSatisfaccionId ;
      private GXWebForm Form ;
   }

   public class gx0060__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000C2( IGxContext context ,
                                             DateTime AV7cSatisfaccionFecha ,
                                             short AV9cSatisfaccionResueltoId ,
                                             short AV10cSatisfaccionTecnicoProblemaId ,
                                             short AV11cSatisfaccionTecnicoCompetenteId ,
                                             short AV12cSatisfaccionTecnicoProfesionalismoId ,
                                             short AV15cSatisfaccionTiempoId ,
                                             DateTime A32SatisfaccionFecha ,
                                             short A8SatisfaccionResueltoId ,
                                             short A9SatisfaccionTecnicoProblemaId ,
                                             short A10SatisfaccionTecnicoCompetenteId ,
                                             short A11SatisfaccionTecnicoProfesionalismoId ,
                                             short A12SatisfaccionTiempoId ,
                                             long AV6cSatisfaccionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SatisfaccionTiempoId], [SatisfaccionTecnicoProfesionalismoId], [TicketId], [SatisfaccionHora], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProblemaId], [SatisfaccionResueltoId], [SatisfaccionFecha], [SatisfaccionId]";
         sFromString = " FROM [Satisfaccion]";
         sOrderString = "";
         AddWhere(sWhereString, "([SatisfaccionId] >= @AV6cSatisfaccionId)");
         if ( ! (DateTime.MinValue==AV7cSatisfaccionFecha) )
         {
            AddWhere(sWhereString, "([SatisfaccionFecha] >= @AV7cSatisfaccionFecha)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV9cSatisfaccionResueltoId) )
         {
            AddWhere(sWhereString, "([SatisfaccionResueltoId] >= @AV9cSatisfaccionResueltoId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV10cSatisfaccionTecnicoProblemaId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTecnicoProblemaId] >= @AV10cSatisfaccionTecnicoProblemaId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV11cSatisfaccionTecnicoCompetenteId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTecnicoCompetenteId] >= @AV11cSatisfaccionTecnicoCompetenteId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV12cSatisfaccionTecnicoProfesionalismoId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTecnicoProfesionalismoId] >= @AV12cSatisfaccionTecnicoProfesionalismoId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV15cSatisfaccionTiempoId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTiempoId] >= @AV15cSatisfaccionTiempoId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [SatisfaccionId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000C3( IGxContext context ,
                                             DateTime AV7cSatisfaccionFecha ,
                                             short AV9cSatisfaccionResueltoId ,
                                             short AV10cSatisfaccionTecnicoProblemaId ,
                                             short AV11cSatisfaccionTecnicoCompetenteId ,
                                             short AV12cSatisfaccionTecnicoProfesionalismoId ,
                                             short AV15cSatisfaccionTiempoId ,
                                             DateTime A32SatisfaccionFecha ,
                                             short A8SatisfaccionResueltoId ,
                                             short A9SatisfaccionTecnicoProblemaId ,
                                             short A10SatisfaccionTecnicoCompetenteId ,
                                             short A11SatisfaccionTecnicoProfesionalismoId ,
                                             short A12SatisfaccionTiempoId ,
                                             long AV6cSatisfaccionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Satisfaccion]";
         AddWhere(sWhereString, "([SatisfaccionId] >= @AV6cSatisfaccionId)");
         if ( ! (DateTime.MinValue==AV7cSatisfaccionFecha) )
         {
            AddWhere(sWhereString, "([SatisfaccionFecha] >= @AV7cSatisfaccionFecha)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV9cSatisfaccionResueltoId) )
         {
            AddWhere(sWhereString, "([SatisfaccionResueltoId] >= @AV9cSatisfaccionResueltoId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV10cSatisfaccionTecnicoProblemaId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTecnicoProblemaId] >= @AV10cSatisfaccionTecnicoProblemaId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV11cSatisfaccionTecnicoCompetenteId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTecnicoCompetenteId] >= @AV11cSatisfaccionTecnicoCompetenteId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV12cSatisfaccionTecnicoProfesionalismoId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTecnicoProfesionalismoId] >= @AV12cSatisfaccionTecnicoProfesionalismoId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV15cSatisfaccionTiempoId) )
         {
            AddWhere(sWhereString, "([SatisfaccionTiempoId] >= @AV15cSatisfaccionTiempoId)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000C2(context, (DateTime)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H000C3(context, (DateTime)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000C2;
          prmH000C2 = new Object[] {
          new ParDef("@AV6cSatisfaccionId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cSatisfaccionFecha",GXType.Date,8,0) ,
          new ParDef("@AV9cSatisfaccionResueltoId",GXType.Int16,4,0) ,
          new ParDef("@AV10cSatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@AV11cSatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
          new ParDef("@AV12cSatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@AV15cSatisfaccionTiempoId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000C3;
          prmH000C3 = new Object[] {
          new ParDef("@AV6cSatisfaccionId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cSatisfaccionFecha",GXType.Date,8,0) ,
          new ParDef("@AV9cSatisfaccionResueltoId",GXType.Int16,4,0) ,
          new ParDef("@AV10cSatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
          new ParDef("@AV11cSatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
          new ParDef("@AV12cSatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
          new ParDef("@AV15cSatisfaccionTiempoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C3,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
