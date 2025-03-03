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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.commonchatbots {
   public class getcomponentbyid : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
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
            return "getcomponentbyid_Services_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("K2BOrion");
         initialize();
         if ( ! context.isAjaxRequest( ) )
         {
            GXSoapHTTPResponse.AppendHeader("Content-type", "text/xml;charset=utf-8");
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.Method), "get") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.QueryString), "wsdl") == 0 )
            {
               GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
               GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
               GXSoapXMLWriter.WriteStartElement("definitions");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentById");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "kb_ticket");
               GXSoapXMLWriter.WriteAttribute("xmlns:wsdlns", "kb_ticket");
               GXSoapXMLWriter.WriteAttribute("xmlns:soap", "http://schemas.xmlsoap.org/wsdl/soap/");
               GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://schemas.xmlsoap.org/wsdl/");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns", "kb_ticket");
               GXSoapXMLWriter.WriteStartElement("types");
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "kb_ticket");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentById.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Chatmessageid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentById.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Sdcomponentlink");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Iscallpanel");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:boolean");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentById.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:CommonChatbots.GetComponentById.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentById.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:CommonChatbots.GetComponentById.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentByIdSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"CommonChatbots.GetComponentById.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"CommonChatbots.GetComponentById.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentByIdSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"CommonChatbots.GetComponentByIdSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "kb_ticketaction/"+"commonchatbots.AGETCOMPONENTBYID.Execute");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("service");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentById");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "CommonChatbots.GetComponentByIdSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"CommonChatbots.GetComponentByIdSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"commonchatbots.getcomponentbyid.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "commonchatbots.getcomponentbyid.aspx" + "?wsdl to get the WSDL.";
            }
         }
         if ( currSoapErr == 0 )
         {
            GXSoapXMLReader.OpenRequest(GXSoapHTTPRequest);
            GXSoapXMLReader.ReadExternalEntities = 0;
            GXSoapXMLReader.IgnoreComments = 1;
            GXSoapError = GXSoapXMLReader.Read();
            while ( GXSoapError > 0 )
            {
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
               }
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
               {
                  if (true) break;
               }
               GXSoapError = GXSoapXMLReader.Read();
            }
            if ( GXSoapError > 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  currMethod = GXSoapXMLReader.Name;
                  if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           GXSoapError = GXSoapXMLReader.Read();
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Chatmessageid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "kb_ticket") == 0 ) )
                              {
                                 AV8ChatMessageId = (Guid)(StringUtil.StrToGuid( GXSoapXMLReader.Value));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     currSoapErr = (short)(-20002);
                     currSoapErrmsg = "Wrong method called. Expected method: " + "Execute";
                  }
               }
            }
            GXSoapXMLReader.Close();
         }
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr == 0 )
         {
            executePrivate();
         }
         context.CloseConnections();
         sIncludeState = true;
         GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("CommonChatbots.GetComponentById.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "kb_ticket");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Sdcomponentlink", StringUtil.RTrim( AV15SDComponentLink));
               GXSoapXMLWriter.WriteAttribute("xmlns", "kb_ticket");
               GXSoapXMLWriter.WriteElement("Iscallpanel", StringUtil.RTrim( StringUtil.BoolToStr( AV13IsCallPanel)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "kb_ticket");
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         cleanup();
      }

      public getcomponentbyid( )
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

      public getcomponentbyid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ChatMessageId ,
                           out string aP1_SDComponentLink ,
                           out bool aP2_IsCallPanel )
      {
         this.AV8ChatMessageId = aP0_ChatMessageId;
         this.AV15SDComponentLink = "" ;
         this.AV13IsCallPanel = false ;
         initialize();
         executePrivate();
         aP1_SDComponentLink=this.AV15SDComponentLink;
         aP2_IsCallPanel=this.AV13IsCallPanel;
      }

      public bool executeUdp( Guid aP0_ChatMessageId ,
                              out string aP1_SDComponentLink )
      {
         execute(aP0_ChatMessageId, out aP1_SDComponentLink, out aP2_IsCallPanel);
         return AV13IsCallPanel ;
      }

      public void executeSubmit( Guid aP0_ChatMessageId ,
                                 out string aP1_SDComponentLink ,
                                 out bool aP2_IsCallPanel )
      {
         getcomponentbyid objgetcomponentbyid;
         objgetcomponentbyid = new getcomponentbyid();
         objgetcomponentbyid.AV8ChatMessageId = aP0_ChatMessageId;
         objgetcomponentbyid.AV15SDComponentLink = "" ;
         objgetcomponentbyid.AV13IsCallPanel = false ;
         objgetcomponentbyid.context.SetSubmitInitialConfig(context);
         objgetcomponentbyid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetcomponentbyid);
         aP1_SDComponentLink=this.AV15SDComponentLink;
         aP2_IsCallPanel=this.AV13IsCallPanel;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getcomponentbyid)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P006W2 */
         pr_default.execute(0, new Object[] {AV8ChatMessageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A267GXChatMessageId = (Guid)((Guid)(P006W2_A267GXChatMessageId[0]));
            A276GXChatMessageMeta = P006W2_A276GXChatMessageMeta[0];
            AV14Meta = A276GXChatMessageMeta;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV9Context.FromJSonString(AV14Meta, null);
         AV9Context.FromJSonString(AV9Context.Get("context"), null);
         AV10GXCallPanelSD = AV9Context.Get("GXCallPanelSD");
         AV12GXComponentSD = AV9Context.Get("GXComponentSD");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10GXCallPanelSD)) )
         {
            AV15SDComponentLink = AV10GXCallPanelSD;
            AV13IsCallPanel = true;
         }
         else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GXComponentSD)) )
         {
            AV15SDComponentLink = AV12GXComponentSD;
            AV13IsCallPanel = false;
         }
         else
         {
            AV13IsCallPanel = false;
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         scmdbuf = "";
         P006W2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         P006W2_A276GXChatMessageMeta = new string[] {""} ;
         A267GXChatMessageId = (Guid)(Guid.Empty);
         A276GXChatMessageMeta = "";
         AV14Meta = "";
         AV9Context = new GXProperties();
         AV10GXCallPanelSD = "";
         AV12GXComponentSD = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.getcomponentbyid__default(),
            new Object[][] {
                new Object[] {
               P006W2_A267GXChatMessageId, P006W2_A276GXChatMessageMeta
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string scmdbuf ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool AV13IsCallPanel ;
      private string A276GXChatMessageMeta ;
      private string AV14Meta ;
      private string AV15SDComponentLink ;
      private string AV10GXCallPanelSD ;
      private string AV12GXComponentSD ;
      private Guid AV8ChatMessageId ;
      private Guid A267GXChatMessageId ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006W2_A267GXChatMessageId ;
      private string[] P006W2_A276GXChatMessageMeta ;
      private string aP1_SDComponentLink ;
      private bool aP2_IsCallPanel ;
      private GXProperties AV9Context ;
   }

   public class getcomponentbyid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006W2;
          prmP006W2 = new Object[] {
          new ParDef("@AV8ChatMessageId",GXType.UniqueIdentifier,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006W2", "SELECT [GXChatMessageId], [GXChatMessageMeta] FROM [GXChatMessage] WHERE [GXChatMessageId] = @AV8ChatMessageId ORDER BY [GXChatMessageId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006W2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.commonchatbots.getcomponentbyid_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class getcomponentbyid_services : GxRestService
 {
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

    [OperationContract(Name = "GetComponentById" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( Guid ChatMessageId ,
                         out string SDComponentLink ,
                         out bool IsCallPanel )
    {
       SDComponentLink = "" ;
       IsCallPanel = false ;
       try
       {
          permissionPrefix = "getcomponentbyid_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("getcomponentbyid") )
          {
             return  ;
          }
          getcomponentbyid worker = new getcomponentbyid(context);
          worker.IsMain = RunAsMain ;
          worker.execute(ChatMessageId,out SDComponentLink,out IsCallPanel );
          worker.cleanup( );
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}
