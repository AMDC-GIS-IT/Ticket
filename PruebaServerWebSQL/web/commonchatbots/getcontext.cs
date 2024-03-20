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
   public class getcontext : GXProcedure
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
            return "getcontext_Services_Execute" ;
         }

      }

      public getcontext( )
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

      public getcontext( IGxContext context )
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
                           out string aP2_Context )
      {
         this.AV9Instance = aP0_Instance;
         this.AV11UserId = aP1_UserId;
         this.AV8Context = "" ;
         initialize();
         executePrivate();
         aP2_Context=this.AV8Context;
      }

      public string executeUdp( string aP0_Instance ,
                                Guid aP1_UserId )
      {
         execute(aP0_Instance, aP1_UserId, out aP2_Context);
         return AV8Context ;
      }

      public void executeSubmit( string aP0_Instance ,
                                 Guid aP1_UserId ,
                                 out string aP2_Context )
      {
         getcontext objgetcontext;
         objgetcontext = new getcontext();
         objgetcontext.AV9Instance = aP0_Instance;
         objgetcontext.AV11UserId = aP1_UserId;
         objgetcontext.AV8Context = "" ;
         objgetcontext.context.SetSubmitInitialConfig(context);
         objgetcontext.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetcontext);
         aP2_Context=this.AV8Context;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getcontext)stateInfo).executePrivate();
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
         AV15GXLvl1 = 0;
         /* Using cursor P006R2 */
         pr_default.execute(0, new Object[] {AV11UserId, AV9Instance});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A273GXChatMessageInstance = P006R2_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(P006R2_A268GXChatUserId[0]));
            A276GXChatMessageMeta = P006R2_A276GXChatMessageMeta[0];
            A270GXChatMessageDate = P006R2_A270GXChatMessageDate[0];
            A267GXChatMessageId = (Guid)((Guid)(P006R2_A267GXChatMessageId[0]));
            AV15GXLvl1 = 1;
            AV8Context = A276GXChatMessageMeta;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl1 == 0 )
         {
            AV12Cache = CacheAPI.GetCache( AV9Instance);
            if ( AV12Cache.Contains(AV11UserId.ToString()) )
            {
               AV8Context = AV12Cache.Get(AV11UserId.ToString());
            }
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
         AV8Context = "";
         scmdbuf = "";
         P006R2_A273GXChatMessageInstance = new string[] {""} ;
         P006R2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         P006R2_A276GXChatMessageMeta = new string[] {""} ;
         P006R2_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         P006R2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         A273GXChatMessageInstance = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         A276GXChatMessageMeta = "";
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         A267GXChatMessageId = (Guid)(Guid.Empty);
         AV12Cache = new CacheAPI();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.getcontext__default(),
            new Object[][] {
                new Object[] {
               P006R2_A273GXChatMessageInstance, P006R2_A268GXChatUserId, P006R2_A276GXChatMessageMeta, P006R2_A270GXChatMessageDate, P006R2_A267GXChatMessageId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15GXLvl1 ;
      private string scmdbuf ;
      private DateTime A270GXChatMessageDate ;
      private string AV8Context ;
      private string A276GXChatMessageMeta ;
      private string AV9Instance ;
      private string A273GXChatMessageInstance ;
      private Guid AV11UserId ;
      private Guid A268GXChatUserId ;
      private Guid A267GXChatMessageId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006R2_A273GXChatMessageInstance ;
      private Guid[] P006R2_A268GXChatUserId ;
      private string[] P006R2_A276GXChatMessageMeta ;
      private DateTime[] P006R2_A270GXChatMessageDate ;
      private Guid[] P006R2_A267GXChatMessageId ;
      private string aP2_Context ;
      private CacheAPI AV12Cache ;
   }

   public class getcontext__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006R2;
          prmP006R2 = new Object[] {
          new ParDef("@AV11UserId",GXType.UniqueIdentifier,4,0) ,
          new ParDef("@AV9Instance",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006R2", "SELECT TOP 1 [GXChatMessageInstance], [GXChatUserId], [GXChatMessageMeta], [GXChatMessageDate], [GXChatMessageId] FROM [GXChatMessage] WHERE ([GXChatUserId] = @AV11UserId) AND ([GXChatMessageInstance] = @AV9Instance) ORDER BY [GXChatMessageDate] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R2,1, GxCacheFrequency.OFF ,false,true )
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

 [ServiceContract(Namespace = "GeneXus.Programs.commonchatbots.getcontext_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class getcontext_services : GxRestService
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

    [OperationContract(Name = "GetContext" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string Instance ,
                         Guid UserId ,
                         out string Context )
    {
       Context = "" ;
       try
       {
          permissionPrefix = "getcontext_Services_Execute";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("getcontext") )
          {
             return  ;
          }
          getcontext worker = new getcontext(context);
          worker.IsMain = RunAsMain ;
          worker.execute(Instance,UserId,out Context );
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
