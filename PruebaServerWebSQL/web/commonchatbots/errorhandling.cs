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
   public class errorhandling : GXProcedure
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
            return "errorhandling_Services_Execute" ;
         }

      }

      public errorhandling( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public errorhandling( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref GXBaseCollection<SdtMessages_Message> aP0_Messages ,
                           out bool aP1_ShowErrorsInUI )
      {
         this.AV8Messages = aP0_Messages;
         this.AV9ShowErrorsInUI = false ;
         initialize();
         executePrivate();
         aP0_Messages=this.AV8Messages;
         aP1_ShowErrorsInUI=this.AV9ShowErrorsInUI;
      }

      public bool executeUdp( ref GXBaseCollection<SdtMessages_Message> aP0_Messages )
      {
         execute(ref aP0_Messages, out aP1_ShowErrorsInUI);
         return AV9ShowErrorsInUI ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtMessages_Message> aP0_Messages ,
                                 out bool aP1_ShowErrorsInUI )
      {
         errorhandling objerrorhandling;
         objerrorhandling = new errorhandling();
         objerrorhandling.AV8Messages = aP0_Messages;
         objerrorhandling.AV9ShowErrorsInUI = false ;
         objerrorhandling.context.SetSubmitInitialConfig(context);
         objerrorhandling.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objerrorhandling);
         aP0_Messages=this.AV8Messages;
         aP1_ShowErrorsInUI=this.AV9ShowErrorsInUI;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((errorhandling)stateInfo).executePrivate();
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
         AV9ShowErrorsInUI = true;
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

      private bool AV9ShowErrorsInUI ;
      private GXBaseCollection<SdtMessages_Message> aP0_Messages ;
      private bool aP1_ShowErrorsInUI ;
      private GXBaseCollection<SdtMessages_Message> AV8Messages ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.commonchatbots.errorhandling_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class errorhandling_services : GxRestService
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

      [OperationContract(Name = "ErrorHandling" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( ref GxGenericCollection<SdtMessages_Message_RESTInterface> Messages ,
                           out bool ShowErrorsInUI )
      {
         ShowErrorsInUI = false ;
         try
         {
            permissionPrefix = "errorhandling_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("errorhandling") )
            {
               return  ;
            }
            errorhandling worker = new errorhandling(context);
            worker.IsMain = RunAsMain ;
            GXBaseCollection<SdtMessages_Message> gxrMessages = new GXBaseCollection<SdtMessages_Message>();
            Messages.LoadCollection(gxrMessages);
            worker.execute(ref gxrMessages,out ShowErrorsInUI );
            worker.cleanup( );
            Messages = new GxGenericCollection<SdtMessages_Message_RESTInterface>(gxrMessages) ;
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
