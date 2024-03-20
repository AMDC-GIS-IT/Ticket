using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class ticketresponsableconversion : GXProcedure
   {
      public ticketresponsableconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public ticketresponsableconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         ticketresponsableconversion objticketresponsableconversion;
         objticketresponsableconversion = new ticketresponsableconversion();
         objticketresponsableconversion.context.SetSubmitInitialConfig(context);
         objticketresponsableconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objticketresponsableconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ticketresponsableconversion)stateInfo).executePrivate();
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
         /* Using cursor TICKETRESP2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A6ResponsableId = TICKETRESP2_A6ResponsableId[0];
            A186TicketResponsableOtrosTallerTxt = TICKETRESP2_A186TicketResponsableOtrosTallerTxt[0];
            n186TicketResponsableOtrosTallerTxt = TICKETRESP2_n186TicketResponsableOtrosTallerTxt[0];
            A185TicketResponsableCableEspecialTxt = TICKETRESP2_A185TicketResponsableCableEspecialTxt[0];
            n185TicketResponsableCableEspecialTxt = TICKETRESP2_n185TicketResponsableCableEspecialTxt[0];
            A184TicketResponsableCDsDVDsTxt = TICKETRESP2_A184TicketResponsableCDsDVDsTxt[0];
            n184TicketResponsableCDsDVDsTxt = TICKETRESP2_n184TicketResponsableCDsDVDsTxt[0];
            A183TicketResponsableCargadorLaptopTxt = TICKETRESP2_A183TicketResponsableCargadorLaptopTxt[0];
            n183TicketResponsableCargadorLaptopTxt = TICKETRESP2_n183TicketResponsableCargadorLaptopTxt[0];
            A182TicketResponsableTarjetaVideoExtraTxt = TICKETRESP2_A182TicketResponsableTarjetaVideoExtraTxt[0];
            n182TicketResponsableTarjetaVideoExtraTxt = TICKETRESP2_n182TicketResponsableTarjetaVideoExtraTxt[0];
            A181TicketResponsableTonerCintaTxt = TICKETRESP2_A181TicketResponsableTonerCintaTxt[0];
            n181TicketResponsableTonerCintaTxt = TICKETRESP2_n181TicketResponsableTonerCintaTxt[0];
            A180TicketResponsableMaletinTxt = TICKETRESP2_A180TicketResponsableMaletinTxt[0];
            n180TicketResponsableMaletinTxt = TICKETRESP2_n180TicketResponsableMaletinTxt[0];
            A179TicketResponsableProcesadorTxt = TICKETRESP2_A179TicketResponsableProcesadorTxt[0];
            n179TicketResponsableProcesadorTxt = TICKETRESP2_n179TicketResponsableProcesadorTxt[0];
            A178TicketResponsableDiscoDuroTxt = TICKETRESP2_A178TicketResponsableDiscoDuroTxt[0];
            n178TicketResponsableDiscoDuroTxt = TICKETRESP2_n178TicketResponsableDiscoDuroTxt[0];
            A177TicketResponsableRamTxt = TICKETRESP2_A177TicketResponsableRamTxt[0];
            n177TicketResponsableRamTxt = TICKETRESP2_n177TicketResponsableRamTxt[0];
            A176TicketResponsableHoraResuelve = TICKETRESP2_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = TICKETRESP2_n176TicketResponsableHoraResuelve[0];
            A175TicketResponsableFechaResuelve = TICKETRESP2_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = TICKETRESP2_n175TicketResponsableFechaResuelve[0];
            A168TicketResponsableObservacion = TICKETRESP2_A168TicketResponsableObservacion[0];
            n168TicketResponsableObservacion = TICKETRESP2_n168TicketResponsableObservacion[0];
            A167TicketResponsablePasaTaller = TICKETRESP2_A167TicketResponsablePasaTaller[0];
            n167TicketResponsablePasaTaller = TICKETRESP2_n167TicketResponsablePasaTaller[0];
            A166TicketResponsablePendiente = TICKETRESP2_A166TicketResponsablePendiente[0];
            n166TicketResponsablePendiente = TICKETRESP2_n166TicketResponsablePendiente[0];
            A165TicketResponsableCerrado = TICKETRESP2_A165TicketResponsableCerrado[0];
            n165TicketResponsableCerrado = TICKETRESP2_n165TicketResponsableCerrado[0];
            A154TicketResponsableCopiasRespaldo = TICKETRESP2_A154TicketResponsableCopiasRespaldo[0];
            n154TicketResponsableCopiasRespaldo = TICKETRESP2_n154TicketResponsableCopiasRespaldo[0];
            A153TicketResponsableCambiosHardware = TICKETRESP2_A153TicketResponsableCambiosHardware[0];
            n153TicketResponsableCambiosHardware = TICKETRESP2_n153TicketResponsableCambiosHardware[0];
            A152TicketResponsablePuntoRed = TICKETRESP2_A152TicketResponsablePuntoRed[0];
            n152TicketResponsablePuntoRed = TICKETRESP2_n152TicketResponsablePuntoRed[0];
            A151TicketResponsableLimpieza = TICKETRESP2_A151TicketResponsableLimpieza[0];
            n151TicketResponsableLimpieza = TICKETRESP2_n151TicketResponsableLimpieza[0];
            A150TicketResponsableReparacion = TICKETRESP2_A150TicketResponsableReparacion[0];
            n150TicketResponsableReparacion = TICKETRESP2_n150TicketResponsableReparacion[0];
            A149TicketResponsableFormateo = TICKETRESP2_A149TicketResponsableFormateo[0];
            n149TicketResponsableFormateo = TICKETRESP2_n149TicketResponsableFormateo[0];
            A148TicketResponsableInternetRouter = TICKETRESP2_A148TicketResponsableInternetRouter[0];
            n148TicketResponsableInternetRouter = TICKETRESP2_n148TicketResponsableInternetRouter[0];
            A147TicketResponsableConfiguracion = TICKETRESP2_A147TicketResponsableConfiguracion[0];
            n147TicketResponsableConfiguracion = TICKETRESP2_n147TicketResponsableConfiguracion[0];
            A146TicketResponsableInstalacion = TICKETRESP2_A146TicketResponsableInstalacion[0];
            n146TicketResponsableInstalacion = TICKETRESP2_n146TicketResponsableInstalacion[0];
            A145TicketResponsableInventarioSerie = TICKETRESP2_A145TicketResponsableInventarioSerie[0];
            n145TicketResponsableInventarioSerie = TICKETRESP2_n145TicketResponsableInventarioSerie[0];
            A17EstadoTicketTecnicoId = TICKETRESP2_A17EstadoTicketTecnicoId[0];
            A49TicketHoraResponsable = TICKETRESP2_A49TicketHoraResponsable[0];
            A47TicketFechaResponsable = TICKETRESP2_A47TicketFechaResponsable[0];
            A16TicketResponsableId = TICKETRESP2_A16TicketResponsableId[0];
            A14TicketId = TICKETRESP2_A14TicketId[0];
            /*
               INSERT RECORD ON TABLE GXA0008

            */
            AV2TicketId = A14TicketId;
            AV3TicketResponsableId = A16TicketResponsableId;
            AV4TicketFechaResponsable = A47TicketFechaResponsable;
            AV5TicketHoraResponsable = A49TicketHoraResponsable;
            AV6EstadoTicketTecnicoId = A17EstadoTicketTecnicoId;
            if ( TICKETRESP2_n145TicketResponsableInventarioSerie[0] )
            {
               AV7TicketResponsableInventarioSerie = "";
               nV7TicketResponsableInventarioSerie = false;
               nV7TicketResponsableInventarioSerie = true;
            }
            else
            {
               AV7TicketResponsableInventarioSerie = A145TicketResponsableInventarioSerie;
               nV7TicketResponsableInventarioSerie = false;
            }
            if ( TICKETRESP2_n146TicketResponsableInstalacion[0] )
            {
               AV8TicketResponsableInstalacion = false;
               nV8TicketResponsableInstalacion = false;
               nV8TicketResponsableInstalacion = true;
            }
            else
            {
               AV8TicketResponsableInstalacion = A146TicketResponsableInstalacion;
               nV8TicketResponsableInstalacion = false;
            }
            if ( TICKETRESP2_n147TicketResponsableConfiguracion[0] )
            {
               AV9TicketResponsableConfiguracion = false;
               nV9TicketResponsableConfiguracion = false;
               nV9TicketResponsableConfiguracion = true;
            }
            else
            {
               AV9TicketResponsableConfiguracion = A147TicketResponsableConfiguracion;
               nV9TicketResponsableConfiguracion = false;
            }
            if ( TICKETRESP2_n148TicketResponsableInternetRouter[0] )
            {
               AV10TicketResponsableInternetRouter = false;
               nV10TicketResponsableInternetRouter = false;
               nV10TicketResponsableInternetRouter = true;
            }
            else
            {
               AV10TicketResponsableInternetRouter = A148TicketResponsableInternetRouter;
               nV10TicketResponsableInternetRouter = false;
            }
            if ( TICKETRESP2_n149TicketResponsableFormateo[0] )
            {
               AV11TicketResponsableFormateo = false;
               nV11TicketResponsableFormateo = false;
               nV11TicketResponsableFormateo = true;
            }
            else
            {
               AV11TicketResponsableFormateo = A149TicketResponsableFormateo;
               nV11TicketResponsableFormateo = false;
            }
            if ( TICKETRESP2_n150TicketResponsableReparacion[0] )
            {
               AV12TicketResponsableReparacion = false;
               nV12TicketResponsableReparacion = false;
               nV12TicketResponsableReparacion = true;
            }
            else
            {
               AV12TicketResponsableReparacion = A150TicketResponsableReparacion;
               nV12TicketResponsableReparacion = false;
            }
            if ( TICKETRESP2_n151TicketResponsableLimpieza[0] )
            {
               AV13TicketResponsableLimpieza = false;
               nV13TicketResponsableLimpieza = false;
               nV13TicketResponsableLimpieza = true;
            }
            else
            {
               AV13TicketResponsableLimpieza = A151TicketResponsableLimpieza;
               nV13TicketResponsableLimpieza = false;
            }
            if ( TICKETRESP2_n152TicketResponsablePuntoRed[0] )
            {
               AV14TicketResponsablePuntoRed = false;
               nV14TicketResponsablePuntoRed = false;
               nV14TicketResponsablePuntoRed = true;
            }
            else
            {
               AV14TicketResponsablePuntoRed = A152TicketResponsablePuntoRed;
               nV14TicketResponsablePuntoRed = false;
            }
            if ( TICKETRESP2_n153TicketResponsableCambiosHardware[0] )
            {
               AV15TicketResponsableCambiosHardware = false;
               nV15TicketResponsableCambiosHardware = false;
               nV15TicketResponsableCambiosHardware = true;
            }
            else
            {
               AV15TicketResponsableCambiosHardware = A153TicketResponsableCambiosHardware;
               nV15TicketResponsableCambiosHardware = false;
            }
            if ( TICKETRESP2_n154TicketResponsableCopiasRespaldo[0] )
            {
               AV16TicketResponsableCopiasRespaldo = false;
               nV16TicketResponsableCopiasRespaldo = false;
               nV16TicketResponsableCopiasRespaldo = true;
            }
            else
            {
               AV16TicketResponsableCopiasRespaldo = A154TicketResponsableCopiasRespaldo;
               nV16TicketResponsableCopiasRespaldo = false;
            }
            if ( TICKETRESP2_n165TicketResponsableCerrado[0] )
            {
               AV17TicketResponsableCerrado = false;
               nV17TicketResponsableCerrado = false;
               nV17TicketResponsableCerrado = true;
            }
            else
            {
               AV17TicketResponsableCerrado = A165TicketResponsableCerrado;
               nV17TicketResponsableCerrado = false;
            }
            if ( TICKETRESP2_n166TicketResponsablePendiente[0] )
            {
               AV18TicketResponsablePendiente = false;
               nV18TicketResponsablePendiente = false;
               nV18TicketResponsablePendiente = true;
            }
            else
            {
               AV18TicketResponsablePendiente = A166TicketResponsablePendiente;
               nV18TicketResponsablePendiente = false;
            }
            if ( TICKETRESP2_n167TicketResponsablePasaTaller[0] )
            {
               AV19TicketResponsablePasaTaller = false;
               nV19TicketResponsablePasaTaller = false;
               nV19TicketResponsablePasaTaller = true;
            }
            else
            {
               AV19TicketResponsablePasaTaller = A167TicketResponsablePasaTaller;
               nV19TicketResponsablePasaTaller = false;
            }
            if ( TICKETRESP2_n168TicketResponsableObservacion[0] )
            {
               AV20TicketResponsableObservacion = "";
               nV20TicketResponsableObservacion = false;
               nV20TicketResponsableObservacion = true;
            }
            else
            {
               AV20TicketResponsableObservacion = A168TicketResponsableObservacion;
               nV20TicketResponsableObservacion = false;
            }
            if ( TICKETRESP2_n175TicketResponsableFechaResuelve[0] )
            {
               AV21TicketResponsableFechaResuelve = DateTime.MinValue;
               nV21TicketResponsableFechaResuelve = false;
               nV21TicketResponsableFechaResuelve = true;
            }
            else
            {
               AV21TicketResponsableFechaResuelve = A175TicketResponsableFechaResuelve;
               nV21TicketResponsableFechaResuelve = false;
            }
            if ( TICKETRESP2_n176TicketResponsableHoraResuelve[0] )
            {
               AV22TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
               nV22TicketResponsableHoraResuelve = false;
               nV22TicketResponsableHoraResuelve = true;
            }
            else
            {
               AV22TicketResponsableHoraResuelve = A176TicketResponsableHoraResuelve;
               nV22TicketResponsableHoraResuelve = false;
            }
            if ( TICKETRESP2_n177TicketResponsableRamTxt[0] )
            {
               AV23TicketResponsableRamTxt = "";
               nV23TicketResponsableRamTxt = false;
               nV23TicketResponsableRamTxt = true;
            }
            else
            {
               AV23TicketResponsableRamTxt = A177TicketResponsableRamTxt;
               nV23TicketResponsableRamTxt = false;
            }
            if ( TICKETRESP2_n178TicketResponsableDiscoDuroTxt[0] )
            {
               AV24TicketResponsableDiscoDuroTxt = "";
               nV24TicketResponsableDiscoDuroTxt = false;
               nV24TicketResponsableDiscoDuroTxt = true;
            }
            else
            {
               AV24TicketResponsableDiscoDuroTxt = A178TicketResponsableDiscoDuroTxt;
               nV24TicketResponsableDiscoDuroTxt = false;
            }
            if ( TICKETRESP2_n179TicketResponsableProcesadorTxt[0] )
            {
               AV25TicketResponsableProcesadorTxt = "";
               nV25TicketResponsableProcesadorTxt = false;
               nV25TicketResponsableProcesadorTxt = true;
            }
            else
            {
               AV25TicketResponsableProcesadorTxt = A179TicketResponsableProcesadorTxt;
               nV25TicketResponsableProcesadorTxt = false;
            }
            if ( TICKETRESP2_n180TicketResponsableMaletinTxt[0] )
            {
               AV26TicketResponsableMaletinTxt = "";
               nV26TicketResponsableMaletinTxt = false;
               nV26TicketResponsableMaletinTxt = true;
            }
            else
            {
               AV26TicketResponsableMaletinTxt = A180TicketResponsableMaletinTxt;
               nV26TicketResponsableMaletinTxt = false;
            }
            if ( TICKETRESP2_n181TicketResponsableTonerCintaTxt[0] )
            {
               AV27TicketResponsableTonerCintaTxt = "";
               nV27TicketResponsableTonerCintaTxt = false;
               nV27TicketResponsableTonerCintaTxt = true;
            }
            else
            {
               AV27TicketResponsableTonerCintaTxt = A181TicketResponsableTonerCintaTxt;
               nV27TicketResponsableTonerCintaTxt = false;
            }
            if ( TICKETRESP2_n182TicketResponsableTarjetaVideoExtraTxt[0] )
            {
               AV28TicketResponsableTarjetaVideoExtraTxt = "";
               nV28TicketResponsableTarjetaVideoExtraTxt = false;
               nV28TicketResponsableTarjetaVideoExtraTxt = true;
            }
            else
            {
               AV28TicketResponsableTarjetaVideoExtraTxt = A182TicketResponsableTarjetaVideoExtraTxt;
               nV28TicketResponsableTarjetaVideoExtraTxt = false;
            }
            if ( TICKETRESP2_n183TicketResponsableCargadorLaptopTxt[0] )
            {
               AV29TicketResponsableCargadorLaptopTxt = "";
               nV29TicketResponsableCargadorLaptopTxt = false;
               nV29TicketResponsableCargadorLaptopTxt = true;
            }
            else
            {
               AV29TicketResponsableCargadorLaptopTxt = A183TicketResponsableCargadorLaptopTxt;
               nV29TicketResponsableCargadorLaptopTxt = false;
            }
            if ( TICKETRESP2_n184TicketResponsableCDsDVDsTxt[0] )
            {
               AV30TicketResponsableCDsDVDsTxt = "";
               nV30TicketResponsableCDsDVDsTxt = false;
               nV30TicketResponsableCDsDVDsTxt = true;
            }
            else
            {
               AV30TicketResponsableCDsDVDsTxt = A184TicketResponsableCDsDVDsTxt;
               nV30TicketResponsableCDsDVDsTxt = false;
            }
            if ( TICKETRESP2_n185TicketResponsableCableEspecialTxt[0] )
            {
               AV31TicketResponsableCableEspecialTxt = "";
               nV31TicketResponsableCableEspecialTxt = false;
               nV31TicketResponsableCableEspecialTxt = true;
            }
            else
            {
               AV31TicketResponsableCableEspecialTxt = A185TicketResponsableCableEspecialTxt;
               nV31TicketResponsableCableEspecialTxt = false;
            }
            if ( TICKETRESP2_n186TicketResponsableOtrosTallerTxt[0] )
            {
               AV32TicketResponsableOtrosTallerTxt = "";
               nV32TicketResponsableOtrosTallerTxt = false;
               nV32TicketResponsableOtrosTallerTxt = true;
            }
            else
            {
               AV32TicketResponsableOtrosTallerTxt = A186TicketResponsableOtrosTallerTxt;
               nV32TicketResponsableOtrosTallerTxt = false;
            }
            AV33TicketTecnicoResponsableId = A6ResponsableId;
            /* Using cursor TICKETRESP3 */
            pr_default.execute(1, new Object[] {AV2TicketId, AV3TicketResponsableId, AV4TicketFechaResponsable, AV5TicketHoraResponsable, AV6EstadoTicketTecnicoId, nV7TicketResponsableInventarioSerie, AV7TicketResponsableInventarioSerie, nV8TicketResponsableInstalacion, AV8TicketResponsableInstalacion, nV9TicketResponsableConfiguracion, AV9TicketResponsableConfiguracion, nV10TicketResponsableInternetRouter, AV10TicketResponsableInternetRouter, nV11TicketResponsableFormateo, AV11TicketResponsableFormateo, nV12TicketResponsableReparacion, AV12TicketResponsableReparacion, nV13TicketResponsableLimpieza, AV13TicketResponsableLimpieza, nV14TicketResponsablePuntoRed, AV14TicketResponsablePuntoRed, nV15TicketResponsableCambiosHardware, AV15TicketResponsableCambiosHardware, nV16TicketResponsableCopiasRespaldo, AV16TicketResponsableCopiasRespaldo, nV17TicketResponsableCerrado, AV17TicketResponsableCerrado, nV18TicketResponsablePendiente, AV18TicketResponsablePendiente, nV19TicketResponsablePasaTaller, AV19TicketResponsablePasaTaller, nV20TicketResponsableObservacion, AV20TicketResponsableObservacion, nV21TicketResponsableFechaResuelve, AV21TicketResponsableFechaResuelve, nV22TicketResponsableHoraResuelve, AV22TicketResponsableHoraResuelve, nV23TicketResponsableRamTxt, AV23TicketResponsableRamTxt, nV24TicketResponsableDiscoDuroTxt, AV24TicketResponsableDiscoDuroTxt, nV25TicketResponsableProcesadorTxt, AV25TicketResponsableProcesadorTxt, nV26TicketResponsableMaletinTxt, AV26TicketResponsableMaletinTxt, nV27TicketResponsableTonerCintaTxt, AV27TicketResponsableTonerCintaTxt, nV28TicketResponsableTarjetaVideoExtraTxt, AV28TicketResponsableTarjetaVideoExtraTxt, nV29TicketResponsableCargadorLaptopTxt, AV29TicketResponsableCargadorLaptopTxt, nV30TicketResponsableCDsDVDsTxt, AV30TicketResponsableCDsDVDsTxt, nV31TicketResponsableCableEspecialTxt, AV31TicketResponsableCableEspecialTxt, nV32TicketResponsableOtrosTallerTxt, AV32TicketResponsableOtrosTallerTxt, AV33TicketTecnicoResponsableId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0008");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         TICKETRESP2_A6ResponsableId = new short[1] ;
         TICKETRESP2_A186TicketResponsableOtrosTallerTxt = new string[] {""} ;
         TICKETRESP2_n186TicketResponsableOtrosTallerTxt = new bool[] {false} ;
         TICKETRESP2_A185TicketResponsableCableEspecialTxt = new string[] {""} ;
         TICKETRESP2_n185TicketResponsableCableEspecialTxt = new bool[] {false} ;
         TICKETRESP2_A184TicketResponsableCDsDVDsTxt = new string[] {""} ;
         TICKETRESP2_n184TicketResponsableCDsDVDsTxt = new bool[] {false} ;
         TICKETRESP2_A183TicketResponsableCargadorLaptopTxt = new string[] {""} ;
         TICKETRESP2_n183TicketResponsableCargadorLaptopTxt = new bool[] {false} ;
         TICKETRESP2_A182TicketResponsableTarjetaVideoExtraTxt = new string[] {""} ;
         TICKETRESP2_n182TicketResponsableTarjetaVideoExtraTxt = new bool[] {false} ;
         TICKETRESP2_A181TicketResponsableTonerCintaTxt = new string[] {""} ;
         TICKETRESP2_n181TicketResponsableTonerCintaTxt = new bool[] {false} ;
         TICKETRESP2_A180TicketResponsableMaletinTxt = new string[] {""} ;
         TICKETRESP2_n180TicketResponsableMaletinTxt = new bool[] {false} ;
         TICKETRESP2_A179TicketResponsableProcesadorTxt = new string[] {""} ;
         TICKETRESP2_n179TicketResponsableProcesadorTxt = new bool[] {false} ;
         TICKETRESP2_A178TicketResponsableDiscoDuroTxt = new string[] {""} ;
         TICKETRESP2_n178TicketResponsableDiscoDuroTxt = new bool[] {false} ;
         TICKETRESP2_A177TicketResponsableRamTxt = new string[] {""} ;
         TICKETRESP2_n177TicketResponsableRamTxt = new bool[] {false} ;
         TICKETRESP2_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         TICKETRESP2_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         TICKETRESP2_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         TICKETRESP2_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         TICKETRESP2_A168TicketResponsableObservacion = new string[] {""} ;
         TICKETRESP2_n168TicketResponsableObservacion = new bool[] {false} ;
         TICKETRESP2_A167TicketResponsablePasaTaller = new bool[] {false} ;
         TICKETRESP2_n167TicketResponsablePasaTaller = new bool[] {false} ;
         TICKETRESP2_A166TicketResponsablePendiente = new bool[] {false} ;
         TICKETRESP2_n166TicketResponsablePendiente = new bool[] {false} ;
         TICKETRESP2_A165TicketResponsableCerrado = new bool[] {false} ;
         TICKETRESP2_n165TicketResponsableCerrado = new bool[] {false} ;
         TICKETRESP2_A154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         TICKETRESP2_n154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         TICKETRESP2_A153TicketResponsableCambiosHardware = new bool[] {false} ;
         TICKETRESP2_n153TicketResponsableCambiosHardware = new bool[] {false} ;
         TICKETRESP2_A152TicketResponsablePuntoRed = new bool[] {false} ;
         TICKETRESP2_n152TicketResponsablePuntoRed = new bool[] {false} ;
         TICKETRESP2_A151TicketResponsableLimpieza = new bool[] {false} ;
         TICKETRESP2_n151TicketResponsableLimpieza = new bool[] {false} ;
         TICKETRESP2_A150TicketResponsableReparacion = new bool[] {false} ;
         TICKETRESP2_n150TicketResponsableReparacion = new bool[] {false} ;
         TICKETRESP2_A149TicketResponsableFormateo = new bool[] {false} ;
         TICKETRESP2_n149TicketResponsableFormateo = new bool[] {false} ;
         TICKETRESP2_A148TicketResponsableInternetRouter = new bool[] {false} ;
         TICKETRESP2_n148TicketResponsableInternetRouter = new bool[] {false} ;
         TICKETRESP2_A147TicketResponsableConfiguracion = new bool[] {false} ;
         TICKETRESP2_n147TicketResponsableConfiguracion = new bool[] {false} ;
         TICKETRESP2_A146TicketResponsableInstalacion = new bool[] {false} ;
         TICKETRESP2_n146TicketResponsableInstalacion = new bool[] {false} ;
         TICKETRESP2_A145TicketResponsableInventarioSerie = new string[] {""} ;
         TICKETRESP2_n145TicketResponsableInventarioSerie = new bool[] {false} ;
         TICKETRESP2_A17EstadoTicketTecnicoId = new short[1] ;
         TICKETRESP2_A49TicketHoraResponsable = new DateTime[] {DateTime.MinValue} ;
         TICKETRESP2_A47TicketFechaResponsable = new DateTime[] {DateTime.MinValue} ;
         TICKETRESP2_A16TicketResponsableId = new long[1] ;
         TICKETRESP2_A14TicketId = new long[1] ;
         A186TicketResponsableOtrosTallerTxt = "";
         A185TicketResponsableCableEspecialTxt = "";
         A184TicketResponsableCDsDVDsTxt = "";
         A183TicketResponsableCargadorLaptopTxt = "";
         A182TicketResponsableTarjetaVideoExtraTxt = "";
         A181TicketResponsableTonerCintaTxt = "";
         A180TicketResponsableMaletinTxt = "";
         A179TicketResponsableProcesadorTxt = "";
         A178TicketResponsableDiscoDuroTxt = "";
         A177TicketResponsableRamTxt = "";
         A176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         A175TicketResponsableFechaResuelve = DateTime.MinValue;
         A168TicketResponsableObservacion = "";
         A145TicketResponsableInventarioSerie = "";
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         AV4TicketFechaResponsable = DateTime.MinValue;
         AV5TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         AV7TicketResponsableInventarioSerie = "";
         AV20TicketResponsableObservacion = "";
         AV21TicketResponsableFechaResuelve = DateTime.MinValue;
         AV22TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         AV23TicketResponsableRamTxt = "";
         AV24TicketResponsableDiscoDuroTxt = "";
         AV25TicketResponsableProcesadorTxt = "";
         AV26TicketResponsableMaletinTxt = "";
         AV27TicketResponsableTonerCintaTxt = "";
         AV28TicketResponsableTarjetaVideoExtraTxt = "";
         AV29TicketResponsableCargadorLaptopTxt = "";
         AV30TicketResponsableCDsDVDsTxt = "";
         AV31TicketResponsableCableEspecialTxt = "";
         AV32TicketResponsableOtrosTallerTxt = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ticketresponsableconversion__default(),
            new Object[][] {
                new Object[] {
               TICKETRESP2_A6ResponsableId, TICKETRESP2_A186TicketResponsableOtrosTallerTxt, TICKETRESP2_n186TicketResponsableOtrosTallerTxt, TICKETRESP2_A185TicketResponsableCableEspecialTxt, TICKETRESP2_n185TicketResponsableCableEspecialTxt, TICKETRESP2_A184TicketResponsableCDsDVDsTxt, TICKETRESP2_n184TicketResponsableCDsDVDsTxt, TICKETRESP2_A183TicketResponsableCargadorLaptopTxt, TICKETRESP2_n183TicketResponsableCargadorLaptopTxt, TICKETRESP2_A182TicketResponsableTarjetaVideoExtraTxt,
               TICKETRESP2_n182TicketResponsableTarjetaVideoExtraTxt, TICKETRESP2_A181TicketResponsableTonerCintaTxt, TICKETRESP2_n181TicketResponsableTonerCintaTxt, TICKETRESP2_A180TicketResponsableMaletinTxt, TICKETRESP2_n180TicketResponsableMaletinTxt, TICKETRESP2_A179TicketResponsableProcesadorTxt, TICKETRESP2_n179TicketResponsableProcesadorTxt, TICKETRESP2_A178TicketResponsableDiscoDuroTxt, TICKETRESP2_n178TicketResponsableDiscoDuroTxt, TICKETRESP2_A177TicketResponsableRamTxt,
               TICKETRESP2_n177TicketResponsableRamTxt, TICKETRESP2_A176TicketResponsableHoraResuelve, TICKETRESP2_n176TicketResponsableHoraResuelve, TICKETRESP2_A175TicketResponsableFechaResuelve, TICKETRESP2_n175TicketResponsableFechaResuelve, TICKETRESP2_A168TicketResponsableObservacion, TICKETRESP2_n168TicketResponsableObservacion, TICKETRESP2_A167TicketResponsablePasaTaller, TICKETRESP2_n167TicketResponsablePasaTaller, TICKETRESP2_A166TicketResponsablePendiente,
               TICKETRESP2_n166TicketResponsablePendiente, TICKETRESP2_A165TicketResponsableCerrado, TICKETRESP2_n165TicketResponsableCerrado, TICKETRESP2_A154TicketResponsableCopiasRespaldo, TICKETRESP2_n154TicketResponsableCopiasRespaldo, TICKETRESP2_A153TicketResponsableCambiosHardware, TICKETRESP2_n153TicketResponsableCambiosHardware, TICKETRESP2_A152TicketResponsablePuntoRed, TICKETRESP2_n152TicketResponsablePuntoRed, TICKETRESP2_A151TicketResponsableLimpieza,
               TICKETRESP2_n151TicketResponsableLimpieza, TICKETRESP2_A150TicketResponsableReparacion, TICKETRESP2_n150TicketResponsableReparacion, TICKETRESP2_A149TicketResponsableFormateo, TICKETRESP2_n149TicketResponsableFormateo, TICKETRESP2_A148TicketResponsableInternetRouter, TICKETRESP2_n148TicketResponsableInternetRouter, TICKETRESP2_A147TicketResponsableConfiguracion, TICKETRESP2_n147TicketResponsableConfiguracion, TICKETRESP2_A146TicketResponsableInstalacion,
               TICKETRESP2_n146TicketResponsableInstalacion, TICKETRESP2_A145TicketResponsableInventarioSerie, TICKETRESP2_n145TicketResponsableInventarioSerie, TICKETRESP2_A17EstadoTicketTecnicoId, TICKETRESP2_A49TicketHoraResponsable, TICKETRESP2_A47TicketFechaResponsable, TICKETRESP2_A16TicketResponsableId, TICKETRESP2_A14TicketId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A6ResponsableId ;
      private short A17EstadoTicketTecnicoId ;
      private short AV6EstadoTicketTecnicoId ;
      private short AV33TicketTecnicoResponsableId ;
      private int GIGXA0008 ;
      private long A16TicketResponsableId ;
      private long A14TicketId ;
      private long AV2TicketId ;
      private long AV3TicketResponsableId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A176TicketResponsableHoraResuelve ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime AV5TicketHoraResponsable ;
      private DateTime AV22TicketResponsableHoraResuelve ;
      private DateTime A175TicketResponsableFechaResuelve ;
      private DateTime A47TicketFechaResponsable ;
      private DateTime AV4TicketFechaResponsable ;
      private DateTime AV21TicketResponsableFechaResuelve ;
      private bool n186TicketResponsableOtrosTallerTxt ;
      private bool n185TicketResponsableCableEspecialTxt ;
      private bool n184TicketResponsableCDsDVDsTxt ;
      private bool n183TicketResponsableCargadorLaptopTxt ;
      private bool n182TicketResponsableTarjetaVideoExtraTxt ;
      private bool n181TicketResponsableTonerCintaTxt ;
      private bool n180TicketResponsableMaletinTxt ;
      private bool n179TicketResponsableProcesadorTxt ;
      private bool n178TicketResponsableDiscoDuroTxt ;
      private bool n177TicketResponsableRamTxt ;
      private bool n176TicketResponsableHoraResuelve ;
      private bool n175TicketResponsableFechaResuelve ;
      private bool n168TicketResponsableObservacion ;
      private bool A167TicketResponsablePasaTaller ;
      private bool n167TicketResponsablePasaTaller ;
      private bool A166TicketResponsablePendiente ;
      private bool n166TicketResponsablePendiente ;
      private bool A165TicketResponsableCerrado ;
      private bool n165TicketResponsableCerrado ;
      private bool A154TicketResponsableCopiasRespaldo ;
      private bool n154TicketResponsableCopiasRespaldo ;
      private bool A153TicketResponsableCambiosHardware ;
      private bool n153TicketResponsableCambiosHardware ;
      private bool A152TicketResponsablePuntoRed ;
      private bool n152TicketResponsablePuntoRed ;
      private bool A151TicketResponsableLimpieza ;
      private bool n151TicketResponsableLimpieza ;
      private bool A150TicketResponsableReparacion ;
      private bool n150TicketResponsableReparacion ;
      private bool A149TicketResponsableFormateo ;
      private bool n149TicketResponsableFormateo ;
      private bool A148TicketResponsableInternetRouter ;
      private bool n148TicketResponsableInternetRouter ;
      private bool A147TicketResponsableConfiguracion ;
      private bool n147TicketResponsableConfiguracion ;
      private bool A146TicketResponsableInstalacion ;
      private bool n146TicketResponsableInstalacion ;
      private bool n145TicketResponsableInventarioSerie ;
      private bool nV7TicketResponsableInventarioSerie ;
      private bool AV8TicketResponsableInstalacion ;
      private bool nV8TicketResponsableInstalacion ;
      private bool AV9TicketResponsableConfiguracion ;
      private bool nV9TicketResponsableConfiguracion ;
      private bool AV10TicketResponsableInternetRouter ;
      private bool nV10TicketResponsableInternetRouter ;
      private bool AV11TicketResponsableFormateo ;
      private bool nV11TicketResponsableFormateo ;
      private bool AV12TicketResponsableReparacion ;
      private bool nV12TicketResponsableReparacion ;
      private bool AV13TicketResponsableLimpieza ;
      private bool nV13TicketResponsableLimpieza ;
      private bool AV14TicketResponsablePuntoRed ;
      private bool nV14TicketResponsablePuntoRed ;
      private bool AV15TicketResponsableCambiosHardware ;
      private bool nV15TicketResponsableCambiosHardware ;
      private bool AV16TicketResponsableCopiasRespaldo ;
      private bool nV16TicketResponsableCopiasRespaldo ;
      private bool AV17TicketResponsableCerrado ;
      private bool nV17TicketResponsableCerrado ;
      private bool AV18TicketResponsablePendiente ;
      private bool nV18TicketResponsablePendiente ;
      private bool AV19TicketResponsablePasaTaller ;
      private bool nV19TicketResponsablePasaTaller ;
      private bool nV20TicketResponsableObservacion ;
      private bool nV21TicketResponsableFechaResuelve ;
      private bool nV22TicketResponsableHoraResuelve ;
      private bool nV23TicketResponsableRamTxt ;
      private bool nV24TicketResponsableDiscoDuroTxt ;
      private bool nV25TicketResponsableProcesadorTxt ;
      private bool nV26TicketResponsableMaletinTxt ;
      private bool nV27TicketResponsableTonerCintaTxt ;
      private bool nV28TicketResponsableTarjetaVideoExtraTxt ;
      private bool nV29TicketResponsableCargadorLaptopTxt ;
      private bool nV30TicketResponsableCDsDVDsTxt ;
      private bool nV31TicketResponsableCableEspecialTxt ;
      private bool nV32TicketResponsableOtrosTallerTxt ;
      private string A186TicketResponsableOtrosTallerTxt ;
      private string A185TicketResponsableCableEspecialTxt ;
      private string A184TicketResponsableCDsDVDsTxt ;
      private string A183TicketResponsableCargadorLaptopTxt ;
      private string A182TicketResponsableTarjetaVideoExtraTxt ;
      private string A181TicketResponsableTonerCintaTxt ;
      private string A180TicketResponsableMaletinTxt ;
      private string A179TicketResponsableProcesadorTxt ;
      private string A178TicketResponsableDiscoDuroTxt ;
      private string A177TicketResponsableRamTxt ;
      private string A168TicketResponsableObservacion ;
      private string A145TicketResponsableInventarioSerie ;
      private string AV7TicketResponsableInventarioSerie ;
      private string AV20TicketResponsableObservacion ;
      private string AV23TicketResponsableRamTxt ;
      private string AV24TicketResponsableDiscoDuroTxt ;
      private string AV25TicketResponsableProcesadorTxt ;
      private string AV26TicketResponsableMaletinTxt ;
      private string AV27TicketResponsableTonerCintaTxt ;
      private string AV28TicketResponsableTarjetaVideoExtraTxt ;
      private string AV29TicketResponsableCargadorLaptopTxt ;
      private string AV30TicketResponsableCDsDVDsTxt ;
      private string AV31TicketResponsableCableEspecialTxt ;
      private string AV32TicketResponsableOtrosTallerTxt ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] TICKETRESP2_A6ResponsableId ;
      private string[] TICKETRESP2_A186TicketResponsableOtrosTallerTxt ;
      private bool[] TICKETRESP2_n186TicketResponsableOtrosTallerTxt ;
      private string[] TICKETRESP2_A185TicketResponsableCableEspecialTxt ;
      private bool[] TICKETRESP2_n185TicketResponsableCableEspecialTxt ;
      private string[] TICKETRESP2_A184TicketResponsableCDsDVDsTxt ;
      private bool[] TICKETRESP2_n184TicketResponsableCDsDVDsTxt ;
      private string[] TICKETRESP2_A183TicketResponsableCargadorLaptopTxt ;
      private bool[] TICKETRESP2_n183TicketResponsableCargadorLaptopTxt ;
      private string[] TICKETRESP2_A182TicketResponsableTarjetaVideoExtraTxt ;
      private bool[] TICKETRESP2_n182TicketResponsableTarjetaVideoExtraTxt ;
      private string[] TICKETRESP2_A181TicketResponsableTonerCintaTxt ;
      private bool[] TICKETRESP2_n181TicketResponsableTonerCintaTxt ;
      private string[] TICKETRESP2_A180TicketResponsableMaletinTxt ;
      private bool[] TICKETRESP2_n180TicketResponsableMaletinTxt ;
      private string[] TICKETRESP2_A179TicketResponsableProcesadorTxt ;
      private bool[] TICKETRESP2_n179TicketResponsableProcesadorTxt ;
      private string[] TICKETRESP2_A178TicketResponsableDiscoDuroTxt ;
      private bool[] TICKETRESP2_n178TicketResponsableDiscoDuroTxt ;
      private string[] TICKETRESP2_A177TicketResponsableRamTxt ;
      private bool[] TICKETRESP2_n177TicketResponsableRamTxt ;
      private DateTime[] TICKETRESP2_A176TicketResponsableHoraResuelve ;
      private bool[] TICKETRESP2_n176TicketResponsableHoraResuelve ;
      private DateTime[] TICKETRESP2_A175TicketResponsableFechaResuelve ;
      private bool[] TICKETRESP2_n175TicketResponsableFechaResuelve ;
      private string[] TICKETRESP2_A168TicketResponsableObservacion ;
      private bool[] TICKETRESP2_n168TicketResponsableObservacion ;
      private bool[] TICKETRESP2_A167TicketResponsablePasaTaller ;
      private bool[] TICKETRESP2_n167TicketResponsablePasaTaller ;
      private bool[] TICKETRESP2_A166TicketResponsablePendiente ;
      private bool[] TICKETRESP2_n166TicketResponsablePendiente ;
      private bool[] TICKETRESP2_A165TicketResponsableCerrado ;
      private bool[] TICKETRESP2_n165TicketResponsableCerrado ;
      private bool[] TICKETRESP2_A154TicketResponsableCopiasRespaldo ;
      private bool[] TICKETRESP2_n154TicketResponsableCopiasRespaldo ;
      private bool[] TICKETRESP2_A153TicketResponsableCambiosHardware ;
      private bool[] TICKETRESP2_n153TicketResponsableCambiosHardware ;
      private bool[] TICKETRESP2_A152TicketResponsablePuntoRed ;
      private bool[] TICKETRESP2_n152TicketResponsablePuntoRed ;
      private bool[] TICKETRESP2_A151TicketResponsableLimpieza ;
      private bool[] TICKETRESP2_n151TicketResponsableLimpieza ;
      private bool[] TICKETRESP2_A150TicketResponsableReparacion ;
      private bool[] TICKETRESP2_n150TicketResponsableReparacion ;
      private bool[] TICKETRESP2_A149TicketResponsableFormateo ;
      private bool[] TICKETRESP2_n149TicketResponsableFormateo ;
      private bool[] TICKETRESP2_A148TicketResponsableInternetRouter ;
      private bool[] TICKETRESP2_n148TicketResponsableInternetRouter ;
      private bool[] TICKETRESP2_A147TicketResponsableConfiguracion ;
      private bool[] TICKETRESP2_n147TicketResponsableConfiguracion ;
      private bool[] TICKETRESP2_A146TicketResponsableInstalacion ;
      private bool[] TICKETRESP2_n146TicketResponsableInstalacion ;
      private string[] TICKETRESP2_A145TicketResponsableInventarioSerie ;
      private bool[] TICKETRESP2_n145TicketResponsableInventarioSerie ;
      private short[] TICKETRESP2_A17EstadoTicketTecnicoId ;
      private DateTime[] TICKETRESP2_A49TicketHoraResponsable ;
      private DateTime[] TICKETRESP2_A47TicketFechaResponsable ;
      private long[] TICKETRESP2_A16TicketResponsableId ;
      private long[] TICKETRESP2_A14TicketId ;
   }

   public class ticketresponsableconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTICKETRESP2;
          prmTICKETRESP2 = new Object[] {
          };
          Object[] prmTICKETRESP3;
          prmTICKETRESP3 = new Object[] {
          new ParDef("@AV2TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV3TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV4TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@AV5TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@AV6EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV7TicketResponsableInventarioSerie",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("@AV8TicketResponsableInstalacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV9TicketResponsableConfiguracion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV10TicketResponsableInternetRouter",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV11TicketResponsableFormateo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV12TicketResponsableReparacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV13TicketResponsableLimpieza",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV14TicketResponsablePuntoRed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV15TicketResponsableCambiosHardware",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV16TicketResponsableCopiasRespaldo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV17TicketResponsableCerrado",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV18TicketResponsablePendiente",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV19TicketResponsablePasaTaller",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV20TicketResponsableObservacion",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("@AV21TicketResponsableFechaResuelve",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@AV22TicketResponsableHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("@AV23TicketResponsableRamTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV24TicketResponsableDiscoDuroTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV25TicketResponsableProcesadorTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV26TicketResponsableMaletinTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV27TicketResponsableTonerCintaTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV28TicketResponsableTarjetaVideoExtraTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV29TicketResponsableCargadorLaptopTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV30TicketResponsableCDsDVDsTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV31TicketResponsableCableEspecialTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV32TicketResponsableOtrosTallerTxt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV33TicketTecnicoResponsableId",GXType.Int16,4,0)
          };
          string cmdBufferTICKETRESP3;
          cmdBufferTICKETRESP3=" INSERT INTO [GXA0008]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketTecnicoResponsableId]) VALUES(@AV2TicketId, @AV3TicketResponsableId, @AV4TicketFechaResponsable, @AV5TicketHoraResponsable, @AV6EstadoTicketTecnicoId, @AV7TicketResponsableInventarioSerie, @AV8TicketResponsableInstalacion, @AV9TicketResponsableConfiguracion, @AV10TicketResponsableInternetRouter, @AV11TicketResponsableFormateo, @AV12TicketResponsableReparacion, @AV13TicketResponsableLimpieza, @AV14TicketResponsablePuntoRed, @AV15TicketResponsableCambiosHardware, @AV16TicketResponsableCopiasRespaldo, @AV17TicketResponsableCerrado, @AV18TicketResponsablePendiente, @AV19TicketResponsablePasaTaller, @AV20TicketResponsableObservacion, @AV21TicketResponsableFechaResuelve, @AV22TicketResponsableHoraResuelve, @AV23TicketResponsableRamTxt, @AV24TicketResponsableDiscoDuroTxt, @AV25TicketResponsableProcesadorTxt, "
          + " @AV26TicketResponsableMaletinTxt, @AV27TicketResponsableTonerCintaTxt, @AV28TicketResponsableTarjetaVideoExtraTxt, @AV29TicketResponsableCargadorLaptopTxt, @AV30TicketResponsableCDsDVDsTxt, @AV31TicketResponsableCableEspecialTxt, @AV32TicketResponsableOtrosTallerTxt, @AV33TicketTecnicoResponsableId)" ;
          def= new CursorDef[] {
              new CursorDef("TICKETRESP2", "SELECT [ResponsableId], [TicketResponsableOtrosTallerTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableMaletinTxt], [TicketResponsableProcesadorTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableRamTxt], [TicketResponsableHoraResuelve], [TicketResponsableFechaResuelve], [TicketResponsableObservacion], [TicketResponsablePasaTaller], [TicketResponsablePendiente], [TicketResponsableCerrado], [TicketResponsableCopiasRespaldo], [TicketResponsableCambiosHardware], [TicketResponsablePuntoRed], [TicketResponsableLimpieza], [TicketResponsableReparacion], [TicketResponsableFormateo], [TicketResponsableInternetRouter], [TicketResponsableConfiguracion], [TicketResponsableInstalacion], [TicketResponsableInventarioSerie], [EstadoTicketTecnicoId], [TicketHoraResponsable], [TicketFechaResponsable], [TicketResponsableId], [TicketId] FROM [TicketResponsable] ORDER BY [TicketId], [TicketResponsableId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTICKETRESP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TICKETRESP3", cmdBufferTICKETRESP3, GxErrorMask.GX_NOMASK,prmTICKETRESP3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((bool[]) buf[27])[0] = rslt.getBool(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((bool[]) buf[29])[0] = rslt.getBool(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((bool[]) buf[45])[0] = rslt.getBool(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((bool[]) buf[47])[0] = rslt.getBool(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((bool[]) buf[49])[0] = rslt.getBool(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((DateTime[]) buf[54])[0] = rslt.getGXDateTime(29);
                ((DateTime[]) buf[55])[0] = rslt.getGXDate(30);
                ((long[]) buf[56])[0] = rslt.getLong(31);
                ((long[]) buf[57])[0] = rslt.getLong(32);
                return;
       }
    }

 }

}
