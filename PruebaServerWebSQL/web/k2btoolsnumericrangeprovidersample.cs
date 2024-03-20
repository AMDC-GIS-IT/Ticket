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
   public class k2btoolsnumericrangeprovidersample : GXProcedure
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
            return "" ;
         }

      }

      public k2btoolsnumericrangeprovidersample( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2btoolsnumericrangeprovidersample( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<SdtK2BNumericRangeSet_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtK2BNumericRangeSet_Item>( context, "Item", "kb_ticket") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtK2BNumericRangeSet_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BNumericRangeSet_Item> aP0_Gxm2rootcol )
      {
         k2btoolsnumericrangeprovidersample objk2btoolsnumericrangeprovidersample;
         objk2btoolsnumericrangeprovidersample = new k2btoolsnumericrangeprovidersample();
         objk2btoolsnumericrangeprovidersample.Gxm2rootcol = new GXBaseCollection<SdtK2BNumericRangeSet_Item>( context, "Item", "kb_ticket") ;
         objk2btoolsnumericrangeprovidersample.context.SetSubmitInitialConfig(context);
         objk2btoolsnumericrangeprovidersample.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2btoolsnumericrangeprovidersample);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsnumericrangeprovidersample)stateInfo).executePrivate();
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
         Gxm1k2bnumericrangeset = new SdtK2BNumericRangeSet_Item(context);
         Gxm2rootcol.Add(Gxm1k2bnumericrangeset, 0);
         Gxm1k2bnumericrangeset.gxTpr_Code = "0-100";
         Gxm1k2bnumericrangeset.gxTpr_Description = "0-100";
         Gxm1k2bnumericrangeset.gxTpr_Fromvalue = "0";
         Gxm1k2bnumericrangeset.gxTpr_Tovalue = "100";
         Gxm1k2bnumericrangeset = new SdtK2BNumericRangeSet_Item(context);
         Gxm2rootcol.Add(Gxm1k2bnumericrangeset, 0);
         Gxm1k2bnumericrangeset.gxTpr_Code = "100-200";
         Gxm1k2bnumericrangeset.gxTpr_Description = "100-200";
         Gxm1k2bnumericrangeset.gxTpr_Fromvalue = "100";
         Gxm1k2bnumericrangeset.gxTpr_Tovalue = "200";
         Gxm1k2bnumericrangeset = new SdtK2BNumericRangeSet_Item(context);
         Gxm2rootcol.Add(Gxm1k2bnumericrangeset, 0);
         Gxm1k2bnumericrangeset.gxTpr_Code = "0.5-1.5";
         Gxm1k2bnumericrangeset.gxTpr_Description = "0.5-1.5";
         Gxm1k2bnumericrangeset.gxTpr_Fromvalue = "0.5";
         Gxm1k2bnumericrangeset.gxTpr_Tovalue = "1.5";
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
         Gxm1k2bnumericrangeset = new SdtK2BNumericRangeSet_Item(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<SdtK2BNumericRangeSet_Item> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtK2BNumericRangeSet_Item> Gxm2rootcol ;
      private SdtK2BNumericRangeSet_Item Gxm1k2bnumericrangeset ;
   }

}
