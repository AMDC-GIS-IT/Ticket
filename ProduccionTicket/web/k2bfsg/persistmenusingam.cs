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
namespace GeneXus.Programs.k2bfsg {
   public class persistmenusingam : GXProcedure
   {
      public persistmenusingam( )
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

      public persistmenusingam( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ApplicationId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages ,
                           out bool aP2_Result )
      {
         this.AV8ApplicationId = aP0_ApplicationId;
         this.AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV23Result = false ;
         initialize();
         executePrivate();
         aP1_Messages=this.AV19Messages;
         aP2_Result=this.AV23Result;
      }

      public bool executeUdp( long aP0_ApplicationId ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages )
      {
         execute(aP0_ApplicationId, out aP1_Messages, out aP2_Result);
         return AV23Result ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages ,
                                 out bool aP2_Result )
      {
         persistmenusingam objpersistmenusingam;
         objpersistmenusingam = new persistmenusingam();
         objpersistmenusingam.AV8ApplicationId = aP0_ApplicationId;
         objpersistmenusingam.AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objpersistmenusingam.AV23Result = false ;
         objpersistmenusingam.context.SetSubmitInitialConfig(context);
         objpersistmenusingam.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpersistmenusingam);
         aP1_Messages=this.AV19Messages;
         aP2_Result=this.AV23Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((persistmenusingam)stateInfo).executePrivate();
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
         GXt_objcol_SdtK2BPersistedMenuOutput1 = AV22PersistedMenuOutputCollection;
         new k2blistallmenusinitializations(context ).execute( out  GXt_objcol_SdtK2BPersistedMenuOutput1) ;
         AV22PersistedMenuOutputCollection = GXt_objcol_SdtK2BPersistedMenuOutput1;
         AV23Result = true;
         AV15MenuInserted = 0;
         AV17MenuUpdated = 0;
         AV12MenuFailToInsert = 0;
         AV13MenuFailToUpdate = 0;
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV22PersistedMenuOutputCollection.Count )
         {
            AV21PersistedMenuOutput = ((SdtK2BPersistedMenuOutput)AV22PersistedMenuOutputCollection.Item(AV30GXV1));
            GXt_boolean2 = AV16MenuResult;
            new GeneXus.Programs.k2bfsg.createorupdatemenustructure(context ).execute(  AV8ApplicationId,  AV21PersistedMenuOutput.gxTpr_Menucode,  AV21PersistedMenuOutput.gxTpr_Persistedmenu, out  AV10Errors, out  AV14MenuId, out  AV20NewMenu, out  GXt_boolean2) ;
            AV16MenuResult = GXt_boolean2;
            if ( AV16MenuResult )
            {
               context.CommitDataStores("k2bfsg.persistmenusingam",pr_default);
               if ( AV20NewMenu )
               {
                  AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
                  AV18Message.gxTpr_Description = StringUtil.Format( "Men� %1 creado", AV21PersistedMenuOutput.gxTpr_Menucode, "", "", "", "", "", "", "", "");
                  AV19Messages.Add(AV18Message, 0);
                  AV15MenuInserted = (short)(AV15MenuInserted+1);
               }
               else
               {
                  AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
                  AV18Message.gxTpr_Description = StringUtil.Format( "Men� %1 actualizado", AV21PersistedMenuOutput.gxTpr_Menucode, "", "", "", "", "", "", "", "");
                  AV19Messages.Add(AV18Message, 0);
                  AV17MenuUpdated = (short)(AV17MenuUpdated+1);
               }
            }
            else
            {
               AV23Result = false;
               if ( AV20NewMenu )
               {
                  AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
                  AV18Message.gxTpr_Description = StringUtil.Format( "Men� %1 no pudo ser creado", AV21PersistedMenuOutput.gxTpr_Menucode, "", "", "", "", "", "", "", "");
                  AV19Messages.Add(AV18Message, 0);
                  AV12MenuFailToInsert = (short)(AV12MenuFailToInsert+1);
               }
               else
               {
                  AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
                  AV18Message.gxTpr_Description = StringUtil.Format( "Men� %1 no pudo ser actualizado", AV21PersistedMenuOutput.gxTpr_Menucode, "", "", "", "", "", "", "", "");
                  AV19Messages.Add(AV18Message, 0);
                  AV13MenuFailToUpdate = (short)(AV13MenuFailToUpdate+1);
               }
               /* Execute user subroutine: 'ADDERRORSTOMESSAGE' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               if (true) break;
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         if ( AV23Result )
         {
            AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV18Message.gxTpr_Description = StringUtil.Format( "Ejecutado con �xito. Insertados: %1, Actualizados: %2", StringUtil.LTrimStr( (decimal)(AV15MenuInserted), 4, 0), StringUtil.LTrimStr( (decimal)(AV17MenuUpdated), 4, 0), "", "", "", "", "", "", "");
            AV19Messages.Add(AV18Message, 0);
         }
         else
         {
            AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV18Message.gxTpr_Description = StringUtil.Format( "", StringUtil.LTrimStr( (decimal)(AV15MenuInserted), 4, 0), StringUtil.LTrimStr( (decimal)(AV17MenuUpdated), 4, 0), StringUtil.LTrimStr( (decimal)(AV12MenuFailToInsert), 4, 0), StringUtil.LTrimStr( (decimal)(AV13MenuFailToUpdate), 4, 0), "", "", "", "", "");
            AV19Messages.Add(AV18Message, 0);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDERRORSTOMESSAGE' Routine */
         returnInSub = false;
         AV31GXV2 = 1;
         while ( AV31GXV2 <= AV10Errors.Count )
         {
            AV9Error = ((GeneXus.Utils.SdtMessages_Message)AV10Errors.Item(AV31GXV2));
            AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV18Message.gxTpr_Description = AV9Error.gxTpr_Description;
            AV19Messages.Add(AV18Message, 0);
            AV31GXV2 = (int)(AV31GXV2+1);
         }
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
         AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "kb_ticket");
         GXt_objcol_SdtK2BPersistedMenuOutput1 = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "kb_ticket");
         AV21PersistedMenuOutput = new SdtK2BPersistedMenuOutput(context);
         AV10Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV9Error = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.persistmenusingam__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.persistmenusingam__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.persistmenusingam__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.persistmenusingam__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15MenuInserted ;
      private short AV17MenuUpdated ;
      private short AV12MenuFailToInsert ;
      private short AV13MenuFailToUpdate ;
      private int AV30GXV1 ;
      private int AV31GXV2 ;
      private long AV8ApplicationId ;
      private long AV14MenuId ;
      private bool AV23Result ;
      private bool AV16MenuResult ;
      private bool GXt_boolean2 ;
      private bool AV20NewMenu ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP1_Messages ;
      private bool aP2_Result ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Errors ;
      private GXBaseCollection<SdtK2BPersistedMenuOutput> AV22PersistedMenuOutputCollection ;
      private GXBaseCollection<SdtK2BPersistedMenuOutput> GXt_objcol_SdtK2BPersistedMenuOutput1 ;
      private GeneXus.Utils.SdtMessages_Message AV18Message ;
      private GeneXus.Utils.SdtMessages_Message AV9Error ;
      private SdtK2BPersistedMenuOutput AV21PersistedMenuOutput ;
   }

   public class persistmenusingam__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class persistmenusingam__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class persistmenusingam__gam : DataStoreHelperBase, IDataStoreHelper
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

public class persistmenusingam__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
