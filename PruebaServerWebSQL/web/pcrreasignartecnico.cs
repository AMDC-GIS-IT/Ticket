using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pcrreasignartecnico : GXProcedure
   {
      public pcrreasignartecnico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public pcrreasignartecnico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TicketId ,
                           short aP1_UsuarioId ,
                           long aP2_TicketResponsableId ,
                           short aP3_TicketTecnicoResponsableId ,
                           short aP4_ResponsableId ,
                           string aP5_TicketResponsableInventarioSerie ,
                           bool aP6_TicketResponsableInstalacion ,
                           bool aP7_TicketResponsableConfiguracion ,
                           bool aP8_TicketResponsableInternetRouter ,
                           bool aP9_TicketResponsableFormateo ,
                           bool aP10_TicketResponsableReparacion ,
                           bool aP11_TicketResponsableLimpieza ,
                           bool aP12_TicketResponsablePuntoRed ,
                           bool aP13_TicketResponsableCambiosHardware ,
                           bool aP14_TicketResponsableCopiasRespaldo ,
                           string aP15_TicketResponsableRamTxt ,
                           string aP16_TicketResponsableDiscoDuroTxt ,
                           string aP17_TicketResponsableProcesadorTxt ,
                           string aP18_TicketResponsableMaletinTxt ,
                           string aP19_TicketResponsableTonerCintaTxt ,
                           string aP20_TicketResponsableTarjetaVideoExtraTxt ,
                           string aP21_TicketResponsableCargadorLaptopTxt ,
                           string aP22_TicketResponsableCDsDVDsTxt ,
                           string aP23_TicketResponsableCableEspecialTxt ,
                           string aP24_TicketResponsableOtrosTallerTxt ,
                           bool aP25_TicketResponsableCerrado ,
                           bool aP26_TicketResponsablePendiente ,
                           bool aP27_TicketResponsablePasaTaller ,
                           string aP28_TicketResponsableObservacion ,
                           int aP29_categoria_tareaid_tipo_categoria ,
                           int aP30_id_actividad_categoria ,
                           string aP31_UsuarioNombre ,
                           string aP32_UsuarioDepartamento ,
                           string aP33_UsuarioEmail ,
                           int aP34_detalle_infotecid_unidad ,
                           string aP35_detalle_tarea ,
                           string aP36_prioridad ,
                           DateTime aP37_UsuarioFecha ,
                           short aP38_EstadoTicketTicketId )
      {
         this.AV24TicketId = aP0_TicketId;
         this.AV23UsuarioId = aP1_UsuarioId;
         this.AV8TicketResponsableId = aP2_TicketResponsableId;
         this.AV45TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV47ResponsableId = aP4_ResponsableId;
         this.AV9TicketResponsableInventarioSerie = aP5_TicketResponsableInventarioSerie;
         this.AV10TicketResponsableInstalacion = aP6_TicketResponsableInstalacion;
         this.AV11TicketResponsableConfiguracion = aP7_TicketResponsableConfiguracion;
         this.AV12TicketResponsableInternetRouter = aP8_TicketResponsableInternetRouter;
         this.AV13TicketResponsableFormateo = aP9_TicketResponsableFormateo;
         this.AV14TicketResponsableReparacion = aP10_TicketResponsableReparacion;
         this.AV15TicketResponsableLimpieza = aP11_TicketResponsableLimpieza;
         this.AV16TicketResponsablePuntoRed = aP12_TicketResponsablePuntoRed;
         this.AV17TicketResponsableCambiosHardware = aP13_TicketResponsableCambiosHardware;
         this.AV18TicketResponsableCopiasRespaldo = aP14_TicketResponsableCopiasRespaldo;
         this.AV25TicketResponsableRamTxt = aP15_TicketResponsableRamTxt;
         this.AV26TicketResponsableDiscoDuroTxt = aP16_TicketResponsableDiscoDuroTxt;
         this.AV27TicketResponsableProcesadorTxt = aP17_TicketResponsableProcesadorTxt;
         this.AV28TicketResponsableMaletinTxt = aP18_TicketResponsableMaletinTxt;
         this.AV29TicketResponsableTonerCintaTxt = aP19_TicketResponsableTonerCintaTxt;
         this.AV30TicketResponsableTarjetaVideoExtraTxt = aP20_TicketResponsableTarjetaVideoExtraTxt;
         this.AV31TicketResponsableCargadorLaptopTxt = aP21_TicketResponsableCargadorLaptopTxt;
         this.AV32TicketResponsableCDsDVDsTxt = aP22_TicketResponsableCDsDVDsTxt;
         this.AV33TicketResponsableCableEspecialTxt = aP23_TicketResponsableCableEspecialTxt;
         this.AV34TicketResponsableOtrosTallerTxt = aP24_TicketResponsableOtrosTallerTxt;
         this.AV19TicketResponsableCerrado = aP25_TicketResponsableCerrado;
         this.AV20TicketResponsablePendiente = aP26_TicketResponsablePendiente;
         this.AV21TicketResponsablePasaTaller = aP27_TicketResponsablePasaTaller;
         this.AV22TicketResponsableObservacion = aP28_TicketResponsableObservacion;
         this.AV43categoria_tareaid_tipo_categoria = aP29_categoria_tareaid_tipo_categoria;
         this.AV44id_actividad_categoria = aP30_id_actividad_categoria;
         this.AV41UsuarioNombre = aP31_UsuarioNombre;
         this.AV38UsuarioDepartamento = aP32_UsuarioDepartamento;
         this.AV42UsuarioEmail = aP33_UsuarioEmail;
         this.AV37detalle_infotecid_unidad = aP34_detalle_infotecid_unidad;
         this.AV36detalle_tarea = aP35_detalle_tarea;
         this.AV35prioridad = aP36_prioridad;
         this.AV39UsuarioFecha = aP37_UsuarioFecha;
         this.AV46EstadoTicketTicketId = aP38_EstadoTicketTicketId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_TicketId ,
                                 short aP1_UsuarioId ,
                                 long aP2_TicketResponsableId ,
                                 short aP3_TicketTecnicoResponsableId ,
                                 short aP4_ResponsableId ,
                                 string aP5_TicketResponsableInventarioSerie ,
                                 bool aP6_TicketResponsableInstalacion ,
                                 bool aP7_TicketResponsableConfiguracion ,
                                 bool aP8_TicketResponsableInternetRouter ,
                                 bool aP9_TicketResponsableFormateo ,
                                 bool aP10_TicketResponsableReparacion ,
                                 bool aP11_TicketResponsableLimpieza ,
                                 bool aP12_TicketResponsablePuntoRed ,
                                 bool aP13_TicketResponsableCambiosHardware ,
                                 bool aP14_TicketResponsableCopiasRespaldo ,
                                 string aP15_TicketResponsableRamTxt ,
                                 string aP16_TicketResponsableDiscoDuroTxt ,
                                 string aP17_TicketResponsableProcesadorTxt ,
                                 string aP18_TicketResponsableMaletinTxt ,
                                 string aP19_TicketResponsableTonerCintaTxt ,
                                 string aP20_TicketResponsableTarjetaVideoExtraTxt ,
                                 string aP21_TicketResponsableCargadorLaptopTxt ,
                                 string aP22_TicketResponsableCDsDVDsTxt ,
                                 string aP23_TicketResponsableCableEspecialTxt ,
                                 string aP24_TicketResponsableOtrosTallerTxt ,
                                 bool aP25_TicketResponsableCerrado ,
                                 bool aP26_TicketResponsablePendiente ,
                                 bool aP27_TicketResponsablePasaTaller ,
                                 string aP28_TicketResponsableObservacion ,
                                 int aP29_categoria_tareaid_tipo_categoria ,
                                 int aP30_id_actividad_categoria ,
                                 string aP31_UsuarioNombre ,
                                 string aP32_UsuarioDepartamento ,
                                 string aP33_UsuarioEmail ,
                                 int aP34_detalle_infotecid_unidad ,
                                 string aP35_detalle_tarea ,
                                 string aP36_prioridad ,
                                 DateTime aP37_UsuarioFecha ,
                                 short aP38_EstadoTicketTicketId )
      {
         pcrreasignartecnico objpcrreasignartecnico;
         objpcrreasignartecnico = new pcrreasignartecnico();
         objpcrreasignartecnico.AV24TicketId = aP0_TicketId;
         objpcrreasignartecnico.AV23UsuarioId = aP1_UsuarioId;
         objpcrreasignartecnico.AV8TicketResponsableId = aP2_TicketResponsableId;
         objpcrreasignartecnico.AV45TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         objpcrreasignartecnico.AV47ResponsableId = aP4_ResponsableId;
         objpcrreasignartecnico.AV9TicketResponsableInventarioSerie = aP5_TicketResponsableInventarioSerie;
         objpcrreasignartecnico.AV10TicketResponsableInstalacion = aP6_TicketResponsableInstalacion;
         objpcrreasignartecnico.AV11TicketResponsableConfiguracion = aP7_TicketResponsableConfiguracion;
         objpcrreasignartecnico.AV12TicketResponsableInternetRouter = aP8_TicketResponsableInternetRouter;
         objpcrreasignartecnico.AV13TicketResponsableFormateo = aP9_TicketResponsableFormateo;
         objpcrreasignartecnico.AV14TicketResponsableReparacion = aP10_TicketResponsableReparacion;
         objpcrreasignartecnico.AV15TicketResponsableLimpieza = aP11_TicketResponsableLimpieza;
         objpcrreasignartecnico.AV16TicketResponsablePuntoRed = aP12_TicketResponsablePuntoRed;
         objpcrreasignartecnico.AV17TicketResponsableCambiosHardware = aP13_TicketResponsableCambiosHardware;
         objpcrreasignartecnico.AV18TicketResponsableCopiasRespaldo = aP14_TicketResponsableCopiasRespaldo;
         objpcrreasignartecnico.AV25TicketResponsableRamTxt = aP15_TicketResponsableRamTxt;
         objpcrreasignartecnico.AV26TicketResponsableDiscoDuroTxt = aP16_TicketResponsableDiscoDuroTxt;
         objpcrreasignartecnico.AV27TicketResponsableProcesadorTxt = aP17_TicketResponsableProcesadorTxt;
         objpcrreasignartecnico.AV28TicketResponsableMaletinTxt = aP18_TicketResponsableMaletinTxt;
         objpcrreasignartecnico.AV29TicketResponsableTonerCintaTxt = aP19_TicketResponsableTonerCintaTxt;
         objpcrreasignartecnico.AV30TicketResponsableTarjetaVideoExtraTxt = aP20_TicketResponsableTarjetaVideoExtraTxt;
         objpcrreasignartecnico.AV31TicketResponsableCargadorLaptopTxt = aP21_TicketResponsableCargadorLaptopTxt;
         objpcrreasignartecnico.AV32TicketResponsableCDsDVDsTxt = aP22_TicketResponsableCDsDVDsTxt;
         objpcrreasignartecnico.AV33TicketResponsableCableEspecialTxt = aP23_TicketResponsableCableEspecialTxt;
         objpcrreasignartecnico.AV34TicketResponsableOtrosTallerTxt = aP24_TicketResponsableOtrosTallerTxt;
         objpcrreasignartecnico.AV19TicketResponsableCerrado = aP25_TicketResponsableCerrado;
         objpcrreasignartecnico.AV20TicketResponsablePendiente = aP26_TicketResponsablePendiente;
         objpcrreasignartecnico.AV21TicketResponsablePasaTaller = aP27_TicketResponsablePasaTaller;
         objpcrreasignartecnico.AV22TicketResponsableObservacion = aP28_TicketResponsableObservacion;
         objpcrreasignartecnico.AV43categoria_tareaid_tipo_categoria = aP29_categoria_tareaid_tipo_categoria;
         objpcrreasignartecnico.AV44id_actividad_categoria = aP30_id_actividad_categoria;
         objpcrreasignartecnico.AV41UsuarioNombre = aP31_UsuarioNombre;
         objpcrreasignartecnico.AV38UsuarioDepartamento = aP32_UsuarioDepartamento;
         objpcrreasignartecnico.AV42UsuarioEmail = aP33_UsuarioEmail;
         objpcrreasignartecnico.AV37detalle_infotecid_unidad = aP34_detalle_infotecid_unidad;
         objpcrreasignartecnico.AV36detalle_tarea = aP35_detalle_tarea;
         objpcrreasignartecnico.AV35prioridad = aP36_prioridad;
         objpcrreasignartecnico.AV39UsuarioFecha = aP37_UsuarioFecha;
         objpcrreasignartecnico.AV46EstadoTicketTicketId = aP38_EstadoTicketTicketId;
         objpcrreasignartecnico.context.SetSubmitInitialConfig(context);
         objpcrreasignartecnico.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrreasignartecnico);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrreasignartecnico)stateInfo).executePrivate();
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
         /*
            INSERT RECORD ON TABLE TicketResponsable

         */
         /* Using cursor P00653 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00653_A40000GXC1[0];
            n40000GXC1 = P00653_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV49TicketResponsableSig = (long)(A40000GXC1+1);
         A14TicketId = AV24TicketId;
         A16TicketResponsableId = AV49TicketResponsableSig;
         A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A47TicketFechaResponsable = DateTimeUtil.Today( context);
         A198TicketTecnicoResponsableId = AV47ResponsableId;
         A17EstadoTicketTecnicoId = 3;
         A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
         n165TicketResponsableCerrado = false;
         A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
         n166TicketResponsablePendiente = false;
         A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
         n167TicketResponsablePasaTaller = false;
         A290EtapaDesarrolloId = 8;
         n290EtapaDesarrolloId = false;
         /* Using cursor P00654 */
         pr_default.execute(1, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
         if ( (pr_default.getStatus(1) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /* Using cursor P00655 */
         pr_default.execute(2, new Object[] {AV8TicketResponsableId, AV45TicketTecnicoResponsableId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A17EstadoTicketTecnicoId = P00655_A17EstadoTicketTecnicoId[0];
            A198TicketTecnicoResponsableId = P00655_A198TicketTecnicoResponsableId[0];
            A16TicketResponsableId = P00655_A16TicketResponsableId[0];
            A145TicketResponsableInventarioSerie = P00655_A145TicketResponsableInventarioSerie[0];
            n145TicketResponsableInventarioSerie = P00655_n145TicketResponsableInventarioSerie[0];
            A146TicketResponsableInstalacion = P00655_A146TicketResponsableInstalacion[0];
            n146TicketResponsableInstalacion = P00655_n146TicketResponsableInstalacion[0];
            A147TicketResponsableConfiguracion = P00655_A147TicketResponsableConfiguracion[0];
            n147TicketResponsableConfiguracion = P00655_n147TicketResponsableConfiguracion[0];
            A148TicketResponsableInternetRouter = P00655_A148TicketResponsableInternetRouter[0];
            n148TicketResponsableInternetRouter = P00655_n148TicketResponsableInternetRouter[0];
            A149TicketResponsableFormateo = P00655_A149TicketResponsableFormateo[0];
            n149TicketResponsableFormateo = P00655_n149TicketResponsableFormateo[0];
            A150TicketResponsableReparacion = P00655_A150TicketResponsableReparacion[0];
            n150TicketResponsableReparacion = P00655_n150TicketResponsableReparacion[0];
            A151TicketResponsableLimpieza = P00655_A151TicketResponsableLimpieza[0];
            n151TicketResponsableLimpieza = P00655_n151TicketResponsableLimpieza[0];
            A152TicketResponsablePuntoRed = P00655_A152TicketResponsablePuntoRed[0];
            n152TicketResponsablePuntoRed = P00655_n152TicketResponsablePuntoRed[0];
            A153TicketResponsableCambiosHardware = P00655_A153TicketResponsableCambiosHardware[0];
            n153TicketResponsableCambiosHardware = P00655_n153TicketResponsableCambiosHardware[0];
            A154TicketResponsableCopiasRespaldo = P00655_A154TicketResponsableCopiasRespaldo[0];
            n154TicketResponsableCopiasRespaldo = P00655_n154TicketResponsableCopiasRespaldo[0];
            A177TicketResponsableRamTxt = P00655_A177TicketResponsableRamTxt[0];
            n177TicketResponsableRamTxt = P00655_n177TicketResponsableRamTxt[0];
            A178TicketResponsableDiscoDuroTxt = P00655_A178TicketResponsableDiscoDuroTxt[0];
            n178TicketResponsableDiscoDuroTxt = P00655_n178TicketResponsableDiscoDuroTxt[0];
            A179TicketResponsableProcesadorTxt = P00655_A179TicketResponsableProcesadorTxt[0];
            n179TicketResponsableProcesadorTxt = P00655_n179TicketResponsableProcesadorTxt[0];
            A180TicketResponsableMaletinTxt = P00655_A180TicketResponsableMaletinTxt[0];
            n180TicketResponsableMaletinTxt = P00655_n180TicketResponsableMaletinTxt[0];
            A181TicketResponsableTonerCintaTxt = P00655_A181TicketResponsableTonerCintaTxt[0];
            n181TicketResponsableTonerCintaTxt = P00655_n181TicketResponsableTonerCintaTxt[0];
            A182TicketResponsableTarjetaVideoExtraTxt = P00655_A182TicketResponsableTarjetaVideoExtraTxt[0];
            n182TicketResponsableTarjetaVideoExtraTxt = P00655_n182TicketResponsableTarjetaVideoExtraTxt[0];
            A183TicketResponsableCargadorLaptopTxt = P00655_A183TicketResponsableCargadorLaptopTxt[0];
            n183TicketResponsableCargadorLaptopTxt = P00655_n183TicketResponsableCargadorLaptopTxt[0];
            A184TicketResponsableCDsDVDsTxt = P00655_A184TicketResponsableCDsDVDsTxt[0];
            n184TicketResponsableCDsDVDsTxt = P00655_n184TicketResponsableCDsDVDsTxt[0];
            A185TicketResponsableCableEspecialTxt = P00655_A185TicketResponsableCableEspecialTxt[0];
            n185TicketResponsableCableEspecialTxt = P00655_n185TicketResponsableCableEspecialTxt[0];
            A186TicketResponsableOtrosTallerTxt = P00655_A186TicketResponsableOtrosTallerTxt[0];
            n186TicketResponsableOtrosTallerTxt = P00655_n186TicketResponsableOtrosTallerTxt[0];
            A165TicketResponsableCerrado = P00655_A165TicketResponsableCerrado[0];
            n165TicketResponsableCerrado = P00655_n165TicketResponsableCerrado[0];
            A166TicketResponsablePendiente = P00655_A166TicketResponsablePendiente[0];
            n166TicketResponsablePendiente = P00655_n166TicketResponsablePendiente[0];
            A167TicketResponsablePasaTaller = P00655_A167TicketResponsablePasaTaller[0];
            n167TicketResponsablePasaTaller = P00655_n167TicketResponsablePasaTaller[0];
            A168TicketResponsableObservacion = P00655_A168TicketResponsableObservacion[0];
            n168TicketResponsableObservacion = P00655_n168TicketResponsableObservacion[0];
            A175TicketResponsableFechaResuelve = P00655_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = P00655_n175TicketResponsableFechaResuelve[0];
            A176TicketResponsableHoraResuelve = P00655_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = P00655_n176TicketResponsableHoraResuelve[0];
            A14TicketId = P00655_A14TicketId[0];
            A17EstadoTicketTecnicoId = AV46EstadoTicketTicketId;
            A145TicketResponsableInventarioSerie = AV9TicketResponsableInventarioSerie;
            n145TicketResponsableInventarioSerie = false;
            A146TicketResponsableInstalacion = AV10TicketResponsableInstalacion;
            n146TicketResponsableInstalacion = false;
            A147TicketResponsableConfiguracion = AV11TicketResponsableConfiguracion;
            n147TicketResponsableConfiguracion = false;
            A148TicketResponsableInternetRouter = AV12TicketResponsableInternetRouter;
            n148TicketResponsableInternetRouter = false;
            A149TicketResponsableFormateo = AV13TicketResponsableFormateo;
            n149TicketResponsableFormateo = false;
            A150TicketResponsableReparacion = AV14TicketResponsableReparacion;
            n150TicketResponsableReparacion = false;
            A151TicketResponsableLimpieza = AV15TicketResponsableLimpieza;
            n151TicketResponsableLimpieza = false;
            A152TicketResponsablePuntoRed = AV16TicketResponsablePuntoRed;
            n152TicketResponsablePuntoRed = false;
            A153TicketResponsableCambiosHardware = AV17TicketResponsableCambiosHardware;
            n153TicketResponsableCambiosHardware = false;
            A154TicketResponsableCopiasRespaldo = AV18TicketResponsableCopiasRespaldo;
            n154TicketResponsableCopiasRespaldo = false;
            A177TicketResponsableRamTxt = AV25TicketResponsableRamTxt;
            n177TicketResponsableRamTxt = false;
            A178TicketResponsableDiscoDuroTxt = AV26TicketResponsableDiscoDuroTxt;
            n178TicketResponsableDiscoDuroTxt = false;
            A179TicketResponsableProcesadorTxt = AV27TicketResponsableProcesadorTxt;
            n179TicketResponsableProcesadorTxt = false;
            A180TicketResponsableMaletinTxt = AV28TicketResponsableMaletinTxt;
            n180TicketResponsableMaletinTxt = false;
            A181TicketResponsableTonerCintaTxt = AV29TicketResponsableTonerCintaTxt;
            n181TicketResponsableTonerCintaTxt = false;
            A182TicketResponsableTarjetaVideoExtraTxt = AV30TicketResponsableTarjetaVideoExtraTxt;
            n182TicketResponsableTarjetaVideoExtraTxt = false;
            A183TicketResponsableCargadorLaptopTxt = AV31TicketResponsableCargadorLaptopTxt;
            n183TicketResponsableCargadorLaptopTxt = false;
            A184TicketResponsableCDsDVDsTxt = AV32TicketResponsableCDsDVDsTxt;
            n184TicketResponsableCDsDVDsTxt = false;
            A185TicketResponsableCableEspecialTxt = AV33TicketResponsableCableEspecialTxt;
            n185TicketResponsableCableEspecialTxt = false;
            A186TicketResponsableOtrosTallerTxt = AV34TicketResponsableOtrosTallerTxt;
            n186TicketResponsableOtrosTallerTxt = false;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A168TicketResponsableObservacion = AV22TicketResponsableObservacion;
            n168TicketResponsableObservacion = false;
            A175TicketResponsableFechaResuelve = DateTimeUtil.Today( context);
            n175TicketResponsableFechaResuelve = false;
            A176TicketResponsableHoraResuelve = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            n176TicketResponsableHoraResuelve = false;
            /* Using cursor P00656 */
            pr_default.execute(3, new Object[] {A17EstadoTicketTecnicoId, n145TicketResponsableInventarioSerie, A145TicketResponsableInventarioSerie, n146TicketResponsableInstalacion, A146TicketResponsableInstalacion, n147TicketResponsableConfiguracion, A147TicketResponsableConfiguracion, n148TicketResponsableInternetRouter, A148TicketResponsableInternetRouter, n149TicketResponsableFormateo, A149TicketResponsableFormateo, n150TicketResponsableReparacion, A150TicketResponsableReparacion, n151TicketResponsableLimpieza, A151TicketResponsableLimpieza, n152TicketResponsablePuntoRed, A152TicketResponsablePuntoRed, n153TicketResponsableCambiosHardware, A153TicketResponsableCambiosHardware, n154TicketResponsableCopiasRespaldo, A154TicketResponsableCopiasRespaldo, n177TicketResponsableRamTxt, A177TicketResponsableRamTxt, n178TicketResponsableDiscoDuroTxt, A178TicketResponsableDiscoDuroTxt, n179TicketResponsableProcesadorTxt, A179TicketResponsableProcesadorTxt, n180TicketResponsableMaletinTxt, A180TicketResponsableMaletinTxt, n181TicketResponsableTonerCintaTxt, A181TicketResponsableTonerCintaTxt, n182TicketResponsableTarjetaVideoExtraTxt, A182TicketResponsableTarjetaVideoExtraTxt, n183TicketResponsableCargadorLaptopTxt, A183TicketResponsableCargadorLaptopTxt, n184TicketResponsableCDsDVDsTxt, A184TicketResponsableCDsDVDsTxt, n185TicketResponsableCableEspecialTxt, A185TicketResponsableCableEspecialTxt, n186TicketResponsableOtrosTallerTxt, A186TicketResponsableOtrosTallerTxt, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, n168TicketResponsableObservacion, A168TicketResponsableObservacion, n175TicketResponsableFechaResuelve, A175TicketResponsableFechaResuelve, n176TicketResponsableHoraResuelve, A176TicketResponsableHoraResuelve, A14TicketId, A16TicketResponsableId});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Optimized UPDATE. */
         /* Using cursor P00657 */
         pr_default.execute(4, new Object[] {AV45TicketTecnicoResponsableId});
         pr_default.close(4);
         dsDefault.SmartCacheProvider.SetUpdated("Responsable");
         /* End optimized UPDATE. */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrreasignartecnico",pr_default);
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(0);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P00653_A40000GXC1 = new long[1] ;
         P00653_n40000GXC1 = new bool[] {false} ;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         Gx_emsg = "";
         P00655_A17EstadoTicketTecnicoId = new short[1] ;
         P00655_A198TicketTecnicoResponsableId = new short[1] ;
         P00655_A16TicketResponsableId = new long[1] ;
         P00655_A145TicketResponsableInventarioSerie = new string[] {""} ;
         P00655_n145TicketResponsableInventarioSerie = new bool[] {false} ;
         P00655_A146TicketResponsableInstalacion = new bool[] {false} ;
         P00655_n146TicketResponsableInstalacion = new bool[] {false} ;
         P00655_A147TicketResponsableConfiguracion = new bool[] {false} ;
         P00655_n147TicketResponsableConfiguracion = new bool[] {false} ;
         P00655_A148TicketResponsableInternetRouter = new bool[] {false} ;
         P00655_n148TicketResponsableInternetRouter = new bool[] {false} ;
         P00655_A149TicketResponsableFormateo = new bool[] {false} ;
         P00655_n149TicketResponsableFormateo = new bool[] {false} ;
         P00655_A150TicketResponsableReparacion = new bool[] {false} ;
         P00655_n150TicketResponsableReparacion = new bool[] {false} ;
         P00655_A151TicketResponsableLimpieza = new bool[] {false} ;
         P00655_n151TicketResponsableLimpieza = new bool[] {false} ;
         P00655_A152TicketResponsablePuntoRed = new bool[] {false} ;
         P00655_n152TicketResponsablePuntoRed = new bool[] {false} ;
         P00655_A153TicketResponsableCambiosHardware = new bool[] {false} ;
         P00655_n153TicketResponsableCambiosHardware = new bool[] {false} ;
         P00655_A154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         P00655_n154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         P00655_A177TicketResponsableRamTxt = new string[] {""} ;
         P00655_n177TicketResponsableRamTxt = new bool[] {false} ;
         P00655_A178TicketResponsableDiscoDuroTxt = new string[] {""} ;
         P00655_n178TicketResponsableDiscoDuroTxt = new bool[] {false} ;
         P00655_A179TicketResponsableProcesadorTxt = new string[] {""} ;
         P00655_n179TicketResponsableProcesadorTxt = new bool[] {false} ;
         P00655_A180TicketResponsableMaletinTxt = new string[] {""} ;
         P00655_n180TicketResponsableMaletinTxt = new bool[] {false} ;
         P00655_A181TicketResponsableTonerCintaTxt = new string[] {""} ;
         P00655_n181TicketResponsableTonerCintaTxt = new bool[] {false} ;
         P00655_A182TicketResponsableTarjetaVideoExtraTxt = new string[] {""} ;
         P00655_n182TicketResponsableTarjetaVideoExtraTxt = new bool[] {false} ;
         P00655_A183TicketResponsableCargadorLaptopTxt = new string[] {""} ;
         P00655_n183TicketResponsableCargadorLaptopTxt = new bool[] {false} ;
         P00655_A184TicketResponsableCDsDVDsTxt = new string[] {""} ;
         P00655_n184TicketResponsableCDsDVDsTxt = new bool[] {false} ;
         P00655_A185TicketResponsableCableEspecialTxt = new string[] {""} ;
         P00655_n185TicketResponsableCableEspecialTxt = new bool[] {false} ;
         P00655_A186TicketResponsableOtrosTallerTxt = new string[] {""} ;
         P00655_n186TicketResponsableOtrosTallerTxt = new bool[] {false} ;
         P00655_A165TicketResponsableCerrado = new bool[] {false} ;
         P00655_n165TicketResponsableCerrado = new bool[] {false} ;
         P00655_A166TicketResponsablePendiente = new bool[] {false} ;
         P00655_n166TicketResponsablePendiente = new bool[] {false} ;
         P00655_A167TicketResponsablePasaTaller = new bool[] {false} ;
         P00655_n167TicketResponsablePasaTaller = new bool[] {false} ;
         P00655_A168TicketResponsableObservacion = new string[] {""} ;
         P00655_n168TicketResponsableObservacion = new bool[] {false} ;
         P00655_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         P00655_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         P00655_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         P00655_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         P00655_A14TicketId = new long[1] ;
         A145TicketResponsableInventarioSerie = "";
         A177TicketResponsableRamTxt = "";
         A178TicketResponsableDiscoDuroTxt = "";
         A179TicketResponsableProcesadorTxt = "";
         A180TicketResponsableMaletinTxt = "";
         A181TicketResponsableTonerCintaTxt = "";
         A182TicketResponsableTarjetaVideoExtraTxt = "";
         A183TicketResponsableCargadorLaptopTxt = "";
         A184TicketResponsableCDsDVDsTxt = "";
         A185TicketResponsableCableEspecialTxt = "";
         A186TicketResponsableOtrosTallerTxt = "";
         A168TicketResponsableObservacion = "";
         A175TicketResponsableFechaResuelve = DateTime.MinValue;
         A176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrreasignartecnico__default(),
            new Object[][] {
                new Object[] {
               P00653_A40000GXC1, P00653_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               P00655_A17EstadoTicketTecnicoId, P00655_A198TicketTecnicoResponsableId, P00655_A16TicketResponsableId, P00655_A145TicketResponsableInventarioSerie, P00655_n145TicketResponsableInventarioSerie, P00655_A146TicketResponsableInstalacion, P00655_n146TicketResponsableInstalacion, P00655_A147TicketResponsableConfiguracion, P00655_n147TicketResponsableConfiguracion, P00655_A148TicketResponsableInternetRouter,
               P00655_n148TicketResponsableInternetRouter, P00655_A149TicketResponsableFormateo, P00655_n149TicketResponsableFormateo, P00655_A150TicketResponsableReparacion, P00655_n150TicketResponsableReparacion, P00655_A151TicketResponsableLimpieza, P00655_n151TicketResponsableLimpieza, P00655_A152TicketResponsablePuntoRed, P00655_n152TicketResponsablePuntoRed, P00655_A153TicketResponsableCambiosHardware,
               P00655_n153TicketResponsableCambiosHardware, P00655_A154TicketResponsableCopiasRespaldo, P00655_n154TicketResponsableCopiasRespaldo, P00655_A177TicketResponsableRamTxt, P00655_n177TicketResponsableRamTxt, P00655_A178TicketResponsableDiscoDuroTxt, P00655_n178TicketResponsableDiscoDuroTxt, P00655_A179TicketResponsableProcesadorTxt, P00655_n179TicketResponsableProcesadorTxt, P00655_A180TicketResponsableMaletinTxt,
               P00655_n180TicketResponsableMaletinTxt, P00655_A181TicketResponsableTonerCintaTxt, P00655_n181TicketResponsableTonerCintaTxt, P00655_A182TicketResponsableTarjetaVideoExtraTxt, P00655_n182TicketResponsableTarjetaVideoExtraTxt, P00655_A183TicketResponsableCargadorLaptopTxt, P00655_n183TicketResponsableCargadorLaptopTxt, P00655_A184TicketResponsableCDsDVDsTxt, P00655_n184TicketResponsableCDsDVDsTxt, P00655_A185TicketResponsableCableEspecialTxt,
               P00655_n185TicketResponsableCableEspecialTxt, P00655_A186TicketResponsableOtrosTallerTxt, P00655_n186TicketResponsableOtrosTallerTxt, P00655_A165TicketResponsableCerrado, P00655_n165TicketResponsableCerrado, P00655_A166TicketResponsablePendiente, P00655_n166TicketResponsablePendiente, P00655_A167TicketResponsablePasaTaller, P00655_n167TicketResponsablePasaTaller, P00655_A168TicketResponsableObservacion,
               P00655_n168TicketResponsableObservacion, P00655_A175TicketResponsableFechaResuelve, P00655_n175TicketResponsableFechaResuelve, P00655_A176TicketResponsableHoraResuelve, P00655_n176TicketResponsableHoraResuelve, P00655_A14TicketId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV23UsuarioId ;
      private short AV45TicketTecnicoResponsableId ;
      private short AV47ResponsableId ;
      private short AV46EstadoTicketTicketId ;
      private short A198TicketTecnicoResponsableId ;
      private short A17EstadoTicketTecnicoId ;
      private short A290EtapaDesarrolloId ;
      private int AV43categoria_tareaid_tipo_categoria ;
      private int AV44id_actividad_categoria ;
      private int AV37detalle_infotecid_unidad ;
      private int GX_INS8 ;
      private long AV24TicketId ;
      private long AV8TicketResponsableId ;
      private long A40000GXC1 ;
      private long AV49TicketResponsableSig ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime A176TicketResponsableHoraResuelve ;
      private DateTime AV39UsuarioFecha ;
      private DateTime A47TicketFechaResponsable ;
      private DateTime A175TicketResponsableFechaResuelve ;
      private bool AV10TicketResponsableInstalacion ;
      private bool AV11TicketResponsableConfiguracion ;
      private bool AV12TicketResponsableInternetRouter ;
      private bool AV13TicketResponsableFormateo ;
      private bool AV14TicketResponsableReparacion ;
      private bool AV15TicketResponsableLimpieza ;
      private bool AV16TicketResponsablePuntoRed ;
      private bool AV17TicketResponsableCambiosHardware ;
      private bool AV18TicketResponsableCopiasRespaldo ;
      private bool AV19TicketResponsableCerrado ;
      private bool AV20TicketResponsablePendiente ;
      private bool AV21TicketResponsablePasaTaller ;
      private bool n40000GXC1 ;
      private bool A165TicketResponsableCerrado ;
      private bool n165TicketResponsableCerrado ;
      private bool A166TicketResponsablePendiente ;
      private bool n166TicketResponsablePendiente ;
      private bool A167TicketResponsablePasaTaller ;
      private bool n167TicketResponsablePasaTaller ;
      private bool n290EtapaDesarrolloId ;
      private bool n145TicketResponsableInventarioSerie ;
      private bool A146TicketResponsableInstalacion ;
      private bool n146TicketResponsableInstalacion ;
      private bool A147TicketResponsableConfiguracion ;
      private bool n147TicketResponsableConfiguracion ;
      private bool A148TicketResponsableInternetRouter ;
      private bool n148TicketResponsableInternetRouter ;
      private bool A149TicketResponsableFormateo ;
      private bool n149TicketResponsableFormateo ;
      private bool A150TicketResponsableReparacion ;
      private bool n150TicketResponsableReparacion ;
      private bool A151TicketResponsableLimpieza ;
      private bool n151TicketResponsableLimpieza ;
      private bool A152TicketResponsablePuntoRed ;
      private bool n152TicketResponsablePuntoRed ;
      private bool A153TicketResponsableCambiosHardware ;
      private bool n153TicketResponsableCambiosHardware ;
      private bool A154TicketResponsableCopiasRespaldo ;
      private bool n154TicketResponsableCopiasRespaldo ;
      private bool n177TicketResponsableRamTxt ;
      private bool n178TicketResponsableDiscoDuroTxt ;
      private bool n179TicketResponsableProcesadorTxt ;
      private bool n180TicketResponsableMaletinTxt ;
      private bool n181TicketResponsableTonerCintaTxt ;
      private bool n182TicketResponsableTarjetaVideoExtraTxt ;
      private bool n183TicketResponsableCargadorLaptopTxt ;
      private bool n184TicketResponsableCDsDVDsTxt ;
      private bool n185TicketResponsableCableEspecialTxt ;
      private bool n186TicketResponsableOtrosTallerTxt ;
      private bool n168TicketResponsableObservacion ;
      private bool n175TicketResponsableFechaResuelve ;
      private bool n176TicketResponsableHoraResuelve ;
      private string AV9TicketResponsableInventarioSerie ;
      private string AV25TicketResponsableRamTxt ;
      private string AV26TicketResponsableDiscoDuroTxt ;
      private string AV27TicketResponsableProcesadorTxt ;
      private string AV28TicketResponsableMaletinTxt ;
      private string AV29TicketResponsableTonerCintaTxt ;
      private string AV30TicketResponsableTarjetaVideoExtraTxt ;
      private string AV31TicketResponsableCargadorLaptopTxt ;
      private string AV32TicketResponsableCDsDVDsTxt ;
      private string AV33TicketResponsableCableEspecialTxt ;
      private string AV34TicketResponsableOtrosTallerTxt ;
      private string AV22TicketResponsableObservacion ;
      private string AV41UsuarioNombre ;
      private string AV38UsuarioDepartamento ;
      private string AV42UsuarioEmail ;
      private string AV36detalle_tarea ;
      private string AV35prioridad ;
      private string A145TicketResponsableInventarioSerie ;
      private string A177TicketResponsableRamTxt ;
      private string A178TicketResponsableDiscoDuroTxt ;
      private string A179TicketResponsableProcesadorTxt ;
      private string A180TicketResponsableMaletinTxt ;
      private string A181TicketResponsableTonerCintaTxt ;
      private string A182TicketResponsableTarjetaVideoExtraTxt ;
      private string A183TicketResponsableCargadorLaptopTxt ;
      private string A184TicketResponsableCDsDVDsTxt ;
      private string A185TicketResponsableCableEspecialTxt ;
      private string A186TicketResponsableOtrosTallerTxt ;
      private string A168TicketResponsableObservacion ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00653_A40000GXC1 ;
      private bool[] P00653_n40000GXC1 ;
      private short[] P00655_A17EstadoTicketTecnicoId ;
      private short[] P00655_A198TicketTecnicoResponsableId ;
      private long[] P00655_A16TicketResponsableId ;
      private string[] P00655_A145TicketResponsableInventarioSerie ;
      private bool[] P00655_n145TicketResponsableInventarioSerie ;
      private bool[] P00655_A146TicketResponsableInstalacion ;
      private bool[] P00655_n146TicketResponsableInstalacion ;
      private bool[] P00655_A147TicketResponsableConfiguracion ;
      private bool[] P00655_n147TicketResponsableConfiguracion ;
      private bool[] P00655_A148TicketResponsableInternetRouter ;
      private bool[] P00655_n148TicketResponsableInternetRouter ;
      private bool[] P00655_A149TicketResponsableFormateo ;
      private bool[] P00655_n149TicketResponsableFormateo ;
      private bool[] P00655_A150TicketResponsableReparacion ;
      private bool[] P00655_n150TicketResponsableReparacion ;
      private bool[] P00655_A151TicketResponsableLimpieza ;
      private bool[] P00655_n151TicketResponsableLimpieza ;
      private bool[] P00655_A152TicketResponsablePuntoRed ;
      private bool[] P00655_n152TicketResponsablePuntoRed ;
      private bool[] P00655_A153TicketResponsableCambiosHardware ;
      private bool[] P00655_n153TicketResponsableCambiosHardware ;
      private bool[] P00655_A154TicketResponsableCopiasRespaldo ;
      private bool[] P00655_n154TicketResponsableCopiasRespaldo ;
      private string[] P00655_A177TicketResponsableRamTxt ;
      private bool[] P00655_n177TicketResponsableRamTxt ;
      private string[] P00655_A178TicketResponsableDiscoDuroTxt ;
      private bool[] P00655_n178TicketResponsableDiscoDuroTxt ;
      private string[] P00655_A179TicketResponsableProcesadorTxt ;
      private bool[] P00655_n179TicketResponsableProcesadorTxt ;
      private string[] P00655_A180TicketResponsableMaletinTxt ;
      private bool[] P00655_n180TicketResponsableMaletinTxt ;
      private string[] P00655_A181TicketResponsableTonerCintaTxt ;
      private bool[] P00655_n181TicketResponsableTonerCintaTxt ;
      private string[] P00655_A182TicketResponsableTarjetaVideoExtraTxt ;
      private bool[] P00655_n182TicketResponsableTarjetaVideoExtraTxt ;
      private string[] P00655_A183TicketResponsableCargadorLaptopTxt ;
      private bool[] P00655_n183TicketResponsableCargadorLaptopTxt ;
      private string[] P00655_A184TicketResponsableCDsDVDsTxt ;
      private bool[] P00655_n184TicketResponsableCDsDVDsTxt ;
      private string[] P00655_A185TicketResponsableCableEspecialTxt ;
      private bool[] P00655_n185TicketResponsableCableEspecialTxt ;
      private string[] P00655_A186TicketResponsableOtrosTallerTxt ;
      private bool[] P00655_n186TicketResponsableOtrosTallerTxt ;
      private bool[] P00655_A165TicketResponsableCerrado ;
      private bool[] P00655_n165TicketResponsableCerrado ;
      private bool[] P00655_A166TicketResponsablePendiente ;
      private bool[] P00655_n166TicketResponsablePendiente ;
      private bool[] P00655_A167TicketResponsablePasaTaller ;
      private bool[] P00655_n167TicketResponsablePasaTaller ;
      private string[] P00655_A168TicketResponsableObservacion ;
      private bool[] P00655_n168TicketResponsableObservacion ;
      private DateTime[] P00655_A175TicketResponsableFechaResuelve ;
      private bool[] P00655_n175TicketResponsableFechaResuelve ;
      private DateTime[] P00655_A176TicketResponsableHoraResuelve ;
      private bool[] P00655_n176TicketResponsableHoraResuelve ;
      private long[] P00655_A14TicketId ;
   }

   public class pcrreasignartecnico__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00653;
          prmP00653 = new Object[] {
          };
          Object[] prmP00654;
          prmP00654 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketResponsableCerrado",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsablePendiente",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsablePasaTaller",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmP00655;
          prmP00655 = new Object[] {
          new ParDef("@AV8TicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV45TicketTecnicoResponsableId",GXType.Int16,4,0)
          };
          Object[] prmP00656;
          prmP00656 = new Object[] {
          new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@TicketResponsableInventarioSerie",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@TicketResponsableInstalacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableConfiguracion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableInternetRouter",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableFormateo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableReparacion",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableLimpieza",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsablePuntoRed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableCambiosHardware",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableCopiasRespaldo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableRamTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableDiscoDuroTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableProcesadorTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableMaletinTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableTonerCintaTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableTarjetaVideoExtraTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableCargadorLaptopTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableCDsDVDsTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableCableEspecialTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableOtrosTallerTxt",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TicketResponsableCerrado",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsablePendiente",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsablePasaTaller",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@TicketResponsableObservacion",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@TicketResponsableFechaResuelve",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@TicketResponsableHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
          };
          string cmdBufferP00656;
          cmdBufferP00656=" UPDATE [TicketResponsable] SET [EstadoTicketTecnicoId]=@EstadoTicketTecnicoId, [TicketResponsableInventarioSerie]=@TicketResponsableInventarioSerie, [TicketResponsableInstalacion]=@TicketResponsableInstalacion, [TicketResponsableConfiguracion]=@TicketResponsableConfiguracion, [TicketResponsableInternetRouter]=@TicketResponsableInternetRouter, [TicketResponsableFormateo]=@TicketResponsableFormateo, [TicketResponsableReparacion]=@TicketResponsableReparacion, [TicketResponsableLimpieza]=@TicketResponsableLimpieza, [TicketResponsablePuntoRed]=@TicketResponsablePuntoRed, [TicketResponsableCambiosHardware]=@TicketResponsableCambiosHardware, [TicketResponsableCopiasRespaldo]=@TicketResponsableCopiasRespaldo, [TicketResponsableRamTxt]=@TicketResponsableRamTxt, [TicketResponsableDiscoDuroTxt]=@TicketResponsableDiscoDuroTxt, [TicketResponsableProcesadorTxt]=@TicketResponsableProcesadorTxt, [TicketResponsableMaletinTxt]=@TicketResponsableMaletinTxt, [TicketResponsableTonerCintaTxt]=@TicketResponsableTonerCintaTxt, [TicketResponsableTarjetaVideoExtraTxt]=@TicketResponsableTarjetaVideoExtraTxt, [TicketResponsableCargadorLaptopTxt]=@TicketResponsableCargadorLaptopTxt, [TicketResponsableCDsDVDsTxt]=@TicketResponsableCDsDVDsTxt, [TicketResponsableCableEspecialTxt]=@TicketResponsableCableEspecialTxt, [TicketResponsableOtrosTallerTxt]=@TicketResponsableOtrosTallerTxt, [TicketResponsableCerrado]=@TicketResponsableCerrado, [TicketResponsablePendiente]=@TicketResponsablePendiente, [TicketResponsablePasaTaller]=@TicketResponsablePasaTaller, [TicketResponsableObservacion]=@TicketResponsableObservacion, [TicketResponsableFechaResuelve]=@TicketResponsableFechaResuelve, [TicketResponsableHoraResuelve]=@TicketResponsableHoraResuelve  WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId "
          + "" ;
          Object[] prmP00657;
          prmP00657 = new Object[] {
          new ParDef("@AV45TicketTecnicoResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00653", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00653,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00654", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00654)
             ,new CursorDef("P00655", "SELECT [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [TicketResponsableId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketId] FROM [TicketResponsable] WITH (UPDLOCK) WHERE ([TicketResponsableId] = @AV8TicketResponsableId) AND ([TicketTecnicoResponsableId] = @AV45TicketTecnicoResponsableId) AND ([EstadoTicketTecnicoId] = 3) ORDER BY [TicketId], [TicketResponsableId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00655,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00656", cmdBufferP00656, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00656)
             ,new CursorDef("P00657", "UPDATE [Responsable] SET [EstadoResponsableId]=2  WHERE [ResponsableId] = @AV45TicketTecnicoResponsableId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00657)
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((bool[]) buf[7])[0] = rslt.getBool(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((bool[]) buf[13])[0] = rslt.getBool(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((bool[]) buf[15])[0] = rslt.getBool(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((bool[]) buf[17])[0] = rslt.getBool(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((bool[]) buf[19])[0] = rslt.getBool(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((bool[]) buf[21])[0] = rslt.getBool(13);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((string[]) buf[23])[0] = rslt.getVarchar(14);
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                ((string[]) buf[25])[0] = rslt.getVarchar(15);
                ((bool[]) buf[26])[0] = rslt.wasNull(15);
                ((string[]) buf[27])[0] = rslt.getVarchar(16);
                ((bool[]) buf[28])[0] = rslt.wasNull(16);
                ((string[]) buf[29])[0] = rslt.getVarchar(17);
                ((bool[]) buf[30])[0] = rslt.wasNull(17);
                ((string[]) buf[31])[0] = rslt.getVarchar(18);
                ((bool[]) buf[32])[0] = rslt.wasNull(18);
                ((string[]) buf[33])[0] = rslt.getVarchar(19);
                ((bool[]) buf[34])[0] = rslt.wasNull(19);
                ((string[]) buf[35])[0] = rslt.getVarchar(20);
                ((bool[]) buf[36])[0] = rslt.wasNull(20);
                ((string[]) buf[37])[0] = rslt.getVarchar(21);
                ((bool[]) buf[38])[0] = rslt.wasNull(21);
                ((string[]) buf[39])[0] = rslt.getVarchar(22);
                ((bool[]) buf[40])[0] = rslt.wasNull(22);
                ((string[]) buf[41])[0] = rslt.getVarchar(23);
                ((bool[]) buf[42])[0] = rslt.wasNull(23);
                ((bool[]) buf[43])[0] = rslt.getBool(24);
                ((bool[]) buf[44])[0] = rslt.wasNull(24);
                ((bool[]) buf[45])[0] = rslt.getBool(25);
                ((bool[]) buf[46])[0] = rslt.wasNull(25);
                ((bool[]) buf[47])[0] = rslt.getBool(26);
                ((bool[]) buf[48])[0] = rslt.wasNull(26);
                ((string[]) buf[49])[0] = rslt.getVarchar(27);
                ((bool[]) buf[50])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[51])[0] = rslt.getGXDate(28);
                ((bool[]) buf[52])[0] = rslt.wasNull(28);
                ((DateTime[]) buf[53])[0] = rslt.getGXDateTime(29);
                ((bool[]) buf[54])[0] = rslt.wasNull(29);
                ((long[]) buf[55])[0] = rslt.getLong(30);
                return;
       }
    }

 }

}
