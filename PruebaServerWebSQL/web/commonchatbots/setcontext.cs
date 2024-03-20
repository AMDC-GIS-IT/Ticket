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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.commonchatbots {
   public class setcontext : GXProcedure
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
            return "setcontext_Services_Execute" ;
         }

      }

      public setcontext( )
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

      public setcontext( IGxContext context )
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

      public void execute( string aP0_Instance ,
                           Guid aP1_UserId ,
                           string aP2_Context )
      {
         this.AV9Instance = aP0_Instance;
         this.AV10UserId = aP1_UserId;
         this.AV8Context = aP2_Context;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_Instance ,
                                 Guid aP1_UserId ,
                                 string aP2_Context )
      {
         setcontext objsetcontext;
         objsetcontext = new setcontext();
         objsetcontext.AV9Instance = aP0_Instance;
         objsetcontext.AV10UserId = aP1_UserId;
         objsetcontext.AV8Context = aP2_Context;
         objsetcontext.context.SetSubmitInitialConfig(context);
         objsetcontext.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsetcontext);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setcontext)stateInfo).executePrivate();
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
         AV14GXLvl1 = 0;
         /* Using cursor P006S2 */
         pr_default.execute(0, new Object[] {AV10UserId, AV9Instance});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A273GXChatMessageInstance = P006S2_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(P006S2_A268GXChatUserId[0]));
            A276GXChatMessageMeta = P006S2_A276GXChatMessageMeta[0];
            A270GXChatMessageDate = P006S2_A270GXChatMessageDate[0];
            A267GXChatMessageId = (Guid)((Guid)(P006S2_A267GXChatMessageId[0]));
            AV14GXLvl1 = 1;
            A276GXChatMessageMeta = AV8Context;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P006S3 */
            pr_default.execute(1, new Object[] {A276GXChatMessageMeta, A267GXChatMessageId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
            if (true) break;
            /* Using cursor P006S4 */
            pr_default.execute(2, new Object[] {A276GXChatMessageMeta, A267GXChatMessageId});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV14GXLvl1 == 0 )
         {
            AV11Cache = CacheAPI.GetCache( AV9Instance);
            AV11Cache.Set(AV10UserId.ToString(), AV8Context, 0);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("commonchatbots.setcontext",pr_default);
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
         scmdbuf = "";
         P006S2_A273GXChatMessageInstance = new string[] {""} ;
         P006S2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         P006S2_A276GXChatMessageMeta = new string[] {""} ;
         P006S2_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         P006S2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         A273GXChatMessageInstance = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         A276GXChatMessageMeta = "";
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         A267GXChatMessageId = (Guid)(Guid.Empty);
         AV11Cache = new CacheAPI();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.setcontext__default(),
            new Object[][] {
                new Object[] {
               P006S2_A273GXChatMessageInstance, P006S2_A268GXChatUserId, P006S2_A276GXChatMessageMeta, P006S2_A270GXChatMessageDate, P006S2_A267GXChatMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14GXLvl1 ;
      private string scmdbuf ;
      private DateTime A270GXChatMessageDate ;
      private string AV8Context ;
      private string A276GXChatMessageMeta ;
      private string AV9Instance ;
      private string A273GXChatMessageInstance ;
      private Guid AV10UserId ;
      private Guid A268GXChatUserId ;
      private Guid A267GXChatMessageId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006S2_A273GXChatMessageInstance ;
      private Guid[] P006S2_A268GXChatUserId ;
      private string[] P006S2_A276GXChatMessageMeta ;
      private DateTime[] P006S2_A270GXChatMessageDate ;
      private Guid[] P006S2_A267GXChatMessageId ;
      private CacheAPI AV11Cache ;
   }

   public class setcontext__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006S2;
          prmP006S2 = new Object[] {
          new ParDef("@AV10UserId",GXType.UniqueIdentifier,4,0) ,
          new ParDef("@AV9Instance",GXType.NVarChar,40,0)
          };
          Object[] prmP006S3;
          prmP006S3 = new Object[] {
          new ParDef("@GXChatMessageMeta",GXType.NVarChar,2097152,0) ,
          new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
          };
          Object[] prmP006S4;
          prmP006S4 = new Object[] {
          new ParDef("@GXChatMessageMeta",GXType.NVarChar,2097152,0) ,
          new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006S2", "SELECT TOP 1 [GXChatMessageInstance], [GXChatUserId], [GXChatMessageMeta], [GXChatMessageDate], [GXChatMessageId] FROM [GXChatMessage] WITH (UPDLOCK) WHERE ([GXChatUserId] = @AV10UserId) AND ([GXChatMessageInstance] = @AV9Instance) ORDER BY [GXChatMessageDate] DESC ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P006S3", "UPDATE [GXChatMessage] SET [GXChatMessageMeta]=@GXChatMessageMeta  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP006S3)
             ,new CursorDef("P006S4", "UPDATE [GXChatMessage] SET [GXChatMessageMeta]=@GXChatMessageMeta  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP006S4)
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.commonchatbots.setcontext_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class setcontext_services : GxRestService
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

    [OperationContract(Name = "SetContext" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string Instance ,
                         Guid UserId ,
                         string Context )
    {
       try
       {
          permissionPrefix = "setcontext_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("setcontext") )
          {
             return  ;
          }
          setcontext worker = new setcontext(context);
          worker.IsMain = RunAsMain ;
          worker.execute(Instance,UserId,Context );
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
