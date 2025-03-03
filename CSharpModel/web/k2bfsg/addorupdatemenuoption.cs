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
   public class addorupdatemenuoption : GXProcedure
   {
      public addorupdatemenuoption( )
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

      public addorupdatemenuoption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ApplicationId ,
                           GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP1_ApplicationMenu ,
                           GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP2_ApplicationMenuOption ,
                           SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem aP3_MenuSDTItem ,
                           string aP4_MenuType ,
                           long aP5_SubMenuId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Errors ,
                           out bool aP7_Result )
      {
         this.AV8ApplicationId = aP0_ApplicationId;
         this.AV9ApplicationMenu = aP1_ApplicationMenu;
         this.AV10ApplicationMenuOption = aP2_ApplicationMenuOption;
         this.AV14MenuSDTItem = aP3_MenuSDTItem;
         this.AV15MenuType = aP4_MenuType;
         this.AV17SubMenuId = aP5_SubMenuId;
         this.AV11Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV16Result = false ;
         initialize();
         executePrivate();
         aP6_Errors=this.AV11Errors;
         aP7_Result=this.AV16Result;
      }

      public bool executeUdp( long aP0_ApplicationId ,
                              GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP1_ApplicationMenu ,
                              GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP2_ApplicationMenuOption ,
                              SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem aP3_MenuSDTItem ,
                              string aP4_MenuType ,
                              long aP5_SubMenuId ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Errors )
      {
         execute(aP0_ApplicationId, aP1_ApplicationMenu, aP2_ApplicationMenuOption, aP3_MenuSDTItem, aP4_MenuType, aP5_SubMenuId, out aP6_Errors, out aP7_Result);
         return AV16Result ;
      }

      public void executeSubmit( long aP0_ApplicationId ,
                                 GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu aP1_ApplicationMenu ,
                                 GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption aP2_ApplicationMenuOption ,
                                 SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem aP3_MenuSDTItem ,
                                 string aP4_MenuType ,
                                 long aP5_SubMenuId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Errors ,
                                 out bool aP7_Result )
      {
         addorupdatemenuoption objaddorupdatemenuoption;
         objaddorupdatemenuoption = new addorupdatemenuoption();
         objaddorupdatemenuoption.AV8ApplicationId = aP0_ApplicationId;
         objaddorupdatemenuoption.AV9ApplicationMenu = aP1_ApplicationMenu;
         objaddorupdatemenuoption.AV10ApplicationMenuOption = aP2_ApplicationMenuOption;
         objaddorupdatemenuoption.AV14MenuSDTItem = aP3_MenuSDTItem;
         objaddorupdatemenuoption.AV15MenuType = aP4_MenuType;
         objaddorupdatemenuoption.AV17SubMenuId = aP5_SubMenuId;
         objaddorupdatemenuoption.AV11Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objaddorupdatemenuoption.AV16Result = false ;
         objaddorupdatemenuoption.context.SetSubmitInitialConfig(context);
         objaddorupdatemenuoption.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaddorupdatemenuoption);
         aP6_Errors=this.AV11Errors;
         aP7_Result=this.AV16Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((addorupdatemenuoption)stateInfo).executePrivate();
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
         if ( (0==AV10ApplicationMenuOption.gxTpr_Id) )
         {
            AV10ApplicationMenuOption.gxTpr_Name = AV14MenuSDTItem.gxTpr_Code;
            AV10ApplicationMenuOption.gxTpr_Type = AV15MenuType;
            if ( StringUtil.StrCmp(AV15MenuType, "M") == 0 )
            {
               AV10ApplicationMenuOption.gxTpr_Submenuid = AV17SubMenuId;
            }
            /* Execute user subroutine: 'LOAD_APPLICATIONMENUOPTION' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV13IsOK = AV9ApplicationMenu.addmenuoption(AV8ApplicationId, AV10ApplicationMenuOption, out  AV12GAMErrors);
            if ( ! AV13IsOK )
            {
               GXt_objcol_SdtMessages_Message1 = AV11Errors;
               new GeneXus.Programs.k2bfsg.convertgammessagestomessages(context ).execute(  AV12GAMErrors, out  GXt_objcol_SdtMessages_Message1) ;
               AV11Errors = GXt_objcol_SdtMessages_Message1;
               AV16Result = false;
               this.cleanup();
               if (true) return;
            }
            else
            {
               AV16Result = true;
               context.CommitDataStores("k2bfsg.addorupdatemenuoption",pr_default);
            }
         }
         else
         {
            /* Execute user subroutine: 'LOAD_APPLICATIONMENUOPTION' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV10ApplicationMenuOption.gxTpr_Type = AV15MenuType;
            if ( StringUtil.StrCmp(AV15MenuType, "M") == 0 )
            {
               AV10ApplicationMenuOption.gxTpr_Submenuid = AV17SubMenuId;
            }
            AV13IsOK = AV9ApplicationMenu.updatemenuoption(AV8ApplicationId, AV10ApplicationMenuOption, out  AV12GAMErrors);
            if ( ! AV13IsOK )
            {
               GXt_objcol_SdtMessages_Message1 = AV11Errors;
               new GeneXus.Programs.k2bfsg.convertgammessagestomessages(context ).execute(  AV12GAMErrors, out  GXt_objcol_SdtMessages_Message1) ;
               AV11Errors = GXt_objcol_SdtMessages_Message1;
               AV16Result = false;
               this.cleanup();
               if (true) return;
            }
            else
            {
               AV16Result = true;
               context.CommitDataStores("k2bfsg.addorupdatemenuoption",pr_default);
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOAD_APPLICATIONMENUOPTION' Routine */
         returnInSub = false;
         AV10ApplicationMenuOption.gxTpr_Description = AV14MenuSDTItem.gxTpr_Title;
         new GeneXus.Programs.k2bfsg.setextendedmenuoptionsvalues(context ).execute( ref  AV10ApplicationMenuOption,  AV14MenuSDTItem.gxTpr_Imageurl,  AV14MenuSDTItem.gxTpr_Imageclass,  AV14MenuSDTItem.gxTpr_Showinextrasmall,  AV14MenuSDTItem.gxTpr_Showinsmall,  AV14MenuSDTItem.gxTpr_Showinmedium,  AV14MenuSDTItem.gxTpr_Showinlarge) ;
         if ( StringUtil.StrCmp(AV15MenuType, "S") == 0 )
         {
            GXt_char2 = "";
            new GeneXus.Programs.k2bfsg.addandgetpermissionresource(context ).execute(  AV14MenuSDTItem.gxTpr_Activity,  AV8ApplicationId, out  GXt_char2) ;
            AV10ApplicationMenuOption.gxTpr_Permissionresourceguid = GXt_char2;
         }
         AV10ApplicationMenuOption.gxTpr_Resource = AV14MenuSDTItem.gxTpr_Gxobject;
         AV10ApplicationMenuOption.gxTpr_Permissionresourceparameters = AV14MenuSDTItem.gxTpr_Gxobjectparameters;
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
         AV11Errors = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_char2 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addorupdatemenuoption__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addorupdatemenuoption__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addorupdatemenuoption__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addorupdatemenuoption__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV8ApplicationId ;
      private long AV17SubMenuId ;
      private string AV15MenuType ;
      private string GXt_char2 ;
      private bool AV16Result ;
      private bool returnInSub ;
      private bool AV13IsOK ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Errors ;
      private bool aP7_Result ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV9ApplicationMenu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV10ApplicationMenuOption ;
      private SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem AV14MenuSDTItem ;
   }

   public class addorupdatemenuoption__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class addorupdatemenuoption__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class addorupdatemenuoption__gam : DataStoreHelperBase, IDataStoreHelper
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

public class addorupdatemenuoption__default : DataStoreHelperBase, IDataStoreHelper
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
