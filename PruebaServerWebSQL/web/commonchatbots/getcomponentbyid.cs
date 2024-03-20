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
   public class getcomponentbyid : GXProcedure
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

      public void release( )
      {
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
         AV15SDComponentLink = "";
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

      private string scmdbuf ;
      private bool AV13IsCallPanel ;
      private string A276GXChatMessageMeta ;
      private string AV14Meta ;
      private string AV15SDComponentLink ;
      private string AV10GXCallPanelSD ;
      private string AV12GXComponentSD ;
      private Guid AV8ChatMessageId ;
      private Guid A267GXChatMessageId ;
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
