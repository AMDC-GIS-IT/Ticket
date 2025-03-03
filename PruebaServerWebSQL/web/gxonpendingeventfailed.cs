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
namespace GeneXus.Programs {
   public class gxonpendingeventfailed : GXProcedure
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
            return "gxonpendingeventfailed_Services_Execute" ;
         }

      }

      public gxonpendingeventfailed( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gxonpendingeventfailed( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem aP0_PendingEvent ,
                           string aP1_BCName ,
                           string aP2_BCJson ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem aP3_EventResult ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP4_GxSyncroInfo ,
                           out bool aP5_Continue )
      {
         this.AV8PendingEvent = aP0_PendingEvent;
         this.AV9BCName = aP1_BCName;
         this.AV10BCJson = aP2_BCJson;
         this.AV12EventResult = aP3_EventResult;
         this.GxSyncroInfo = aP4_GxSyncroInfo;
         this.AV11Continue = false ;
         initialize();
         executePrivate();
         aP5_Continue=this.AV11Continue;
      }

      public bool executeUdp( GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem aP0_PendingEvent ,
                              string aP1_BCName ,
                              string aP2_BCJson ,
                              GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem aP3_EventResult ,
                              GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP4_GxSyncroInfo )
      {
         execute(aP0_PendingEvent, aP1_BCName, aP2_BCJson, aP3_EventResult, aP4_GxSyncroInfo, out aP5_Continue);
         return AV11Continue ;
      }

      public void executeSubmit( GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem aP0_PendingEvent ,
                                 string aP1_BCName ,
                                 string aP2_BCJson ,
                                 GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem aP3_EventResult ,
                                 GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP4_GxSyncroInfo ,
                                 out bool aP5_Continue )
      {
         gxonpendingeventfailed objgxonpendingeventfailed;
         objgxonpendingeventfailed = new gxonpendingeventfailed();
         objgxonpendingeventfailed.AV8PendingEvent = aP0_PendingEvent;
         objgxonpendingeventfailed.AV9BCName = aP1_BCName;
         objgxonpendingeventfailed.AV10BCJson = aP2_BCJson;
         objgxonpendingeventfailed.AV12EventResult = aP3_EventResult;
         objgxonpendingeventfailed.GxSyncroInfo = aP4_GxSyncroInfo;
         objgxonpendingeventfailed.AV11Continue = false ;
         objgxonpendingeventfailed.context.SetSubmitInitialConfig(context);
         objgxonpendingeventfailed.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgxonpendingeventfailed);
         aP5_Continue=this.AV11Continue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxonpendingeventfailed)stateInfo).executePrivate();
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
         AV11Continue = true;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV11Continue ;
      private string AV10BCJson ;
      private string AV9BCName ;
      private bool aP5_Continue ;
      private GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem AV8PendingEvent ;
      private GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem AV12EventResult ;
      private GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo GxSyncroInfo ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gxonpendingeventfailed_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gxonpendingeventfailed_services : GxRestService
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

      [OperationContract(Name = "GxOnPendingEventFailed" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem_RESTInterface PendingEvent ,
                           string BCName ,
                           string BCJson ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem_RESTInterface EventResult ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo_RESTInterface GxSyncroInfo ,
                           out bool Continue )
      {
         Continue = false ;
         try
         {
            permissionPrefix = "gxonpendingeventfailed_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("gxonpendingeventfailed") )
            {
               return  ;
            }
            gxonpendingeventfailed worker = new gxonpendingeventfailed(context);
            worker.IsMain = RunAsMain ;
            GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem gxrPendingEvent = PendingEvent.sdt;
            GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem gxrEventResult = EventResult.sdt;
            GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo gxrGxSyncroInfo = GxSyncroInfo.sdt;
            worker.execute(gxrPendingEvent,BCName,BCJson,gxrEventResult,gxrGxSyncroInfo,out Continue );
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
