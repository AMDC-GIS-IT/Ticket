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
   public class k2btoolsmsg : GXProcedure
   {
      public k2btoolsmsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2btoolsmsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Message ,
                           short aP1_MessageType )
      {
         this.AV8Message = aP0_Message;
         this.AV9MessageType = aP1_MessageType;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_Message ,
                                 short aP1_MessageType )
      {
         k2btoolsmsg objk2btoolsmsg;
         objk2btoolsmsg = new k2btoolsmsg();
         objk2btoolsmsg.AV8Message = aP0_Message;
         objk2btoolsmsg.AV9MessageType = aP1_MessageType;
         objk2btoolsmsg.context.SetSubmitInitialConfig(context);
         objk2btoolsmsg.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2btoolsmsg);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsmsg)stateInfo).executePrivate();
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
         if ( AV9MessageType == 0 )
         {
            GX_msglist.addItem("K2BToolsMessage:info:"+AV8Message);
         }
         else if ( AV9MessageType == 3 )
         {
            GX_msglist.addItem("K2BToolsMessage:success:"+AV8Message);
         }
         else if ( AV9MessageType == 2 )
         {
            GX_msglist.addItem("K2BToolsMessage:error:"+AV8Message);
         }
         else if ( AV9MessageType == 1 )
         {
            GX_msglist.addItem("K2BToolsMessage:warning:"+AV8Message);
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

      private short AV9MessageType ;
      private string AV8Message ;
   }

}
