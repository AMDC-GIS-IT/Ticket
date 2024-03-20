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
namespace GeneXus.Programs.k2bfsg {
   public class k2bgetfilterssummarywrapper : GXProcedure
   {
      public k2bgetfilterssummarywrapper( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetfilterssummarywrapper( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT ,
                           out string aP3_FilterSummary )
      {
         this.AV18ProgramName = aP0_ProgramName;
         this.AV15GridName = aP1_GridName;
         this.AV9K2BFilterValuesSDT = aP2_K2BFilterValuesSDT;
         this.AV11FilterSummary = "" ;
         initialize();
         executePrivate();
         aP3_FilterSummary=this.AV11FilterSummary;
      }

      public string executeUdp( string aP0_ProgramName ,
                                string aP1_GridName ,
                                GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT )
      {
         execute(aP0_ProgramName, aP1_GridName, aP2_K2BFilterValuesSDT, out aP3_FilterSummary);
         return AV11FilterSummary ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT ,
                                 out string aP3_FilterSummary )
      {
         k2bgetfilterssummarywrapper objk2bgetfilterssummarywrapper;
         objk2bgetfilterssummarywrapper = new k2bgetfilterssummarywrapper();
         objk2bgetfilterssummarywrapper.AV18ProgramName = aP0_ProgramName;
         objk2bgetfilterssummarywrapper.AV15GridName = aP1_GridName;
         objk2bgetfilterssummarywrapper.AV9K2BFilterValuesSDT = aP2_K2BFilterValuesSDT;
         objk2bgetfilterssummarywrapper.AV11FilterSummary = "" ;
         objk2bgetfilterssummarywrapper.context.SetSubmitInitialConfig(context);
         objk2bgetfilterssummarywrapper.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetfilterssummarywrapper);
         aP3_FilterSummary=this.AV11FilterSummary;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetfilterssummarywrapper)stateInfo).executePrivate();
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
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV9K2BFilterValuesSDT.Count )
         {
            AV17K2BFilterValuesSDTItem = ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem)AV9K2BFilterValuesSDT.Item(AV21GXV1));
            if ( ( StringUtil.StrCmp(AV17K2BFilterValuesSDTItem.gxTpr_Name, "ApplicationId") == 0 ) || ( StringUtil.StrCmp(AV17K2BFilterValuesSDTItem.gxTpr_Name, "ApplicationId_Filter") == 0 ) )
            {
               AV10ApplicationId = (short)(NumberUtil.Val( AV17K2BFilterValuesSDTItem.gxTpr_Value, "."));
               AV12GAMApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
               AV12GAMApplicationFilter.gxTpr_Id = AV10ApplicationId;
               AV13GAMApplications = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV12GAMApplicationFilter, out  AV14GAMErrors);
               AV22GXV2 = 1;
               while ( AV22GXV2 <= AV13GAMApplications.Count )
               {
                  AV8GAMApplication = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV13GAMApplications.Item(AV22GXV2));
                  if ( AV8GAMApplication.gxTpr_Id == AV10ApplicationId )
                  {
                     AV17K2BFilterValuesSDTItem.gxTpr_Valuedescription = AV8GAMApplication.gxTpr_Name;
                  }
                  AV22GXV2 = (int)(AV22GXV2+1);
               }
            }
            AV21GXV1 = (int)(AV21GXV1+1);
         }
         new k2bgetfilterssummary(context ).execute(  AV18ProgramName,  AV15GridName,  AV9K2BFilterValuesSDT, out  AV11FilterSummary) ;
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
         AV11FilterSummary = "";
         AV17K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         AV12GAMApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
         AV13GAMApplications = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplication", "GeneXus.Programs");
         AV14GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10ApplicationId ;
      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private string AV18ProgramName ;
      private string AV15GridName ;
      private string AV11FilterSummary ;
      private string aP3_FilterSummary ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication> AV13GAMApplications ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrors ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV9K2BFilterValuesSDT ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8GAMApplication ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV17K2BFilterValuesSDTItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter AV12GAMApplicationFilter ;
   }

}
