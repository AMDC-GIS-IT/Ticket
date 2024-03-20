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
   public class k2bmenupersistencesetshowin : GXProcedure
   {
      public k2bmenupersistencesetshowin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bmenupersistencesetshowin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( bool aP0_ShowInExtraSmall ,
                           bool aP1_ShowInSmall ,
                           bool aP2_ShowInMedium ,
                           ref bool aP3_ShowInLarge ,
                           ref SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem aP4_CurrentMenuItem )
      {
         this.AV16ShowInExtraSmall = aP0_ShowInExtraSmall;
         this.AV19ShowInSmall = aP1_ShowInSmall;
         this.AV18ShowInMedium = aP2_ShowInMedium;
         this.AV17ShowInLarge = aP3_ShowInLarge;
         this.AV11CurrentMenuItem = aP4_CurrentMenuItem;
         initialize();
         executePrivate();
         aP3_ShowInLarge=this.AV17ShowInLarge;
         aP4_CurrentMenuItem=this.AV11CurrentMenuItem;
      }

      public SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem executeUdp( bool aP0_ShowInExtraSmall ,
                                                                                      bool aP1_ShowInSmall ,
                                                                                      bool aP2_ShowInMedium ,
                                                                                      ref bool aP3_ShowInLarge )
      {
         execute(aP0_ShowInExtraSmall, aP1_ShowInSmall, aP2_ShowInMedium, ref aP3_ShowInLarge, ref aP4_CurrentMenuItem);
         return AV11CurrentMenuItem ;
      }

      public void executeSubmit( bool aP0_ShowInExtraSmall ,
                                 bool aP1_ShowInSmall ,
                                 bool aP2_ShowInMedium ,
                                 ref bool aP3_ShowInLarge ,
                                 ref SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem aP4_CurrentMenuItem )
      {
         k2bmenupersistencesetshowin objk2bmenupersistencesetshowin;
         objk2bmenupersistencesetshowin = new k2bmenupersistencesetshowin();
         objk2bmenupersistencesetshowin.AV16ShowInExtraSmall = aP0_ShowInExtraSmall;
         objk2bmenupersistencesetshowin.AV19ShowInSmall = aP1_ShowInSmall;
         objk2bmenupersistencesetshowin.AV18ShowInMedium = aP2_ShowInMedium;
         objk2bmenupersistencesetshowin.AV17ShowInLarge = aP3_ShowInLarge;
         objk2bmenupersistencesetshowin.AV11CurrentMenuItem = aP4_CurrentMenuItem;
         objk2bmenupersistencesetshowin.context.SetSubmitInitialConfig(context);
         objk2bmenupersistencesetshowin.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bmenupersistencesetshowin);
         aP3_ShowInLarge=this.AV17ShowInLarge;
         aP4_CurrentMenuItem=this.AV11CurrentMenuItem;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bmenupersistencesetshowin)stateInfo).executePrivate();
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
         AV11CurrentMenuItem.gxTpr_Showinextrasmall = AV16ShowInExtraSmall;
         AV11CurrentMenuItem.gxTpr_Showinsmall = AV19ShowInSmall;
         AV11CurrentMenuItem.gxTpr_Showinmedium = AV18ShowInMedium;
         AV11CurrentMenuItem.gxTpr_Showinlarge = AV17ShowInLarge;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV16ShowInExtraSmall ;
      private bool AV19ShowInSmall ;
      private bool AV18ShowInMedium ;
      private bool AV17ShowInLarge ;
      private bool aP3_ShowInLarge ;
      private SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem aP4_CurrentMenuItem ;
      private SdtK2BMultiLevelPersistedMenu_K2BMultiLevelPersistedMenuItem AV11CurrentMenuItem ;
   }

}
