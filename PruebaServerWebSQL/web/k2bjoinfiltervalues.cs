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
   public class k2bjoinfiltervalues : GXProcedure
   {
      public k2bjoinfiltervalues( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bjoinfiltervalues( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GXBaseCollection<SdtK2BAttributeValue_Item> aP0_K2BAttributeValue ,
                           out string aP1_Result )
      {
         this.AV8K2BAttributeValue = aP0_K2BAttributeValue;
         this.AV9Result = "" ;
         initialize();
         executePrivate();
         aP1_Result=this.AV9Result;
      }

      public string executeUdp( GXBaseCollection<SdtK2BAttributeValue_Item> aP0_K2BAttributeValue )
      {
         execute(aP0_K2BAttributeValue, out aP1_Result);
         return AV9Result ;
      }

      public void executeSubmit( GXBaseCollection<SdtK2BAttributeValue_Item> aP0_K2BAttributeValue ,
                                 out string aP1_Result )
      {
         k2bjoinfiltervalues objk2bjoinfiltervalues;
         objk2bjoinfiltervalues = new k2bjoinfiltervalues();
         objk2bjoinfiltervalues.AV8K2BAttributeValue = aP0_K2BAttributeValue;
         objk2bjoinfiltervalues.AV9Result = "" ;
         objk2bjoinfiltervalues.context.SetSubmitInitialConfig(context);
         objk2bjoinfiltervalues.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bjoinfiltervalues);
         aP1_Result=this.AV9Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bjoinfiltervalues)stateInfo).executePrivate();
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
         AV9Result = "";
         if ( AV8K2BAttributeValue.Count > 0 )
         {
            AV9Result = ((SdtK2BAttributeValue_Item)AV8K2BAttributeValue.Item(1)).gxTpr_Attributename + ": " + ((SdtK2BAttributeValue_Item)AV8K2BAttributeValue.Item(1)).gxTpr_Attributevalue;
            AV10i = 2;
            while ( AV10i <= AV8K2BAttributeValue.Count )
            {
               AV9Result += ", " + ((SdtK2BAttributeValue_Item)AV8K2BAttributeValue.Item(AV10i)).gxTpr_Attributename + ": " + ((SdtK2BAttributeValue_Item)AV8K2BAttributeValue.Item(AV10i)).gxTpr_Attributevalue;
               AV10i = (short)(AV10i+1);
            }
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
         AV9Result = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10i ;
      private string AV9Result ;
      private string aP1_Result ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV8K2BAttributeValue ;
   }

}
