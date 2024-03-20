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
   public class pcrregistrardesarrollo : GXProcedure
   {
      public pcrregistrardesarrollo( )
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

      public pcrregistrardesarrollo( IGxContext context )
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
                           string aP4_TicketResponsableInventarioSerie ,
                           bool aP5_TicketResponsableInstalacion ,
                           bool aP6_TicketResponsableConfiguracion ,
                           bool aP7_TicketResponsableInternetRouter ,
                           bool aP8_TicketResponsableFormateo ,
                           bool aP9_TicketResponsableReparacion ,
                           bool aP10_TicketResponsableLimpieza ,
                           bool aP11_TicketResponsablePuntoRed ,
                           bool aP12_TicketResponsableCambiosHardware ,
                           bool aP13_TicketResponsableCopiasRespaldo ,
                           string aP14_TicketResponsableRamTxt ,
                           string aP15_TicketResponsableDiscoDuroTxt ,
                           string aP16_TicketResponsableProcesadorTxt ,
                           string aP17_TicketResponsableMaletinTxt ,
                           string aP18_TicketResponsableTonerCintaTxt ,
                           string aP19_TicketResponsableTarjetaVideoExtraTxt ,
                           string aP20_TicketResponsableCargadorLaptopTxt ,
                           string aP21_TicketResponsableCDsDVDsTxt ,
                           string aP22_TicketResponsableCableEspecialTxt ,
                           string aP23_TicketResponsableOtrosTallerTxt ,
                           bool aP24_TicketResponsableCerrado ,
                           bool aP25_TicketResponsablePendiente ,
                           bool aP26_TicketResponsablePasaTaller ,
                           string aP27_TicketResponsableObservacion ,
                           int aP28_categoria_tareaid_tipo_categoria ,
                           int aP29_id_actividad_categoria ,
                           string aP30_UsuarioNombre ,
                           string aP31_UsuarioDepartamento ,
                           string aP32_UsuarioEmail ,
                           int aP33_detalle_infotecid_unidad ,
                           string aP34_detalle_tarea ,
                           string aP35_prioridad ,
                           DateTime aP36_UsuarioFecha ,
                           short aP37_EstadoTicketTicketId ,
                           short aP38_EtapaDesarrolloId )
      {
         this.AV24TicketId = aP0_TicketId;
         this.AV23UsuarioId = aP1_UsuarioId;
         this.AV8TicketResponsableId = aP2_TicketResponsableId;
         this.AV45TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV9TicketResponsableInventarioSerie = aP4_TicketResponsableInventarioSerie;
         this.AV10TicketResponsableInstalacion = aP5_TicketResponsableInstalacion;
         this.AV11TicketResponsableConfiguracion = aP6_TicketResponsableConfiguracion;
         this.AV12TicketResponsableInternetRouter = aP7_TicketResponsableInternetRouter;
         this.AV13TicketResponsableFormateo = aP8_TicketResponsableFormateo;
         this.AV14TicketResponsableReparacion = aP9_TicketResponsableReparacion;
         this.AV15TicketResponsableLimpieza = aP10_TicketResponsableLimpieza;
         this.AV16TicketResponsablePuntoRed = aP11_TicketResponsablePuntoRed;
         this.AV17TicketResponsableCambiosHardware = aP12_TicketResponsableCambiosHardware;
         this.AV18TicketResponsableCopiasRespaldo = aP13_TicketResponsableCopiasRespaldo;
         this.AV25TicketResponsableRamTxt = aP14_TicketResponsableRamTxt;
         this.AV26TicketResponsableDiscoDuroTxt = aP15_TicketResponsableDiscoDuroTxt;
         this.AV27TicketResponsableProcesadorTxt = aP16_TicketResponsableProcesadorTxt;
         this.AV28TicketResponsableMaletinTxt = aP17_TicketResponsableMaletinTxt;
         this.AV29TicketResponsableTonerCintaTxt = aP18_TicketResponsableTonerCintaTxt;
         this.AV30TicketResponsableTarjetaVideoExtraTxt = aP19_TicketResponsableTarjetaVideoExtraTxt;
         this.AV31TicketResponsableCargadorLaptopTxt = aP20_TicketResponsableCargadorLaptopTxt;
         this.AV32TicketResponsableCDsDVDsTxt = aP21_TicketResponsableCDsDVDsTxt;
         this.AV33TicketResponsableCableEspecialTxt = aP22_TicketResponsableCableEspecialTxt;
         this.AV34TicketResponsableOtrosTallerTxt = aP23_TicketResponsableOtrosTallerTxt;
         this.AV19TicketResponsableCerrado = aP24_TicketResponsableCerrado;
         this.AV20TicketResponsablePendiente = aP25_TicketResponsablePendiente;
         this.AV21TicketResponsablePasaTaller = aP26_TicketResponsablePasaTaller;
         this.AV22TicketResponsableObservacion = aP27_TicketResponsableObservacion;
         this.AV43categoria_tareaid_tipo_categoria = aP28_categoria_tareaid_tipo_categoria;
         this.AV44id_actividad_categoria = aP29_id_actividad_categoria;
         this.AV41UsuarioNombre = aP30_UsuarioNombre;
         this.AV38UsuarioDepartamento = aP31_UsuarioDepartamento;
         this.AV42UsuarioEmail = aP32_UsuarioEmail;
         this.AV37detalle_infotecid_unidad = aP33_detalle_infotecid_unidad;
         this.AV36detalle_tarea = aP34_detalle_tarea;
         this.AV35prioridad = aP35_prioridad;
         this.AV39UsuarioFecha = aP36_UsuarioFecha;
         this.AV46EstadoTicketTicketId = aP37_EstadoTicketTicketId;
         this.AV47EtapaDesarrolloId = aP38_EtapaDesarrolloId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_TicketId ,
                                 short aP1_UsuarioId ,
                                 long aP2_TicketResponsableId ,
                                 short aP3_TicketTecnicoResponsableId ,
                                 string aP4_TicketResponsableInventarioSerie ,
                                 bool aP5_TicketResponsableInstalacion ,
                                 bool aP6_TicketResponsableConfiguracion ,
                                 bool aP7_TicketResponsableInternetRouter ,
                                 bool aP8_TicketResponsableFormateo ,
                                 bool aP9_TicketResponsableReparacion ,
                                 bool aP10_TicketResponsableLimpieza ,
                                 bool aP11_TicketResponsablePuntoRed ,
                                 bool aP12_TicketResponsableCambiosHardware ,
                                 bool aP13_TicketResponsableCopiasRespaldo ,
                                 string aP14_TicketResponsableRamTxt ,
                                 string aP15_TicketResponsableDiscoDuroTxt ,
                                 string aP16_TicketResponsableProcesadorTxt ,
                                 string aP17_TicketResponsableMaletinTxt ,
                                 string aP18_TicketResponsableTonerCintaTxt ,
                                 string aP19_TicketResponsableTarjetaVideoExtraTxt ,
                                 string aP20_TicketResponsableCargadorLaptopTxt ,
                                 string aP21_TicketResponsableCDsDVDsTxt ,
                                 string aP22_TicketResponsableCableEspecialTxt ,
                                 string aP23_TicketResponsableOtrosTallerTxt ,
                                 bool aP24_TicketResponsableCerrado ,
                                 bool aP25_TicketResponsablePendiente ,
                                 bool aP26_TicketResponsablePasaTaller ,
                                 string aP27_TicketResponsableObservacion ,
                                 int aP28_categoria_tareaid_tipo_categoria ,
                                 int aP29_id_actividad_categoria ,
                                 string aP30_UsuarioNombre ,
                                 string aP31_UsuarioDepartamento ,
                                 string aP32_UsuarioEmail ,
                                 int aP33_detalle_infotecid_unidad ,
                                 string aP34_detalle_tarea ,
                                 string aP35_prioridad ,
                                 DateTime aP36_UsuarioFecha ,
                                 short aP37_EstadoTicketTicketId ,
                                 short aP38_EtapaDesarrolloId )
      {
         pcrregistrardesarrollo objpcrregistrardesarrollo;
         objpcrregistrardesarrollo = new pcrregistrardesarrollo();
         objpcrregistrardesarrollo.AV24TicketId = aP0_TicketId;
         objpcrregistrardesarrollo.AV23UsuarioId = aP1_UsuarioId;
         objpcrregistrardesarrollo.AV8TicketResponsableId = aP2_TicketResponsableId;
         objpcrregistrardesarrollo.AV45TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         objpcrregistrardesarrollo.AV9TicketResponsableInventarioSerie = aP4_TicketResponsableInventarioSerie;
         objpcrregistrardesarrollo.AV10TicketResponsableInstalacion = aP5_TicketResponsableInstalacion;
         objpcrregistrardesarrollo.AV11TicketResponsableConfiguracion = aP6_TicketResponsableConfiguracion;
         objpcrregistrardesarrollo.AV12TicketResponsableInternetRouter = aP7_TicketResponsableInternetRouter;
         objpcrregistrardesarrollo.AV13TicketResponsableFormateo = aP8_TicketResponsableFormateo;
         objpcrregistrardesarrollo.AV14TicketResponsableReparacion = aP9_TicketResponsableReparacion;
         objpcrregistrardesarrollo.AV15TicketResponsableLimpieza = aP10_TicketResponsableLimpieza;
         objpcrregistrardesarrollo.AV16TicketResponsablePuntoRed = aP11_TicketResponsablePuntoRed;
         objpcrregistrardesarrollo.AV17TicketResponsableCambiosHardware = aP12_TicketResponsableCambiosHardware;
         objpcrregistrardesarrollo.AV18TicketResponsableCopiasRespaldo = aP13_TicketResponsableCopiasRespaldo;
         objpcrregistrardesarrollo.AV25TicketResponsableRamTxt = aP14_TicketResponsableRamTxt;
         objpcrregistrardesarrollo.AV26TicketResponsableDiscoDuroTxt = aP15_TicketResponsableDiscoDuroTxt;
         objpcrregistrardesarrollo.AV27TicketResponsableProcesadorTxt = aP16_TicketResponsableProcesadorTxt;
         objpcrregistrardesarrollo.AV28TicketResponsableMaletinTxt = aP17_TicketResponsableMaletinTxt;
         objpcrregistrardesarrollo.AV29TicketResponsableTonerCintaTxt = aP18_TicketResponsableTonerCintaTxt;
         objpcrregistrardesarrollo.AV30TicketResponsableTarjetaVideoExtraTxt = aP19_TicketResponsableTarjetaVideoExtraTxt;
         objpcrregistrardesarrollo.AV31TicketResponsableCargadorLaptopTxt = aP20_TicketResponsableCargadorLaptopTxt;
         objpcrregistrardesarrollo.AV32TicketResponsableCDsDVDsTxt = aP21_TicketResponsableCDsDVDsTxt;
         objpcrregistrardesarrollo.AV33TicketResponsableCableEspecialTxt = aP22_TicketResponsableCableEspecialTxt;
         objpcrregistrardesarrollo.AV34TicketResponsableOtrosTallerTxt = aP23_TicketResponsableOtrosTallerTxt;
         objpcrregistrardesarrollo.AV19TicketResponsableCerrado = aP24_TicketResponsableCerrado;
         objpcrregistrardesarrollo.AV20TicketResponsablePendiente = aP25_TicketResponsablePendiente;
         objpcrregistrardesarrollo.AV21TicketResponsablePasaTaller = aP26_TicketResponsablePasaTaller;
         objpcrregistrardesarrollo.AV22TicketResponsableObservacion = aP27_TicketResponsableObservacion;
         objpcrregistrardesarrollo.AV43categoria_tareaid_tipo_categoria = aP28_categoria_tareaid_tipo_categoria;
         objpcrregistrardesarrollo.AV44id_actividad_categoria = aP29_id_actividad_categoria;
         objpcrregistrardesarrollo.AV41UsuarioNombre = aP30_UsuarioNombre;
         objpcrregistrardesarrollo.AV38UsuarioDepartamento = aP31_UsuarioDepartamento;
         objpcrregistrardesarrollo.AV42UsuarioEmail = aP32_UsuarioEmail;
         objpcrregistrardesarrollo.AV37detalle_infotecid_unidad = aP33_detalle_infotecid_unidad;
         objpcrregistrardesarrollo.AV36detalle_tarea = aP34_detalle_tarea;
         objpcrregistrardesarrollo.AV35prioridad = aP35_prioridad;
         objpcrregistrardesarrollo.AV39UsuarioFecha = aP36_UsuarioFecha;
         objpcrregistrardesarrollo.AV46EstadoTicketTicketId = aP37_EstadoTicketTicketId;
         objpcrregistrardesarrollo.AV47EtapaDesarrolloId = aP38_EtapaDesarrolloId;
         objpcrregistrardesarrollo.context.SetSubmitInitialConfig(context);
         objpcrregistrardesarrollo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrregistrardesarrollo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrregistrardesarrollo)stateInfo).executePrivate();
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
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {AV8TicketResponsableId, AV45TicketTecnicoResponsableId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A17EstadoTicketTecnicoId = P00752_A17EstadoTicketTecnicoId[0];
            A198TicketTecnicoResponsableId = P00752_A198TicketTecnicoResponsableId[0];
            A16TicketResponsableId = P00752_A16TicketResponsableId[0];
            A145TicketResponsableInventarioSerie = P00752_A145TicketResponsableInventarioSerie[0];
            n145TicketResponsableInventarioSerie = P00752_n145TicketResponsableInventarioSerie[0];
            A146TicketResponsableInstalacion = P00752_A146TicketResponsableInstalacion[0];
            n146TicketResponsableInstalacion = P00752_n146TicketResponsableInstalacion[0];
            A147TicketResponsableConfiguracion = P00752_A147TicketResponsableConfiguracion[0];
            n147TicketResponsableConfiguracion = P00752_n147TicketResponsableConfiguracion[0];
            A148TicketResponsableInternetRouter = P00752_A148TicketResponsableInternetRouter[0];
            n148TicketResponsableInternetRouter = P00752_n148TicketResponsableInternetRouter[0];
            A149TicketResponsableFormateo = P00752_A149TicketResponsableFormateo[0];
            n149TicketResponsableFormateo = P00752_n149TicketResponsableFormateo[0];
            A150TicketResponsableReparacion = P00752_A150TicketResponsableReparacion[0];
            n150TicketResponsableReparacion = P00752_n150TicketResponsableReparacion[0];
            A151TicketResponsableLimpieza = P00752_A151TicketResponsableLimpieza[0];
            n151TicketResponsableLimpieza = P00752_n151TicketResponsableLimpieza[0];
            A152TicketResponsablePuntoRed = P00752_A152TicketResponsablePuntoRed[0];
            n152TicketResponsablePuntoRed = P00752_n152TicketResponsablePuntoRed[0];
            A153TicketResponsableCambiosHardware = P00752_A153TicketResponsableCambiosHardware[0];
            n153TicketResponsableCambiosHardware = P00752_n153TicketResponsableCambiosHardware[0];
            A154TicketResponsableCopiasRespaldo = P00752_A154TicketResponsableCopiasRespaldo[0];
            n154TicketResponsableCopiasRespaldo = P00752_n154TicketResponsableCopiasRespaldo[0];
            A177TicketResponsableRamTxt = P00752_A177TicketResponsableRamTxt[0];
            n177TicketResponsableRamTxt = P00752_n177TicketResponsableRamTxt[0];
            A178TicketResponsableDiscoDuroTxt = P00752_A178TicketResponsableDiscoDuroTxt[0];
            n178TicketResponsableDiscoDuroTxt = P00752_n178TicketResponsableDiscoDuroTxt[0];
            A179TicketResponsableProcesadorTxt = P00752_A179TicketResponsableProcesadorTxt[0];
            n179TicketResponsableProcesadorTxt = P00752_n179TicketResponsableProcesadorTxt[0];
            A180TicketResponsableMaletinTxt = P00752_A180TicketResponsableMaletinTxt[0];
            n180TicketResponsableMaletinTxt = P00752_n180TicketResponsableMaletinTxt[0];
            A181TicketResponsableTonerCintaTxt = P00752_A181TicketResponsableTonerCintaTxt[0];
            n181TicketResponsableTonerCintaTxt = P00752_n181TicketResponsableTonerCintaTxt[0];
            A182TicketResponsableTarjetaVideoExtraTxt = P00752_A182TicketResponsableTarjetaVideoExtraTxt[0];
            n182TicketResponsableTarjetaVideoExtraTxt = P00752_n182TicketResponsableTarjetaVideoExtraTxt[0];
            A183TicketResponsableCargadorLaptopTxt = P00752_A183TicketResponsableCargadorLaptopTxt[0];
            n183TicketResponsableCargadorLaptopTxt = P00752_n183TicketResponsableCargadorLaptopTxt[0];
            A184TicketResponsableCDsDVDsTxt = P00752_A184TicketResponsableCDsDVDsTxt[0];
            n184TicketResponsableCDsDVDsTxt = P00752_n184TicketResponsableCDsDVDsTxt[0];
            A185TicketResponsableCableEspecialTxt = P00752_A185TicketResponsableCableEspecialTxt[0];
            n185TicketResponsableCableEspecialTxt = P00752_n185TicketResponsableCableEspecialTxt[0];
            A186TicketResponsableOtrosTallerTxt = P00752_A186TicketResponsableOtrosTallerTxt[0];
            n186TicketResponsableOtrosTallerTxt = P00752_n186TicketResponsableOtrosTallerTxt[0];
            A165TicketResponsableCerrado = P00752_A165TicketResponsableCerrado[0];
            n165TicketResponsableCerrado = P00752_n165TicketResponsableCerrado[0];
            A166TicketResponsablePendiente = P00752_A166TicketResponsablePendiente[0];
            n166TicketResponsablePendiente = P00752_n166TicketResponsablePendiente[0];
            A167TicketResponsablePasaTaller = P00752_A167TicketResponsablePasaTaller[0];
            n167TicketResponsablePasaTaller = P00752_n167TicketResponsablePasaTaller[0];
            A168TicketResponsableObservacion = P00752_A168TicketResponsableObservacion[0];
            n168TicketResponsableObservacion = P00752_n168TicketResponsableObservacion[0];
            A175TicketResponsableFechaResuelve = P00752_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = P00752_n175TicketResponsableFechaResuelve[0];
            A176TicketResponsableHoraResuelve = P00752_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = P00752_n176TicketResponsableHoraResuelve[0];
            A14TicketId = P00752_A14TicketId[0];
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
            /* Using cursor P00753 */
            pr_default.execute(1, new Object[] {A17EstadoTicketTecnicoId, n145TicketResponsableInventarioSerie, A145TicketResponsableInventarioSerie, n146TicketResponsableInstalacion, A146TicketResponsableInstalacion, n147TicketResponsableConfiguracion, A147TicketResponsableConfiguracion, n148TicketResponsableInternetRouter, A148TicketResponsableInternetRouter, n149TicketResponsableFormateo, A149TicketResponsableFormateo, n150TicketResponsableReparacion, A150TicketResponsableReparacion, n151TicketResponsableLimpieza, A151TicketResponsableLimpieza, n152TicketResponsablePuntoRed, A152TicketResponsablePuntoRed, n153TicketResponsableCambiosHardware, A153TicketResponsableCambiosHardware, n154TicketResponsableCopiasRespaldo, A154TicketResponsableCopiasRespaldo, n177TicketResponsableRamTxt, A177TicketResponsableRamTxt, n178TicketResponsableDiscoDuroTxt, A178TicketResponsableDiscoDuroTxt, n179TicketResponsableProcesadorTxt, A179TicketResponsableProcesadorTxt, n180TicketResponsableMaletinTxt, A180TicketResponsableMaletinTxt, n181TicketResponsableTonerCintaTxt, A181TicketResponsableTonerCintaTxt, n182TicketResponsableTarjetaVideoExtraTxt, A182TicketResponsableTarjetaVideoExtraTxt, n183TicketResponsableCargadorLaptopTxt, A183TicketResponsableCargadorLaptopTxt, n184TicketResponsableCDsDVDsTxt, A184TicketResponsableCDsDVDsTxt, n185TicketResponsableCableEspecialTxt, A185TicketResponsableCableEspecialTxt, n186TicketResponsableOtrosTallerTxt, A186TicketResponsableOtrosTallerTxt, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, n168TicketResponsableObservacion, A168TicketResponsableObservacion, n175TicketResponsableFechaResuelve, A175TicketResponsableFechaResuelve, n176TicketResponsableHoraResuelve, A176TicketResponsableHoraResuelve, A14TicketId, A16TicketResponsableId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /*
            INSERT RECORD ON TABLE DETALLE_INFOTEC

         */
         A239nombre_emp = AV40WebSession.Get("NombreResponsable");
         n239nombre_emp = false;
         A240cargo_emp = AV40WebSession.Get("CargoResponsable");
         n240cargo_emp = false;
         A241fecha_registro = DateTimeUtil.Today( context);
         n241fecha_registro = false;
         A243estatus = "SOLICITADO";
         n243estatus = false;
         A244trabajo = "ABIERTO";
         n244trabajo = false;
         A245nombre_usuario = AV41UsuarioNombre;
         n245nombre_usuario = false;
         A246depto_usuario = AV38UsuarioDepartamento;
         n246depto_usuario = false;
         A247correo_usuario = AV42UsuarioEmail;
         n247correo_usuario = false;
         A248detalle_infotecid_unidad = AV37detalle_infotecid_unidad;
         n248detalle_infotecid_unidad = false;
         A249id_categoria = AV43categoria_tareaid_tipo_categoria;
         n249id_categoria = false;
         A250id_actividad = AV44id_actividad_categoria;
         n250id_actividad = false;
         A251detalle_tarea = AV36detalle_tarea;
         n251detalle_tarea = false;
         A252prioridad = AV35prioridad;
         n252prioridad = false;
         A253observaciones = AV22TicketResponsableObservacion;
         n253observaciones = false;
         A254fecha_solicitud = context.localUtil.DToC( AV39UsuarioFecha, 2, "/");
         n254fecha_solicitud = false;
         /* Using cursor P00754 */
         pr_datastore1.execute(0, new Object[] {n239nombre_emp, A239nombre_emp, n240cargo_emp, A240cargo_emp, n241fecha_registro, A241fecha_registro, n243estatus, A243estatus, n244trabajo, A244trabajo, n245nombre_usuario, A245nombre_usuario, n246depto_usuario, A246depto_usuario, n247correo_usuario, A247correo_usuario, n248detalle_infotecid_unidad, A248detalle_infotecid_unidad, n249id_categoria, A249id_categoria, n250id_actividad, A250id_actividad, n251detalle_tarea, A251detalle_tarea, n252prioridad, A252prioridad, n253observaciones, A253observaciones, n254fecha_solicitud, A254fecha_solicitud});
         A238correlativo = P00754_A238correlativo[0];
         pr_datastore1.close(0);
         dsDataStore1.SmartCacheProvider.SetUpdated("DETALLE_INFOTEC");
         if ( (pr_datastore1.getStatus(0) == 1) )
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
         if ( AV47EtapaDesarrolloId == 1 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P00756 */
            pr_default.execute(2);
            if ( (pr_default.getStatus(2) != 101) )
            {
               A40000GXC1 = P00756_A40000GXC1[0];
               n40000GXC1 = P00756_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(2);
            AV51Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV51Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A290EtapaDesarrolloId = 2;
            n290EtapaDesarrolloId = false;
            /* Using cursor P00757 */
            pr_default.execute(3, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(3) == 1) )
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
         }
         if ( AV47EtapaDesarrolloId == 2 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P00759 */
            pr_default.execute(4);
            if ( (pr_default.getStatus(4) != 101) )
            {
               A40000GXC1 = P00759_A40000GXC1[0];
               n40000GXC1 = P00759_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(4);
            AV51Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV51Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A290EtapaDesarrolloId = 3;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007510 */
            pr_default.execute(5, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(5);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(5) == 1) )
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
         }
         if ( AV47EtapaDesarrolloId == 3 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007512 */
            pr_default.execute(6);
            if ( (pr_default.getStatus(6) != 101) )
            {
               A40000GXC1 = P007512_A40000GXC1[0];
               n40000GXC1 = P007512_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(6);
            AV51Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV51Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A290EtapaDesarrolloId = 4;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007513 */
            pr_default.execute(7, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(7);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(7) == 1) )
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
         }
         if ( AV47EtapaDesarrolloId == 4 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007515 */
            pr_default.execute(8);
            if ( (pr_default.getStatus(8) != 101) )
            {
               A40000GXC1 = P007515_A40000GXC1[0];
               n40000GXC1 = P007515_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(8);
            AV51Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV51Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A290EtapaDesarrolloId = 5;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007516 */
            pr_default.execute(9, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(9);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(9) == 1) )
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
         }
         if ( AV47EtapaDesarrolloId == 5 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007518 */
            pr_default.execute(10);
            if ( (pr_default.getStatus(10) != 101) )
            {
               A40000GXC1 = P007518_A40000GXC1[0];
               n40000GXC1 = P007518_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(10);
            AV51Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV51Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A290EtapaDesarrolloId = 6;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007519 */
            pr_default.execute(11, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(11);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(11) == 1) )
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
         }
         if ( AV47EtapaDesarrolloId == 6 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007521 */
            pr_default.execute(12);
            if ( (pr_default.getStatus(12) != 101) )
            {
               A40000GXC1 = P007521_A40000GXC1[0];
               n40000GXC1 = P007521_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(12);
            AV51Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV51Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A165TicketResponsableCerrado = AV19TicketResponsableCerrado;
            n165TicketResponsableCerrado = false;
            A166TicketResponsablePendiente = AV20TicketResponsablePendiente;
            n166TicketResponsablePendiente = false;
            A167TicketResponsablePasaTaller = AV21TicketResponsablePasaTaller;
            n167TicketResponsablePasaTaller = false;
            A290EtapaDesarrolloId = 7;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007522 */
            pr_default.execute(13, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(13);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(13) == 1) )
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
         }
         if ( AV47EtapaDesarrolloId == 7 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P007523 */
            pr_default.execute(14, new Object[] {AV24TicketId, AV23UsuarioId});
            pr_default.close(14);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
            /* Optimized UPDATE. */
            /* Using cursor P007524 */
            pr_default.execute(15, new Object[] {AV23UsuarioId});
            pr_default.close(15);
            dsDefault.SmartCacheProvider.SetUpdated("Usuario");
            /* End optimized UPDATE. */
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrregistrardesarrollo",pr_default);
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(12);
         pr_default.close(10);
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(4);
         pr_default.close(2);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P00752_A17EstadoTicketTecnicoId = new short[1] ;
         P00752_A198TicketTecnicoResponsableId = new short[1] ;
         P00752_A16TicketResponsableId = new long[1] ;
         P00752_A145TicketResponsableInventarioSerie = new string[] {""} ;
         P00752_n145TicketResponsableInventarioSerie = new bool[] {false} ;
         P00752_A146TicketResponsableInstalacion = new bool[] {false} ;
         P00752_n146TicketResponsableInstalacion = new bool[] {false} ;
         P00752_A147TicketResponsableConfiguracion = new bool[] {false} ;
         P00752_n147TicketResponsableConfiguracion = new bool[] {false} ;
         P00752_A148TicketResponsableInternetRouter = new bool[] {false} ;
         P00752_n148TicketResponsableInternetRouter = new bool[] {false} ;
         P00752_A149TicketResponsableFormateo = new bool[] {false} ;
         P00752_n149TicketResponsableFormateo = new bool[] {false} ;
         P00752_A150TicketResponsableReparacion = new bool[] {false} ;
         P00752_n150TicketResponsableReparacion = new bool[] {false} ;
         P00752_A151TicketResponsableLimpieza = new bool[] {false} ;
         P00752_n151TicketResponsableLimpieza = new bool[] {false} ;
         P00752_A152TicketResponsablePuntoRed = new bool[] {false} ;
         P00752_n152TicketResponsablePuntoRed = new bool[] {false} ;
         P00752_A153TicketResponsableCambiosHardware = new bool[] {false} ;
         P00752_n153TicketResponsableCambiosHardware = new bool[] {false} ;
         P00752_A154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         P00752_n154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         P00752_A177TicketResponsableRamTxt = new string[] {""} ;
         P00752_n177TicketResponsableRamTxt = new bool[] {false} ;
         P00752_A178TicketResponsableDiscoDuroTxt = new string[] {""} ;
         P00752_n178TicketResponsableDiscoDuroTxt = new bool[] {false} ;
         P00752_A179TicketResponsableProcesadorTxt = new string[] {""} ;
         P00752_n179TicketResponsableProcesadorTxt = new bool[] {false} ;
         P00752_A180TicketResponsableMaletinTxt = new string[] {""} ;
         P00752_n180TicketResponsableMaletinTxt = new bool[] {false} ;
         P00752_A181TicketResponsableTonerCintaTxt = new string[] {""} ;
         P00752_n181TicketResponsableTonerCintaTxt = new bool[] {false} ;
         P00752_A182TicketResponsableTarjetaVideoExtraTxt = new string[] {""} ;
         P00752_n182TicketResponsableTarjetaVideoExtraTxt = new bool[] {false} ;
         P00752_A183TicketResponsableCargadorLaptopTxt = new string[] {""} ;
         P00752_n183TicketResponsableCargadorLaptopTxt = new bool[] {false} ;
         P00752_A184TicketResponsableCDsDVDsTxt = new string[] {""} ;
         P00752_n184TicketResponsableCDsDVDsTxt = new bool[] {false} ;
         P00752_A185TicketResponsableCableEspecialTxt = new string[] {""} ;
         P00752_n185TicketResponsableCableEspecialTxt = new bool[] {false} ;
         P00752_A186TicketResponsableOtrosTallerTxt = new string[] {""} ;
         P00752_n186TicketResponsableOtrosTallerTxt = new bool[] {false} ;
         P00752_A165TicketResponsableCerrado = new bool[] {false} ;
         P00752_n165TicketResponsableCerrado = new bool[] {false} ;
         P00752_A166TicketResponsablePendiente = new bool[] {false} ;
         P00752_n166TicketResponsablePendiente = new bool[] {false} ;
         P00752_A167TicketResponsablePasaTaller = new bool[] {false} ;
         P00752_n167TicketResponsablePasaTaller = new bool[] {false} ;
         P00752_A168TicketResponsableObservacion = new string[] {""} ;
         P00752_n168TicketResponsableObservacion = new bool[] {false} ;
         P00752_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         P00752_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         P00752_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         P00752_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         P00752_A14TicketId = new long[1] ;
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
         A239nombre_emp = "";
         AV40WebSession = context.GetSession();
         A240cargo_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         P00754_A238correlativo = new int[1] ;
         Gx_emsg = "";
         P00756_A40000GXC1 = new long[1] ;
         P00756_n40000GXC1 = new bool[] {false} ;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A47TicketFechaResponsable = DateTime.MinValue;
         P00759_A40000GXC1 = new long[1] ;
         P00759_n40000GXC1 = new bool[] {false} ;
         P007512_A40000GXC1 = new long[1] ;
         P007512_n40000GXC1 = new bool[] {false} ;
         P007515_A40000GXC1 = new long[1] ;
         P007515_n40000GXC1 = new bool[] {false} ;
         P007518_A40000GXC1 = new long[1] ;
         P007518_n40000GXC1 = new bool[] {false} ;
         P007521_A40000GXC1 = new long[1] ;
         P007521_n40000GXC1 = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrardesarrollo__datastore1(),
            new Object[][] {
                new Object[] {
               P00754_A238correlativo
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrardesarrollo__default(),
            new Object[][] {
                new Object[] {
               P00752_A17EstadoTicketTecnicoId, P00752_A198TicketTecnicoResponsableId, P00752_A16TicketResponsableId, P00752_A145TicketResponsableInventarioSerie, P00752_n145TicketResponsableInventarioSerie, P00752_A146TicketResponsableInstalacion, P00752_n146TicketResponsableInstalacion, P00752_A147TicketResponsableConfiguracion, P00752_n147TicketResponsableConfiguracion, P00752_A148TicketResponsableInternetRouter,
               P00752_n148TicketResponsableInternetRouter, P00752_A149TicketResponsableFormateo, P00752_n149TicketResponsableFormateo, P00752_A150TicketResponsableReparacion, P00752_n150TicketResponsableReparacion, P00752_A151TicketResponsableLimpieza, P00752_n151TicketResponsableLimpieza, P00752_A152TicketResponsablePuntoRed, P00752_n152TicketResponsablePuntoRed, P00752_A153TicketResponsableCambiosHardware,
               P00752_n153TicketResponsableCambiosHardware, P00752_A154TicketResponsableCopiasRespaldo, P00752_n154TicketResponsableCopiasRespaldo, P00752_A177TicketResponsableRamTxt, P00752_n177TicketResponsableRamTxt, P00752_A178TicketResponsableDiscoDuroTxt, P00752_n178TicketResponsableDiscoDuroTxt, P00752_A179TicketResponsableProcesadorTxt, P00752_n179TicketResponsableProcesadorTxt, P00752_A180TicketResponsableMaletinTxt,
               P00752_n180TicketResponsableMaletinTxt, P00752_A181TicketResponsableTonerCintaTxt, P00752_n181TicketResponsableTonerCintaTxt, P00752_A182TicketResponsableTarjetaVideoExtraTxt, P00752_n182TicketResponsableTarjetaVideoExtraTxt, P00752_A183TicketResponsableCargadorLaptopTxt, P00752_n183TicketResponsableCargadorLaptopTxt, P00752_A184TicketResponsableCDsDVDsTxt, P00752_n184TicketResponsableCDsDVDsTxt, P00752_A185TicketResponsableCableEspecialTxt,
               P00752_n185TicketResponsableCableEspecialTxt, P00752_A186TicketResponsableOtrosTallerTxt, P00752_n186TicketResponsableOtrosTallerTxt, P00752_A165TicketResponsableCerrado, P00752_n165TicketResponsableCerrado, P00752_A166TicketResponsablePendiente, P00752_n166TicketResponsablePendiente, P00752_A167TicketResponsablePasaTaller, P00752_n167TicketResponsablePasaTaller, P00752_A168TicketResponsableObservacion,
               P00752_n168TicketResponsableObservacion, P00752_A175TicketResponsableFechaResuelve, P00752_n175TicketResponsableFechaResuelve, P00752_A176TicketResponsableHoraResuelve, P00752_n176TicketResponsableHoraResuelve, P00752_A14TicketId
               }
               , new Object[] {
               }
               , new Object[] {
               P00756_A40000GXC1, P00756_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               P00759_A40000GXC1, P00759_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               P007512_A40000GXC1, P007512_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               P007515_A40000GXC1, P007515_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               P007518_A40000GXC1, P007518_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               P007521_A40000GXC1, P007521_n40000GXC1
               }
               , new Object[] {
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
      private short AV46EstadoTicketTicketId ;
      private short AV47EtapaDesarrolloId ;
      private short A17EstadoTicketTecnicoId ;
      private short A198TicketTecnicoResponsableId ;
      private short A290EtapaDesarrolloId ;
      private int AV43categoria_tareaid_tipo_categoria ;
      private int AV44id_actividad_categoria ;
      private int AV37detalle_infotecid_unidad ;
      private int GX_INS17 ;
      private int A248detalle_infotecid_unidad ;
      private int A249id_categoria ;
      private int A250id_actividad ;
      private int A238correlativo ;
      private int GX_INS8 ;
      private long AV24TicketId ;
      private long AV8TicketResponsableId ;
      private long A16TicketResponsableId ;
      private long A14TicketId ;
      private long A40000GXC1 ;
      private long AV51Ticketresponsablesig ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A176TicketResponsableHoraResuelve ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime AV39UsuarioFecha ;
      private DateTime A175TicketResponsableFechaResuelve ;
      private DateTime A241fecha_registro ;
      private DateTime A47TicketFechaResponsable ;
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
      private bool A165TicketResponsableCerrado ;
      private bool n165TicketResponsableCerrado ;
      private bool A166TicketResponsablePendiente ;
      private bool n166TicketResponsablePendiente ;
      private bool A167TicketResponsablePasaTaller ;
      private bool n167TicketResponsablePasaTaller ;
      private bool n168TicketResponsableObservacion ;
      private bool n175TicketResponsableFechaResuelve ;
      private bool n176TicketResponsableHoraResuelve ;
      private bool n239nombre_emp ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n243estatus ;
      private bool n244trabajo ;
      private bool n245nombre_usuario ;
      private bool n246depto_usuario ;
      private bool n247correo_usuario ;
      private bool n248detalle_infotecid_unidad ;
      private bool n249id_categoria ;
      private bool n250id_actividad ;
      private bool n251detalle_tarea ;
      private bool n252prioridad ;
      private bool n253observaciones ;
      private bool n254fecha_solicitud ;
      private bool n40000GXC1 ;
      private bool n290EtapaDesarrolloId ;
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
      private string A239nombre_emp ;
      private string A240cargo_emp ;
      private string A243estatus ;
      private string A244trabajo ;
      private string A245nombre_usuario ;
      private string A246depto_usuario ;
      private string A247correo_usuario ;
      private string A251detalle_tarea ;
      private string A252prioridad ;
      private string A253observaciones ;
      private string A254fecha_solicitud ;
      private IGxSession AV40WebSession ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00752_A17EstadoTicketTecnicoId ;
      private short[] P00752_A198TicketTecnicoResponsableId ;
      private long[] P00752_A16TicketResponsableId ;
      private string[] P00752_A145TicketResponsableInventarioSerie ;
      private bool[] P00752_n145TicketResponsableInventarioSerie ;
      private bool[] P00752_A146TicketResponsableInstalacion ;
      private bool[] P00752_n146TicketResponsableInstalacion ;
      private bool[] P00752_A147TicketResponsableConfiguracion ;
      private bool[] P00752_n147TicketResponsableConfiguracion ;
      private bool[] P00752_A148TicketResponsableInternetRouter ;
      private bool[] P00752_n148TicketResponsableInternetRouter ;
      private bool[] P00752_A149TicketResponsableFormateo ;
      private bool[] P00752_n149TicketResponsableFormateo ;
      private bool[] P00752_A150TicketResponsableReparacion ;
      private bool[] P00752_n150TicketResponsableReparacion ;
      private bool[] P00752_A151TicketResponsableLimpieza ;
      private bool[] P00752_n151TicketResponsableLimpieza ;
      private bool[] P00752_A152TicketResponsablePuntoRed ;
      private bool[] P00752_n152TicketResponsablePuntoRed ;
      private bool[] P00752_A153TicketResponsableCambiosHardware ;
      private bool[] P00752_n153TicketResponsableCambiosHardware ;
      private bool[] P00752_A154TicketResponsableCopiasRespaldo ;
      private bool[] P00752_n154TicketResponsableCopiasRespaldo ;
      private string[] P00752_A177TicketResponsableRamTxt ;
      private bool[] P00752_n177TicketResponsableRamTxt ;
      private string[] P00752_A178TicketResponsableDiscoDuroTxt ;
      private bool[] P00752_n178TicketResponsableDiscoDuroTxt ;
      private string[] P00752_A179TicketResponsableProcesadorTxt ;
      private bool[] P00752_n179TicketResponsableProcesadorTxt ;
      private string[] P00752_A180TicketResponsableMaletinTxt ;
      private bool[] P00752_n180TicketResponsableMaletinTxt ;
      private string[] P00752_A181TicketResponsableTonerCintaTxt ;
      private bool[] P00752_n181TicketResponsableTonerCintaTxt ;
      private string[] P00752_A182TicketResponsableTarjetaVideoExtraTxt ;
      private bool[] P00752_n182TicketResponsableTarjetaVideoExtraTxt ;
      private string[] P00752_A183TicketResponsableCargadorLaptopTxt ;
      private bool[] P00752_n183TicketResponsableCargadorLaptopTxt ;
      private string[] P00752_A184TicketResponsableCDsDVDsTxt ;
      private bool[] P00752_n184TicketResponsableCDsDVDsTxt ;
      private string[] P00752_A185TicketResponsableCableEspecialTxt ;
      private bool[] P00752_n185TicketResponsableCableEspecialTxt ;
      private string[] P00752_A186TicketResponsableOtrosTallerTxt ;
      private bool[] P00752_n186TicketResponsableOtrosTallerTxt ;
      private bool[] P00752_A165TicketResponsableCerrado ;
      private bool[] P00752_n165TicketResponsableCerrado ;
      private bool[] P00752_A166TicketResponsablePendiente ;
      private bool[] P00752_n166TicketResponsablePendiente ;
      private bool[] P00752_A167TicketResponsablePasaTaller ;
      private bool[] P00752_n167TicketResponsablePasaTaller ;
      private string[] P00752_A168TicketResponsableObservacion ;
      private bool[] P00752_n168TicketResponsableObservacion ;
      private DateTime[] P00752_A175TicketResponsableFechaResuelve ;
      private bool[] P00752_n175TicketResponsableFechaResuelve ;
      private DateTime[] P00752_A176TicketResponsableHoraResuelve ;
      private bool[] P00752_n176TicketResponsableHoraResuelve ;
      private long[] P00752_A14TicketId ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] P00754_A238correlativo ;
      private long[] P00756_A40000GXC1 ;
      private bool[] P00756_n40000GXC1 ;
      private long[] P00759_A40000GXC1 ;
      private bool[] P00759_n40000GXC1 ;
      private long[] P007512_A40000GXC1 ;
      private bool[] P007512_n40000GXC1 ;
      private long[] P007515_A40000GXC1 ;
      private bool[] P007515_n40000GXC1 ;
      private long[] P007518_A40000GXC1 ;
      private bool[] P007518_n40000GXC1 ;
      private long[] P007521_A40000GXC1 ;
      private bool[] P007521_n40000GXC1 ;
   }

   public class pcrregistrardesarrollo__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00754;
          prmP00754 = new Object[] {
          new ParDef("@nombre_emp",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@cargo_emp",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@fecha_registro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@estatus",GXType.NVarChar,30,0){Nullable=true} ,
          new ParDef("@trabajo",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@nombre_usuario",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@depto_usuario",GXType.NVarChar,150,0){Nullable=true} ,
          new ParDef("@correo_usuario",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@detalle_infotecid_unidad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@id_categoria",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@id_actividad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@detalle_tarea",GXType.NVarChar,250,0){Nullable=true} ,
          new ParDef("@prioridad",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@observaciones",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@fecha_solicitud",GXType.NVarChar,300,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00754", "INSERT INTO dbo.[detalle_infotec]([nombre_emp], [cargo_emp], [fecha_registro], [estatus], [trabajo], [nombre_usuario], [depto_usuario], [correo_usuario], [id_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud], [hora_registro], [fecha_ciere], [hora_cierra]) VALUES(@nombre_emp, @cargo_emp, @fecha_registro, @estatus, @trabajo, @nombre_usuario, @depto_usuario, @correo_usuario, @detalle_infotecid_unidad, @id_categoria, @id_actividad, @detalle_tarea, @prioridad, @observaciones, @fecha_solicitud, convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP00754)
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class pcrregistrardesarrollo__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00752;
        prmP00752 = new Object[] {
        new ParDef("@AV8TicketResponsableId",GXType.Decimal,10,0) ,
        new ParDef("@AV45TicketTecnicoResponsableId",GXType.Int16,4,0)
        };
        Object[] prmP00753;
        prmP00753 = new Object[] {
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
        string cmdBufferP00753;
        cmdBufferP00753=" UPDATE [TicketResponsable] SET [EstadoTicketTecnicoId]=@EstadoTicketTecnicoId, [TicketResponsableInventarioSerie]=@TicketResponsableInventarioSerie, [TicketResponsableInstalacion]=@TicketResponsableInstalacion, [TicketResponsableConfiguracion]=@TicketResponsableConfiguracion, [TicketResponsableInternetRouter]=@TicketResponsableInternetRouter, [TicketResponsableFormateo]=@TicketResponsableFormateo, [TicketResponsableReparacion]=@TicketResponsableReparacion, [TicketResponsableLimpieza]=@TicketResponsableLimpieza, [TicketResponsablePuntoRed]=@TicketResponsablePuntoRed, [TicketResponsableCambiosHardware]=@TicketResponsableCambiosHardware, [TicketResponsableCopiasRespaldo]=@TicketResponsableCopiasRespaldo, [TicketResponsableRamTxt]=@TicketResponsableRamTxt, [TicketResponsableDiscoDuroTxt]=@TicketResponsableDiscoDuroTxt, [TicketResponsableProcesadorTxt]=@TicketResponsableProcesadorTxt, [TicketResponsableMaletinTxt]=@TicketResponsableMaletinTxt, [TicketResponsableTonerCintaTxt]=@TicketResponsableTonerCintaTxt, [TicketResponsableTarjetaVideoExtraTxt]=@TicketResponsableTarjetaVideoExtraTxt, [TicketResponsableCargadorLaptopTxt]=@TicketResponsableCargadorLaptopTxt, [TicketResponsableCDsDVDsTxt]=@TicketResponsableCDsDVDsTxt, [TicketResponsableCableEspecialTxt]=@TicketResponsableCableEspecialTxt, [TicketResponsableOtrosTallerTxt]=@TicketResponsableOtrosTallerTxt, [TicketResponsableCerrado]=@TicketResponsableCerrado, [TicketResponsablePendiente]=@TicketResponsablePendiente, [TicketResponsablePasaTaller]=@TicketResponsablePasaTaller, [TicketResponsableObservacion]=@TicketResponsableObservacion, [TicketResponsableFechaResuelve]=@TicketResponsableFechaResuelve, [TicketResponsableHoraResuelve]=@TicketResponsableHoraResuelve  WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId "
        + "" ;
        Object[] prmP00756;
        prmP00756 = new Object[] {
        };
        Object[] prmP00757;
        prmP00757 = new Object[] {
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
        Object[] prmP00759;
        prmP00759 = new Object[] {
        };
        Object[] prmP007510;
        prmP007510 = new Object[] {
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
        Object[] prmP007512;
        prmP007512 = new Object[] {
        };
        Object[] prmP007513;
        prmP007513 = new Object[] {
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
        Object[] prmP007515;
        prmP007515 = new Object[] {
        };
        Object[] prmP007516;
        prmP007516 = new Object[] {
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
        Object[] prmP007518;
        prmP007518 = new Object[] {
        };
        Object[] prmP007519;
        prmP007519 = new Object[] {
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
        Object[] prmP007521;
        prmP007521 = new Object[] {
        };
        Object[] prmP007522;
        prmP007522 = new Object[] {
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
        Object[] prmP007523;
        prmP007523 = new Object[] {
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Int16,4,0)
        };
        Object[] prmP007524;
        prmP007524 = new Object[] {
        new ParDef("@AV23UsuarioId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00752", "SELECT [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [TicketResponsableId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketId] FROM [TicketResponsable] WITH (UPDLOCK) WHERE ([TicketResponsableId] = @AV8TicketResponsableId) AND ([TicketTecnicoResponsableId] = @AV45TicketTecnicoResponsableId) AND ([EstadoTicketTecnicoId] = 3) ORDER BY [TicketId], [TicketResponsableId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00753", cmdBufferP00753, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00753)
           ,new CursorDef("P00756", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00756,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00757", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00757)
           ,new CursorDef("P00759", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00759,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007510", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP007510)
           ,new CursorDef("P007512", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007512,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007513", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP007513)
           ,new CursorDef("P007515", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007515,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007516", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP007516)
           ,new CursorDef("P007518", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007518,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007519", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP007519)
           ,new CursorDef("P007521", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007521,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007522", "INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP007522)
           ,new CursorDef("P007523", "UPDATE [Ticket] SET [EstadoTicketTicketId]=5  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007523)
           ,new CursorDef("P007524", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=5  WHERE [UsuarioId] = @AV23UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007524)
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
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
