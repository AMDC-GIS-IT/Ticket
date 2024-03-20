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
   public class newmessage : GXProcedure
   {
      public newmessage( )
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

      public newmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_User ,
                           string aP1_Type ,
                           string aP2_Message ,
                           string aP3_Image ,
                           string aP4_Meta ,
                           ref string aP5_Repeat ,
                           string aP6_ClientId ,
                           string aP7_Instance )
      {
         this.AV19User = aP0_User;
         this.AV18Type = aP1_Type;
         this.AV14Message = aP2_Message;
         this.AV12Image = aP3_Image;
         this.AV16Meta = aP4_Meta;
         this.AV17Repeat = aP5_Repeat;
         this.AV11ClientId = aP6_ClientId;
         this.AV13Instance = aP7_Instance;
         initialize();
         executePrivate();
         aP5_Repeat=this.AV17Repeat;
      }

      public void executeSubmit( Guid aP0_User ,
                                 string aP1_Type ,
                                 string aP2_Message ,
                                 string aP3_Image ,
                                 string aP4_Meta ,
                                 ref string aP5_Repeat ,
                                 string aP6_ClientId ,
                                 string aP7_Instance )
      {
         newmessage objnewmessage;
         objnewmessage = new newmessage();
         objnewmessage.AV19User = aP0_User;
         objnewmessage.AV18Type = aP1_Type;
         objnewmessage.AV14Message = aP2_Message;
         objnewmessage.AV12Image = aP3_Image;
         objnewmessage.AV16Meta = aP4_Meta;
         objnewmessage.AV17Repeat = aP5_Repeat;
         objnewmessage.AV11ClientId = aP6_ClientId;
         objnewmessage.AV13Instance = aP7_Instance;
         objnewmessage.context.SetSubmitInitialConfig(context);
         objnewmessage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnewmessage);
         aP5_Repeat=this.AV17Repeat;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((newmessage)stateInfo).executePrivate();
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
         AV9Add = true;
         /* Using cursor P006O2 */
         pr_default.execute(0, new Object[] {AV19User, AV11ClientId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A269GXChatUserDevice = P006O2_A269GXChatUserDevice[0];
            A268GXChatUserId = (Guid)((Guid)(P006O2_A268GXChatUserId[0]));
            AV9Add = false;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV9Add )
         {
            AV8ChatUser.gxTpr_Gxchatuserid = (Guid)(AV19User);
            AV8ChatUser.gxTpr_Gxchatuserdevice = AV11ClientId;
            AV8ChatUser.Save();
            context.CommitDataStores("commonchatbots.newmessage",pr_default);
         }
         AV10ChatMessage.gxTpr_Gxchatmessageid = (Guid)(Guid.NewGuid( ));
         AV10ChatMessage.gxTpr_Gxchatuserid = (Guid)(AV19User);
         AV10ChatMessage.gxTpr_Gxchatmessagemessage = AV14Message;
         AV10ChatMessage.gxTpr_Gxchatmessagetype = AV18Type;
         AV15MessageDateTime = DateTimeUtil.NowMS( context);
         AV10ChatMessage.gxTpr_Gxchatmessagedate = AV15MessageDateTime;
         AV10ChatMessage.gxTpr_Gxchatmessageimage = AV12Image;
         AV10ChatMessage.gxTpr_Gxchatmessageimage_gxi = AV23Image_GXI;
         AV10ChatMessage.gxTpr_Gxchatmessagemeta = AV16Meta;
         AV10ChatMessage.gxTpr_Gxchatmessagerepeat = AV17Repeat;
         AV10ChatMessage.gxTpr_Gxchatuserdevice = AV11ClientId;
         AV10ChatMessage.gxTpr_Gxchatmessageinstance = AV13Instance;
         AV10ChatMessage.Save();
         context.CommitDataStores("commonchatbots.newmessage",pr_default);
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
         scmdbuf = "";
         P006O2_A269GXChatUserDevice = new string[] {""} ;
         P006O2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         A269GXChatUserDevice = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         AV8ChatUser = new GeneXus.Programs.commonchatbots.SdtGXChatUser(context);
         AV10ChatMessage = new GeneXus.Programs.commonchatbots.SdtGXChatMessage(context);
         AV15MessageDateTime = (DateTime)(DateTime.MinValue);
         AV23Image_GXI = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.newmessage__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.newmessage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.newmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.newmessage__default(),
            new Object[][] {
                new Object[] {
               P006O2_A269GXChatUserDevice, P006O2_A268GXChatUserId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV18Type ;
      private string scmdbuf ;
      private DateTime AV15MessageDateTime ;
      private bool AV9Add ;
      private string AV14Message ;
      private string AV16Meta ;
      private string AV17Repeat ;
      private string AV11ClientId ;
      private string AV13Instance ;
      private string A269GXChatUserDevice ;
      private string AV23Image_GXI ;
      private string AV12Image ;
      private Guid AV19User ;
      private Guid A268GXChatUserId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP5_Repeat ;
      private IDataStoreProvider pr_default ;
      private string[] P006O2_A269GXChatUserDevice ;
      private Guid[] P006O2_A268GXChatUserId ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.commonchatbots.SdtGXChatUser AV8ChatUser ;
      private GeneXus.Programs.commonchatbots.SdtGXChatMessage AV10ChatMessage ;
   }

   public class newmessage__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class newmessage__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class newmessage__gam : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

 public override string getDataStoreName( )
 {
    return "GAM";
 }

}

public class newmessage__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP006O2;
       prmP006O2 = new Object[] {
       new ParDef("@AV19User",GXType.UniqueIdentifier,128,0) ,
       new ParDef("@AV11ClientId",GXType.NVarChar,258,0)
       };
       def= new CursorDef[] {
           new CursorDef("P006O2", "SELECT [GXChatUserDevice], [GXChatUserId] FROM [GXChatUser] WHERE [GXChatUserId] = @AV19User and [GXChatUserDevice] = @AV11ClientId ORDER BY [GXChatUserId], [GXChatUserDevice] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006O2,1, GxCacheFrequency.OFF ,false,true )
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
