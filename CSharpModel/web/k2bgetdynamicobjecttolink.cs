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
   public class k2bgetdynamicobjecttolink : GXProcedure
   {
      public k2bgetdynamicobjecttolink( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetdynamicobjecttolink( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_DynamicObjectToLink )
      {
         this.AV8DynamicObjectToLink = aP0_DynamicObjectToLink;
         initialize();
         executePrivate();
         aP0_DynamicObjectToLink=this.AV8DynamicObjectToLink;
      }

      public string executeUdp( )
      {
         execute(ref aP0_DynamicObjectToLink);
         return AV8DynamicObjectToLink ;
      }

      public void executeSubmit( ref string aP0_DynamicObjectToLink )
      {
         k2bgetdynamicobjecttolink objk2bgetdynamicobjecttolink;
         objk2bgetdynamicobjecttolink = new k2bgetdynamicobjecttolink();
         objk2bgetdynamicobjecttolink.AV8DynamicObjectToLink = aP0_DynamicObjectToLink;
         objk2bgetdynamicobjecttolink.context.SetSubmitInitialConfig(context);
         objk2bgetdynamicobjecttolink.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetdynamicobjecttolink);
         aP0_DynamicObjectToLink=this.AV8DynamicObjectToLink;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetdynamicobjecttolink)stateInfo).executePrivate();
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
         if ( StringUtil.StringSearchRev( AV8DynamicObjectToLink, ".aspx", -1) == 0 )
         {
            /* User Code */
              AV8DynamicObjectToLink += ".aspx" ;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8DynamicObjectToLink ;
      private string aP0_DynamicObjectToLink ;
   }

}
