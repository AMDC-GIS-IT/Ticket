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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.commonchatbots {
   public class notifyclients : GXProcedure
   {
      public notifyclients( )
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

      public notifyclients( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_UserId ,
                           string aP1_SourceClient ,
                           string aP2_ChatbotNotificationType ,
                           string aP3_NotificationMessage ,
                           bool aP4_IsFromClient )
      {
         this.AV8UserId = aP0_UserId;
         this.AV13SourceClient = aP1_SourceClient;
         this.AV9ChatbotNotificationType = aP2_ChatbotNotificationType;
         this.AV10NotificationMessage = aP3_NotificationMessage;
         this.AV14IsFromClient = aP4_IsFromClient;
         initialize();
         executePrivate();
      }

      public void executeSubmit( Guid aP0_UserId ,
                                 string aP1_SourceClient ,
                                 string aP2_ChatbotNotificationType ,
                                 string aP3_NotificationMessage ,
                                 bool aP4_IsFromClient )
      {
         notifyclients objnotifyclients;
         objnotifyclients = new notifyclients();
         objnotifyclients.AV8UserId = aP0_UserId;
         objnotifyclients.AV13SourceClient = aP1_SourceClient;
         objnotifyclients.AV9ChatbotNotificationType = aP2_ChatbotNotificationType;
         objnotifyclients.AV10NotificationMessage = aP3_NotificationMessage;
         objnotifyclients.AV14IsFromClient = aP4_IsFromClient;
         objnotifyclients.context.SetSubmitInitialConfig(context);
         objnotifyclients.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnotifyclients);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notifyclients)stateInfo).executePrivate();
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
         AV11NotificationInfo.gxTpr_Id = AV9ChatbotNotificationType;
         AV11NotificationInfo.gxTpr_Message = AV10NotificationMessage;
         /* Using cursor P006V2 */
         pr_default.execute(0, new Object[] {AV8UserId, AV14IsFromClient, AV13SourceClient});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A269GXChatUserDevice = P006V2_A269GXChatUserDevice[0];
            A268GXChatUserId = (Guid)((Guid)(P006V2_A268GXChatUserId[0]));
            AV12Socket.notifyclient( A269GXChatUserDevice,  AV11NotificationInfo);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV11NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         scmdbuf = "";
         P006V2_A269GXChatUserDevice = new string[] {""} ;
         P006V2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         A269GXChatUserDevice = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         AV12Socket = new GeneXus.Core.genexus.server.SdtSocket(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.notifyclients__default(),
            new Object[][] {
                new Object[] {
               P006V2_A269GXChatUserDevice, P006V2_A268GXChatUserId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string scmdbuf ;
      private bool AV14IsFromClient ;
      private string AV10NotificationMessage ;
      private string AV13SourceClient ;
      private string AV9ChatbotNotificationType ;
      private string A269GXChatUserDevice ;
      private Guid AV8UserId ;
      private Guid A268GXChatUserId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006V2_A269GXChatUserDevice ;
      private Guid[] P006V2_A268GXChatUserId ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV11NotificationInfo ;
      private GeneXus.Core.genexus.server.SdtSocket AV12Socket ;
   }

   public class notifyclients__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006V2;
          prmP006V2 = new Object[] {
          new ParDef("@AV8UserId",GXType.UniqueIdentifier,4,0) ,
          new ParDef("@AV14IsFromClient",GXType.Boolean,4,0) ,
          new ParDef("@AV13SourceClient",GXType.NVarChar,256,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006V2", "SELECT [GXChatUserDevice], [GXChatUserId] FROM [GXChatUser] WHERE ([GXChatUserId] = @AV8UserId) AND (Not ( @AV14IsFromClient = 1 and [GXChatUserDevice] = @AV13SourceClient)) ORDER BY [GXChatUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
