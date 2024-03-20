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
   public class getwebcomponentbyid : GXProcedure
   {
      public getwebcomponentbyid( )
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

      public getwebcomponentbyid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ChatMessageId ,
                           out string aP1_WebComponentLink )
      {
         this.AV8ChatMessageId = aP0_ChatMessageId;
         this.AV11WebComponentLink = "" ;
         initialize();
         executePrivate();
         aP1_WebComponentLink=this.AV11WebComponentLink;
      }

      public string executeUdp( Guid aP0_ChatMessageId )
      {
         execute(aP0_ChatMessageId, out aP1_WebComponentLink);
         return AV11WebComponentLink ;
      }

      public void executeSubmit( Guid aP0_ChatMessageId ,
                                 out string aP1_WebComponentLink )
      {
         getwebcomponentbyid objgetwebcomponentbyid;
         objgetwebcomponentbyid = new getwebcomponentbyid();
         objgetwebcomponentbyid.AV8ChatMessageId = aP0_ChatMessageId;
         objgetwebcomponentbyid.AV11WebComponentLink = "" ;
         objgetwebcomponentbyid.context.SetSubmitInitialConfig(context);
         objgetwebcomponentbyid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetwebcomponentbyid);
         aP1_WebComponentLink=this.AV11WebComponentLink;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getwebcomponentbyid)stateInfo).executePrivate();
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
         /* Using cursor P006Q2 */
         pr_default.execute(0, new Object[] {AV8ChatMessageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A267GXChatMessageId = (Guid)((Guid)(P006Q2_A267GXChatMessageId[0]));
            A276GXChatMessageMeta = P006Q2_A276GXChatMessageMeta[0];
            AV9ContextString = A276GXChatMessageMeta;
            AV10AnalyzeResponse.FromJSonString(AV9ContextString, null);
            AV11WebComponentLink = AV10AnalyzeResponse.gxTpr_Context.gxTpr_Gxcomponentweb;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV11WebComponentLink = "";
         scmdbuf = "";
         P006Q2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         P006Q2_A276GXChatMessageMeta = new string[] {""} ;
         A267GXChatMessageId = (Guid)(Guid.Empty);
         A276GXChatMessageMeta = "";
         AV9ContextString = "";
         AV10AnalyzeResponse = new GeneXus.Programs.chatbot.message.SdtAnalyzeResponse(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.getwebcomponentbyid__default(),
            new Object[][] {
                new Object[] {
               P006Q2_A267GXChatMessageId, P006Q2_A276GXChatMessageMeta
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string scmdbuf ;
      private string A276GXChatMessageMeta ;
      private string AV9ContextString ;
      private string AV11WebComponentLink ;
      private Guid AV8ChatMessageId ;
      private Guid A267GXChatMessageId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Q2_A267GXChatMessageId ;
      private string[] P006Q2_A276GXChatMessageMeta ;
      private string aP1_WebComponentLink ;
      private GeneXus.Programs.chatbot.message.SdtAnalyzeResponse AV10AnalyzeResponse ;
   }

   public class getwebcomponentbyid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006Q2;
          prmP006Q2 = new Object[] {
          new ParDef("@AV8ChatMessageId",GXType.UniqueIdentifier,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Q2", "SELECT [GXChatMessageId], [GXChatMessageMeta] FROM [GXChatMessage] WHERE [GXChatMessageId] = @AV8ChatMessageId ORDER BY [GXChatMessageId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q2,1, GxCacheFrequency.OFF ,false,true )
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

}
