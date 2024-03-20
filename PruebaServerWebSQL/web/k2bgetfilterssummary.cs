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
   public class k2bgetfilterssummary : GXProcedure
   {
      public k2bgetfilterssummary( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetfilterssummary( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT ,
                           out string aP3_FilterSummary )
      {
         this.AV15ProgramName = aP0_ProgramName;
         this.AV11GridName = aP1_GridName;
         this.AV8K2BFilterValuesSDT = aP2_K2BFilterValuesSDT;
         this.AV10FilterSummary = "" ;
         initialize();
         executePrivate();
         aP3_FilterSummary=this.AV10FilterSummary;
      }

      public string executeUdp( string aP0_ProgramName ,
                                string aP1_GridName ,
                                GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT )
      {
         execute(aP0_ProgramName, aP1_GridName, aP2_K2BFilterValuesSDT, out aP3_FilterSummary);
         return AV10FilterSummary ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> aP2_K2BFilterValuesSDT ,
                                 out string aP3_FilterSummary )
      {
         k2bgetfilterssummary objk2bgetfilterssummary;
         objk2bgetfilterssummary = new k2bgetfilterssummary();
         objk2bgetfilterssummary.AV15ProgramName = aP0_ProgramName;
         objk2bgetfilterssummary.AV11GridName = aP1_GridName;
         objk2bgetfilterssummary.AV8K2BFilterValuesSDT = aP2_K2BFilterValuesSDT;
         objk2bgetfilterssummary.AV10FilterSummary = "" ;
         objk2bgetfilterssummary.context.SetSubmitInitialConfig(context);
         objk2bgetfilterssummary.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetfilterssummary);
         aP3_FilterSummary=this.AV10FilterSummary;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetfilterssummary)stateInfo).executePrivate();
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
         AV12K2BAttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV8K2BFilterValuesSDT.Count )
         {
            AV9K2BFilterValuesSDTItem = ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem)AV8K2BFilterValuesSDT.Item(AV18GXV1));
            AV13K2BAttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV13K2BAttributeValueItem.gxTpr_Attributename = AV9K2BFilterValuesSDTItem.gxTpr_Description;
            if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "Standard") == 0 )
            {
               GXt_char1 = "";
               new k2bgetstandardfiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Valuedescription, out  GXt_char1) ;
               AV13K2BAttributeValueItem.gxTpr_Attributevalue = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "DateTimeRange") == 0 )
            {
               GXt_char1 = "";
               new k2bgetdatetimerangefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangetovalue, out  GXt_char1) ;
               AV13K2BAttributeValueItem.gxTpr_Attributevalue = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "DateRange") == 0 )
            {
               GXt_char1 = "";
               new k2bgetdaterangefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Semanticdaterangevalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangefromvalue,  AV9K2BFilterValuesSDTItem.gxTpr_Daterangetovalue, out  GXt_char1) ;
               AV13K2BAttributeValueItem.gxTpr_Attributevalue = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "Multiple") == 0 )
            {
               GXt_char1 = "";
               new k2bgetmultiplefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Multiplevalues, out  GXt_char1) ;
               AV13K2BAttributeValueItem.gxTpr_Attributevalue = GXt_char1;
            }
            else if ( StringUtil.StrCmp(AV9K2BFilterValuesSDTItem.gxTpr_Type, "Numeric Range") == 0 )
            {
               GXt_char1 = "";
               new k2bgetnumericrangefiltervaluesummary(context ).execute(  AV9K2BFilterValuesSDTItem.gxTpr_Semanticnumericrangevalue,  AV9K2BFilterValuesSDTItem.gxTpr_Numericrangefromvalue,  AV9K2BFilterValuesSDTItem.gxTpr_Numericrangetovalue, out  GXt_char1) ;
               AV13K2BAttributeValueItem.gxTpr_Attributevalue = GXt_char1;
            }
            AV12K2BAttributeValue.Add(AV13K2BAttributeValueItem, 0);
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         GXt_char1 = AV10FilterSummary;
         new k2bjoinfiltervalues(context ).execute(  AV12K2BAttributeValue, out  GXt_char1) ;
         AV10FilterSummary = GXt_char1;
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
         AV10FilterSummary = "";
         AV12K2BAttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV9K2BFilterValuesSDTItem = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         AV13K2BAttributeValueItem = new SdtK2BAttributeValue_Item(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18GXV1 ;
      private string AV15ProgramName ;
      private string AV11GridName ;
      private string AV10FilterSummary ;
      private string GXt_char1 ;
      private string aP3_FilterSummary ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV8K2BFilterValuesSDT ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV12K2BAttributeValue ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV9K2BFilterValuesSDTItem ;
      private SdtK2BAttributeValue_Item AV13K2BAttributeValueItem ;
   }

}
