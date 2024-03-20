using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.commonchatbots {
   public class sendmessage : GXProcedure
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
            return "sendmessage_Services_Execute" ;
         }

      }

      public sendmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public sendmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Instance ,
                           string aP1_ChatbotPlatform ,
                           string aP2_Message ,
                           string aP3_Image ,
                           string aP4_ClientId )
      {
         this.AV13Instance = aP0_Instance;
         this.AV9ChatbotPlatform = aP1_ChatbotPlatform;
         this.AV14Message = aP2_Message;
         this.AV12Image = aP3_Image;
         this.AV10ClientId = aP4_ClientId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_Instance ,
                                 string aP1_ChatbotPlatform ,
                                 string aP2_Message ,
                                 string aP3_Image ,
                                 string aP4_ClientId )
      {
         sendmessage objsendmessage;
         objsendmessage = new sendmessage();
         objsendmessage.AV13Instance = aP0_Instance;
         objsendmessage.AV9ChatbotPlatform = aP1_ChatbotPlatform;
         objsendmessage.AV14Message = aP2_Message;
         objsendmessage.AV12Image = aP3_Image;
         objsendmessage.AV10ClientId = aP4_ClientId;
         objsendmessage.context.SetSubmitInitialConfig(context);
         objsendmessage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsendmessage);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sendmessage)stateInfo).executePrivate();
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
         GXt_guid1 = (Guid)(AV20UserId);
         GXt_guid2 = (Guid)(GXt_guid1);
         new GeneXus.Programs.commonchatbots.getuserid(context ).execute( out  GXt_guid2) ;
         GXt_guid1 = (Guid)((Guid)(GXt_guid2));
         AV20UserId = (Guid)(GXt_guid1);
         AV16MessageType = "U";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV12Image)) && String.IsNullOrEmpty(StringUtil.RTrim( AV23Image_GXI)) ) )
         {
            AV16MessageType = "UI";
         }
         GXt_char3 = AV18PreviousContext;
         new GeneXus.Programs.commonchatbots.getchatmeta(context ).execute(  AV20UserId,  AV13Instance, out  GXt_char3) ;
         AV18PreviousContext = GXt_char3;
         GXt_char4 = "";
         new GeneXus.Programs.commonchatbots.newmessage(context ).execute(  AV20UserId,  AV16MessageType,  AV14Message,  AV12Image,  AV18PreviousContext, ref  GXt_char4,  AV10ClientId,  AV13Instance) ;
         AV8AnalyzeResponse.FromJSonString(AV18PreviousContext, null);
         AV8AnalyzeResponse.gxTpr_Context.gxTpr_Gxuserid = AV20UserId.ToString();
         new GeneXus.Programs.commonchatbots.notifyclients(context ).execute(  AV20UserId,  AV10ClientId,  "ChatbotMessage",  "",  false) ;
         new GeneXus.Programs.chatbot.message.sendmessage(context ).execute(  AV13Instance,  AV14Message,  AV12Image, ref  AV8AnalyzeResponse, out  AV15Messages) ;
         if ( AV15Messages.Count == 0 )
         {
            AV17Meta = AV8AnalyzeResponse.ToJSonString(false, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8AnalyzeResponse.gxTpr_Context.gxTpr_Gxquery)) )
            {
               AV16MessageType = "Q";
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8AnalyzeResponse.gxTpr_Context.gxTpr_Gxcomponentweb)) )
            {
               AV16MessageType = "RP";
               if ( StringUtil.StrCmp(AV9ChatbotPlatform, "SmartDevices") == 0 )
               {
                  AV19ShowMessage = "Show";
               }
            }
            else
            {
               AV16MessageType = "R";
            }
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV8AnalyzeResponse.gxTpr_Gxresponse.Count )
            {
               AV11GXResponse = ((GeneXus.Programs.chatbot.message.SdtAnalyzeResponse_GXResponseItem)AV8AnalyzeResponse.gxTpr_Gxresponse.Item(AV24GXV1));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11GXResponse.gxTpr_Gxresponseimage)) )
               {
                  AV16MessageType = "RI";
               }
               new GeneXus.Programs.commonchatbots.newmessage(context ).execute(  AV20UserId,  AV16MessageType,  AV11GXResponse.gxTpr_Gxoutput,  AV11GXResponse.gxTpr_Gxresponseimage,  AV17Meta, ref  AV19ShowMessage,  AV10ClientId,  AV13Instance) ;
               new GeneXus.Programs.commonchatbots.notifyclients(context ).execute(  AV20UserId,  AV10ClientId,  "ChatbotMessage",  "",  false) ;
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
         else
         {
            new GeneXus.Programs.commonchatbots.notifyclients(context ).execute(  AV20UserId,  AV10ClientId,  "ChatbotError",  AV15Messages.ToJSonString(false),  false) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV20UserId = (Guid)(Guid.Empty);
         GXt_guid1 = (Guid)(Guid.Empty);
         GXt_guid2 = (Guid)(Guid.Empty);
         AV16MessageType = "";
         AV23Image_GXI = "";
         AV18PreviousContext = "";
         GXt_char3 = "";
         GXt_char4 = "";
         AV8AnalyzeResponse = new GeneXus.Programs.chatbot.message.SdtAnalyzeResponse(context);
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Meta = "";
         AV19ShowMessage = "";
         AV11GXResponse = new GeneXus.Programs.chatbot.message.SdtAnalyzeResponse_GXResponseItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV24GXV1 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string AV18PreviousContext ;
      private string AV17Meta ;
      private string AV13Instance ;
      private string AV9ChatbotPlatform ;
      private string AV14Message ;
      private string AV10ClientId ;
      private string AV16MessageType ;
      private string AV23Image_GXI ;
      private string AV19ShowMessage ;
      private string AV12Image ;
      private Guid AV20UserId ;
      private Guid GXt_guid1 ;
      private Guid GXt_guid2 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private GeneXus.Programs.chatbot.message.SdtAnalyzeResponse AV8AnalyzeResponse ;
      private GeneXus.Programs.chatbot.message.SdtAnalyzeResponse_GXResponseItem AV11GXResponse ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.commonchatbots.sendmessage_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class sendmessage_services : GxRestService
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

      [OperationContract(Name = "SendMessage" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( string Instance ,
                           string ChatbotPlatform ,
                           string Message ,
                           string Image ,
                           string ClientId )
      {
         try
         {
            permissionPrefix = "sendmessage_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("sendmessage") )
            {
               return  ;
            }
            sendmessage worker = new sendmessage(context);
            worker.IsMain = RunAsMain ;
            worker.execute(Instance,ChatbotPlatform,Message,Image,ClientId );
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

      [OperationContract]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Bare  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/gxobject")]
      public void Upload( System.IO.Stream stream )
      {
         try
         {
            permissionPrefix = "sendmessage_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            UploadImpl(stream);
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
