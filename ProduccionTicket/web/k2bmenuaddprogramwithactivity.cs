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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bmenuaddprogramwithactivity : GXProcedure
   {
      public k2bmenuaddprogramwithactivity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bmenuaddprogramwithactivity( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Code ,
                           string aP1_Title ,
                           string aP2_GXObject ,
                           string aP3_GXObjectParameters ,
                           string aP4_ImageUrl ,
                           string aP5_ImageClass ,
                           SdtK2BActivity aP6_Activity ,
                           bool aP7_ShowInExtraSmall ,
                           bool aP8_ShowInSmall ,
                           bool aP9_ShowInMedium ,
                           ref bool aP10_ShowInLarge ,
                           ref GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP11_CurrentMenu )
      {
         this.AV9Code = aP0_Code;
         this.AV21Title = aP1_Title;
         this.AV12GXObject = aP2_GXObject;
         this.AV13GXObjectParameters = aP3_GXObjectParameters;
         this.AV15ImageUrl = aP4_ImageUrl;
         this.AV14ImageClass = aP5_ImageClass;
         this.AV8Activity = aP6_Activity;
         this.AV17ShowInExtraSmall = aP7_ShowInExtraSmall;
         this.AV20ShowInSmall = aP8_ShowInSmall;
         this.AV19ShowInMedium = aP9_ShowInMedium;
         this.AV18ShowInLarge = aP10_ShowInLarge;
         this.AV10CurrentMenu = aP11_CurrentMenu;
         initialize();
         executePrivate();
         aP10_ShowInLarge=this.AV18ShowInLarge;
         aP11_CurrentMenu=this.AV10CurrentMenu;
      }

      public GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> executeUdp( string aP0_Code ,
                                                                                                        string aP1_Title ,
                                                                                                        string aP2_GXObject ,
                                                                                                        string aP3_GXObjectParameters ,
                                                                                                        string aP4_ImageUrl ,
                                                                                                        string aP5_ImageClass ,
                                                                                                        SdtK2BActivity aP6_Activity ,
                                                                                                        bool aP7_ShowInExtraSmall ,
                                                                                                        bool aP8_ShowInSmall ,
                                                                                                        bool aP9_ShowInMedium ,
                                                                                                        ref bool aP10_ShowInLarge )
      {
         execute(aP0_Code, aP1_Title, aP2_GXObject, aP3_GXObjectParameters, aP4_ImageUrl, aP5_ImageClass, aP6_Activity, aP7_ShowInExtraSmall, aP8_ShowInSmall, aP9_ShowInMedium, ref aP10_ShowInLarge, ref aP11_CurrentMenu);
         return AV10CurrentMenu ;
      }

      public void executeSubmit( string aP0_Code ,
                                 string aP1_Title ,
                                 string aP2_GXObject ,
                                 string aP3_GXObjectParameters ,
                                 string aP4_ImageUrl ,
                                 string aP5_ImageClass ,
                                 SdtK2BActivity aP6_Activity ,
                                 bool aP7_ShowInExtraSmall ,
                                 bool aP8_ShowInSmall ,
                                 bool aP9_ShowInMedium ,
                                 ref bool aP10_ShowInLarge ,
                                 ref GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP11_CurrentMenu )
      {
         k2bmenuaddprogramwithactivity objk2bmenuaddprogramwithactivity;
         objk2bmenuaddprogramwithactivity = new k2bmenuaddprogramwithactivity();
         objk2bmenuaddprogramwithactivity.AV9Code = aP0_Code;
         objk2bmenuaddprogramwithactivity.AV21Title = aP1_Title;
         objk2bmenuaddprogramwithactivity.AV12GXObject = aP2_GXObject;
         objk2bmenuaddprogramwithactivity.AV13GXObjectParameters = aP3_GXObjectParameters;
         objk2bmenuaddprogramwithactivity.AV15ImageUrl = aP4_ImageUrl;
         objk2bmenuaddprogramwithactivity.AV14ImageClass = aP5_ImageClass;
         objk2bmenuaddprogramwithactivity.AV8Activity = aP6_Activity;
         objk2bmenuaddprogramwithactivity.AV17ShowInExtraSmall = aP7_ShowInExtraSmall;
         objk2bmenuaddprogramwithactivity.AV20ShowInSmall = aP8_ShowInSmall;
         objk2bmenuaddprogramwithactivity.AV19ShowInMedium = aP9_ShowInMedium;
         objk2bmenuaddprogramwithactivity.AV18ShowInLarge = aP10_ShowInLarge;
         objk2bmenuaddprogramwithactivity.AV10CurrentMenu = aP11_CurrentMenu;
         objk2bmenuaddprogramwithactivity.context.SetSubmitInitialConfig(context);
         objk2bmenuaddprogramwithactivity.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bmenuaddprogramwithactivity);
         aP10_ShowInLarge=this.AV18ShowInLarge;
         aP11_CurrentMenu=this.AV10CurrentMenu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bmenuaddprogramwithactivity)stateInfo).executePrivate();
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
         AV11CurrentMenuItem = new SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem(context);
         AV11CurrentMenuItem.gxTpr_Code = AV9Code;
         AV11CurrentMenuItem.gxTpr_Imageclass = AV14ImageClass;
         AV11CurrentMenuItem.gxTpr_Imageurl = AV15ImageUrl;
         AV11CurrentMenuItem.gxTpr_Title = AV21Title;
         AV11CurrentMenuItem.gxTpr_Gxobject = StringUtil.Lower( AV12GXObject);
         AV11CurrentMenuItem.gxTpr_Gxobjectparameters = AV13GXObjectParameters;
         AV11CurrentMenuItem.gxTpr_Activity = AV8Activity;
         new k2bmenupersistencesetshowin(context ).execute(  AV17ShowInExtraSmall,  AV20ShowInSmall,  AV19ShowInMedium, ref  AV18ShowInLarge, ref  AV11CurrentMenuItem) ;
         AV10CurrentMenu.Add(AV11CurrentMenuItem, 0);
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
         AV11CurrentMenuItem = new SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9Code ;
      private string AV21Title ;
      private string AV13GXObjectParameters ;
      private string AV14ImageClass ;
      private bool AV17ShowInExtraSmall ;
      private bool AV20ShowInSmall ;
      private bool AV19ShowInMedium ;
      private bool AV18ShowInLarge ;
      private string AV12GXObject ;
      private string AV15ImageUrl ;
      private bool aP10_ShowInLarge ;
      private GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> aP11_CurrentMenu ;
      private GXBaseCollection<SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem> AV10CurrentMenu ;
      private SdtK2BActivity AV8Activity ;
      private SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem AV11CurrentMenuItem ;
   }

}
