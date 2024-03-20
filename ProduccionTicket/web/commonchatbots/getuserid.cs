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
namespace GeneXus.Programs.commonchatbots {
   public class getuserid : GXProcedure
   {
      public getuserid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public getuserid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out Guid aP0_UserId )
      {
         this.AV8UserId = Guid.Empty ;
         initialize();
         executePrivate();
         aP0_UserId=this.AV8UserId;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_UserId);
         return AV8UserId ;
      }

      public void executeSubmit( out Guid aP0_UserId )
      {
         getuserid objgetuserid;
         objgetuserid = new getuserid();
         objgetuserid.AV8UserId = Guid.Empty ;
         objgetuserid.context.SetSubmitInitialConfig(context);
         objgetuserid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetuserid);
         aP0_UserId=this.AV8UserId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getuserid)stateInfo).executePrivate();
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
         AV8UserId = (Guid)(StringUtil.StrToGuid( "6AB18499-CA51-4C36-AC15-4F6735FB09E4"));
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
         AV8UserId = (Guid)(Guid.Empty);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private Guid AV8UserId ;
      private Guid aP0_UserId ;
   }

}
