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
   public class dataproviderqueryticket : GXProcedure
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

      public dataproviderqueryticket( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public dataproviderqueryticket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_FechaUsuarioDesde ,
                           DateTime aP1_FechaUsuarioHasta ,
                           out GXBaseCollection<SdtQueryViewerParameters_Parameter> aP2_Gxm2rootcol )
      {
         this.AV7FechaUsuarioDesde = aP0_FechaUsuarioDesde;
         this.AV8FechaUsuarioHasta = aP1_FechaUsuarioHasta;
         this.Gxm2rootcol = new GXBaseCollection<SdtQueryViewerParameters_Parameter>( context, "Parameter", "kb_ticket") ;
         initialize();
         executePrivate();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtQueryViewerParameters_Parameter> executeUdp( DateTime aP0_FechaUsuarioDesde ,
                                                                              DateTime aP1_FechaUsuarioHasta )
      {
         execute(aP0_FechaUsuarioDesde, aP1_FechaUsuarioHasta, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FechaUsuarioDesde ,
                                 DateTime aP1_FechaUsuarioHasta ,
                                 out GXBaseCollection<SdtQueryViewerParameters_Parameter> aP2_Gxm2rootcol )
      {
         dataproviderqueryticket objdataproviderqueryticket;
         objdataproviderqueryticket = new dataproviderqueryticket();
         objdataproviderqueryticket.AV7FechaUsuarioDesde = aP0_FechaUsuarioDesde;
         objdataproviderqueryticket.AV8FechaUsuarioHasta = aP1_FechaUsuarioHasta;
         objdataproviderqueryticket.Gxm2rootcol = new GXBaseCollection<SdtQueryViewerParameters_Parameter>( context, "Parameter", "kb_ticket") ;
         objdataproviderqueryticket.context.SetSubmitInitialConfig(context);
         objdataproviderqueryticket.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdataproviderqueryticket);
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dataproviderqueryticket)stateInfo).executePrivate();
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
         Gxm1queryviewerparameters = new SdtQueryViewerParameters_Parameter(context);
         Gxm2rootcol.Add(Gxm1queryviewerparameters, 0);
         Gxm1queryviewerparameters.gxTpr_Name = "UsuarioFechaDesde";
         Gxm1queryviewerparameters.gxTpr_Value = context.localUtil.DToC( AV7FechaUsuarioDesde, 2, "/");
         Gxm1queryviewerparameters = new SdtQueryViewerParameters_Parameter(context);
         Gxm2rootcol.Add(Gxm1queryviewerparameters, 0);
         Gxm1queryviewerparameters.gxTpr_Name = "UsuarioFechaHasta";
         Gxm1queryviewerparameters.gxTpr_Value = context.localUtil.DToC( AV8FechaUsuarioHasta, 2, "/");
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
         Gxm1queryviewerparameters = new SdtQueryViewerParameters_Parameter(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV7FechaUsuarioDesde ;
      private DateTime AV8FechaUsuarioHasta ;
      private GXBaseCollection<SdtQueryViewerParameters_Parameter> aP2_Gxm2rootcol ;
      private GXBaseCollection<SdtQueryViewerParameters_Parameter> Gxm2rootcol ;
      private SdtQueryViewerParameters_Parameter Gxm1queryviewerparameters ;
   }

}
