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
   public class getchatmeta : GXProcedure
   {
      public getchatmeta( )
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

      public getchatmeta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Id ,
                           string aP1_Instance ,
                           out string aP2_Meta )
      {
         this.AV11Id = aP0_Id;
         this.AV12Instance = aP1_Instance;
         this.AV13Meta = "" ;
         initialize();
         executePrivate();
         aP2_Meta=this.AV13Meta;
      }

      public string executeUdp( Guid aP0_Id ,
                                string aP1_Instance )
      {
         execute(aP0_Id, aP1_Instance, out aP2_Meta);
         return AV13Meta ;
      }

      public void executeSubmit( Guid aP0_Id ,
                                 string aP1_Instance ,
                                 out string aP2_Meta )
      {
         getchatmeta objgetchatmeta;
         objgetchatmeta = new getchatmeta();
         objgetchatmeta.AV11Id = aP0_Id;
         objgetchatmeta.AV12Instance = aP1_Instance;
         objgetchatmeta.AV13Meta = "" ;
         objgetchatmeta.context.SetSubmitInitialConfig(context);
         objgetchatmeta.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetchatmeta);
         aP2_Meta=this.AV13Meta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getchatmeta)stateInfo).executePrivate();
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
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {AV11Id, AV12Instance});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A273GXChatMessageInstance = P006N2_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(P006N2_A268GXChatUserId[0]));
            A276GXChatMessageMeta = P006N2_A276GXChatMessageMeta[0];
            A270GXChatMessageDate = P006N2_A270GXChatMessageDate[0];
            A267GXChatMessageId = (Guid)((Guid)(P006N2_A267GXChatMessageId[0]));
            AV13Meta = A276GXChatMessageMeta;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Meta)) )
         {
            AV10ContextProperties.FromJSonString(AV13Meta, null);
            AV8Action = AV10ContextProperties.Get("GXAction");
            AV9Clean = AV10ContextProperties.Get("GXClean");
            if ( ( StringUtil.StrCmp(AV8Action, "NoAction") == 0 ) || ( StringUtil.StrCmp(AV9Clean, "True") == 0 ) )
            {
               AV13Meta = "";
            }
         }
         else
         {
            AV13Meta = "{}";
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
         AV13Meta = "";
         scmdbuf = "";
         P006N2_A273GXChatMessageInstance = new string[] {""} ;
         P006N2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         P006N2_A276GXChatMessageMeta = new string[] {""} ;
         P006N2_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         P006N2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         A273GXChatMessageInstance = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         A276GXChatMessageMeta = "";
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         A267GXChatMessageId = (Guid)(Guid.Empty);
         AV10ContextProperties = new GXProperties();
         AV8Action = "";
         AV9Clean = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.getchatmeta__default(),
            new Object[][] {
                new Object[] {
               P006N2_A273GXChatMessageInstance, P006N2_A268GXChatUserId, P006N2_A276GXChatMessageMeta, P006N2_A270GXChatMessageDate, P006N2_A267GXChatMessageId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string scmdbuf ;
      private DateTime A270GXChatMessageDate ;
      private string AV13Meta ;
      private string A276GXChatMessageMeta ;
      private string AV12Instance ;
      private string A273GXChatMessageInstance ;
      private string AV8Action ;
      private string AV9Clean ;
      private Guid AV11Id ;
      private Guid A268GXChatUserId ;
      private Guid A267GXChatMessageId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006N2_A273GXChatMessageInstance ;
      private Guid[] P006N2_A268GXChatUserId ;
      private string[] P006N2_A276GXChatMessageMeta ;
      private DateTime[] P006N2_A270GXChatMessageDate ;
      private Guid[] P006N2_A267GXChatMessageId ;
      private string aP2_Meta ;
      private GXProperties AV10ContextProperties ;
   }

   public class getchatmeta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("@AV11Id",GXType.UniqueIdentifier,256,0) ,
          new ParDef("@AV12Instance",GXType.NVarChar,256,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "SELECT TOP 1 [GXChatMessageInstance], [GXChatUserId], [GXChatMessageMeta], [GXChatMessageDate], [GXChatMessageId] FROM [GXChatMessage] WHERE ([GXChatUserId] = @AV11Id) AND ([GXChatMessageInstance] = @AV12Instance) ORDER BY [GXChatMessageDate] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,1, GxCacheFrequency.OFF ,false,true )
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

}
