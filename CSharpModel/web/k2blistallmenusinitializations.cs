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
   public class k2blistallmenusinitializations : GXProcedure
   {
      public k2blistallmenusinitializations( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2blistallmenusinitializations( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BPersistedMenuOutput> aP0_PersistedMenuOutputCollection )
      {
         this.AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "kb_ticket") ;
         initialize();
         executePrivate();
         aP0_PersistedMenuOutputCollection=this.AV9PersistedMenuOutputCollection;
      }

      public GXBaseCollection<SdtK2BPersistedMenuOutput> executeUdp( )
      {
         execute(out aP0_PersistedMenuOutputCollection);
         return AV9PersistedMenuOutputCollection ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BPersistedMenuOutput> aP0_PersistedMenuOutputCollection )
      {
         k2blistallmenusinitializations objk2blistallmenusinitializations;
         objk2blistallmenusinitializations = new k2blistallmenusinitializations();
         objk2blistallmenusinitializations.AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "kb_ticket") ;
         objk2blistallmenusinitializations.context.SetSubmitInitialConfig(context);
         objk2blistallmenusinitializations.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2blistallmenusinitializations);
         aP0_PersistedMenuOutputCollection=this.AV9PersistedMenuOutputCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2blistallmenusinitializations)stateInfo).executePrivate();
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
         AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "kb_ticket");
         AV8PersistedMenuOutput = new SdtK2BPersistedMenuOutput(context);
         GXt_SdtK2BPersistedMenuOutput1 = AV8PersistedMenuOutput;
         new k2bmenuticketgetmenuinitialization(context ).execute( out  GXt_SdtK2BPersistedMenuOutput1) ;
         AV8PersistedMenuOutput = GXt_SdtK2BPersistedMenuOutput1;
         AV9PersistedMenuOutputCollection.Add(AV8PersistedMenuOutput, 0);
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
         AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "kb_ticket");
         AV8PersistedMenuOutput = new SdtK2BPersistedMenuOutput(context);
         GXt_SdtK2BPersistedMenuOutput1 = new SdtK2BPersistedMenuOutput(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<SdtK2BPersistedMenuOutput> aP0_PersistedMenuOutputCollection ;
      private GXBaseCollection<SdtK2BPersistedMenuOutput> AV9PersistedMenuOutputCollection ;
      private SdtK2BPersistedMenuOutput AV8PersistedMenuOutput ;
      private SdtK2BPersistedMenuOutput GXt_SdtK2BPersistedMenuOutput1 ;
   }

}
