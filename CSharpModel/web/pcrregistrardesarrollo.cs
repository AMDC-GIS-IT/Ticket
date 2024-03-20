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

      public void execute( long aP0_TicketId ,
                           long aP1_UsuarioId ,
                           long aP2_TicketResponsableId ,
                           short aP3_TicketTecnicoResponsableId ,
                           bool aP4_TicketResponsableAnalasisUno ,
                           bool aP5_TicketResponsableAnalasisDos ,
                           bool aP6_TicketResponsableAnalasisTres ,
                           bool aP7_TicketResponsableAnalasisCuatro ,
                           bool aP8_TicketResponsableDisenioUno ,
                           bool aP9_TicketResponsableDesarrolloUno ,
                           bool aP10_TicketResponsableDesarrolloDos ,
                           bool aP11_TicketResponsableDesarrolloTres ,
                           bool aP12_TicketResponsableDesarrolloCuatro ,
                           bool aP13_TicketResponsableDesarrolloCinco ,
                           bool aP14_TicketResponsablePruebasUno ,
                           bool aP15_TicketResponsablePruebasDos ,
                           bool aP16_TicketResponsablePruebasTres ,
                           bool aP17_TicketResponsablePruebasCuatro ,
                           bool aP18_TicketResponsableDocumentacionUno ,
                           bool aP19_TicketResponsableDocumentacionDos ,
                           bool aP20_TicketResponsableDocumentacionTres ,
                           bool aP21_TicketResponsableDocumentacionCuatro ,
                           bool aP22_TicketResponsableImplementacionUno ,
                           bool aP23_TicketResponsableImplementacionDos ,
                           bool aP24_TicketResponsableImplementacionTres ,
                           bool aP25_TicketResponsableImplementacionCuatro ,
                           bool aP26_TicketResponsableImplementacionCinco ,
                           bool aP27_TicketResponsableImplementacionSeis ,
                           bool aP28_TicketResponsableMantenimientoUno ,
                           bool aP29_TicketResponsableMantenimientoDos ,
                           bool aP30_TicketResponsableMantenimientoTres ,
                           bool aP31_TicketResponsableMantenimientoCuatro ,
                           bool aP32_TicketResponsableMantenimientoCinco ,
                           bool aP33_TicketResponsableMantenimientoSeis ,
                           bool aP34_TicketResponsableMantenimientoSiete ,
                           bool aP35_TicketResponsableGestionbdUno ,
                           bool aP36_TicketResponsableGestionbdDos ,
                           bool aP37_TicketResponsableGestionbdTres ,
                           bool aP38_TicketResponsableGestionbdCuatro ,
                           bool aP39_TicketResponsableMantenimientobdUno ,
                           bool aP40_TicketResponsableMantenimientobdDos ,
                           bool aP41_TicketResponsableMantenimientobdTres ,
                           bool aP42_TicketResponsableMantenimientobdCuatro ,
                           bool aP43_TicketResponsableMantenimientobdCinco ,
                           bool aP44_TicketResponsableMantenimientobdSeis ,
                           bool aP45_TicketResponsableMantenimientobdSiete ,
                           string aP46_TicketResponsableObservacion ,
                           int aP47_categoria_tareaid_tipo_categoria ,
                           int aP48_id_actividad_categoria ,
                           string aP49_UsuarioNombre ,
                           string aP50_UsuarioDepartamento ,
                           string aP51_UsuarioEmail ,
                           int aP52_detalle_infotecid_unidad ,
                           string aP53_detalle_tarea ,
                           string aP54_prioridad ,
                           DateTime aP55_UsuarioFecha ,
                           short aP56_EstadoTicketTicketId ,
                           short aP57_EtapaDesarrolloId )
      {
         this.AV24TicketId = aP0_TicketId;
         this.AV23UsuarioId = aP1_UsuarioId;
         this.AV8TicketResponsableId = aP2_TicketResponsableId;
         this.AV45TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV49TicketResponsableAnalasisUno = aP4_TicketResponsableAnalasisUno;
         this.AV50TicketResponsableAnalasisDos = aP5_TicketResponsableAnalasisDos;
         this.AV51TicketResponsableAnalasisTres = aP6_TicketResponsableAnalasisTres;
         this.AV52TicketResponsableAnalasisCuatro = aP7_TicketResponsableAnalasisCuatro;
         this.AV53TicketResponsableDisenioUno = aP8_TicketResponsableDisenioUno;
         this.AV54TicketResponsableDesarrolloUno = aP9_TicketResponsableDesarrolloUno;
         this.AV55TicketResponsableDesarrolloDos = aP10_TicketResponsableDesarrolloDos;
         this.AV56TicketResponsableDesarrolloTres = aP11_TicketResponsableDesarrolloTres;
         this.AV57TicketResponsableDesarrolloCuatro = aP12_TicketResponsableDesarrolloCuatro;
         this.AV58TicketResponsableDesarrolloCinco = aP13_TicketResponsableDesarrolloCinco;
         this.AV59TicketResponsablePruebasUno = aP14_TicketResponsablePruebasUno;
         this.AV60TicketResponsablePruebasDos = aP15_TicketResponsablePruebasDos;
         this.AV61TicketResponsablePruebasTres = aP16_TicketResponsablePruebasTres;
         this.AV62TicketResponsablePruebasCuatro = aP17_TicketResponsablePruebasCuatro;
         this.AV63TicketResponsableDocumentacionUno = aP18_TicketResponsableDocumentacionUno;
         this.AV64TicketResponsableDocumentacionDos = aP19_TicketResponsableDocumentacionDos;
         this.AV65TicketResponsableDocumentacionTres = aP20_TicketResponsableDocumentacionTres;
         this.AV66TicketResponsableDocumentacionCuatro = aP21_TicketResponsableDocumentacionCuatro;
         this.AV67TicketResponsableImplementacionUno = aP22_TicketResponsableImplementacionUno;
         this.AV68TicketResponsableImplementacionDos = aP23_TicketResponsableImplementacionDos;
         this.AV69TicketResponsableImplementacionTres = aP24_TicketResponsableImplementacionTres;
         this.AV70TicketResponsableImplementacionCuatro = aP25_TicketResponsableImplementacionCuatro;
         this.AV71TicketResponsableImplementacionCinco = aP26_TicketResponsableImplementacionCinco;
         this.AV72TicketResponsableImplementacionSeis = aP27_TicketResponsableImplementacionSeis;
         this.AV73TicketResponsableMantenimientoUno = aP28_TicketResponsableMantenimientoUno;
         this.AV74TicketResponsableMantenimientoDos = aP29_TicketResponsableMantenimientoDos;
         this.AV75TicketResponsableMantenimientoTres = aP30_TicketResponsableMantenimientoTres;
         this.AV76TicketResponsableMantenimientoCuatro = aP31_TicketResponsableMantenimientoCuatro;
         this.AV77TicketResponsableMantenimientoCinco = aP32_TicketResponsableMantenimientoCinco;
         this.AV78TicketResponsableMantenimientoSeis = aP33_TicketResponsableMantenimientoSeis;
         this.AV79TicketResponsableMantenimientoSiete = aP34_TicketResponsableMantenimientoSiete;
         this.AV80TicketResponsableGestionbdUno = aP35_TicketResponsableGestionbdUno;
         this.AV81TicketResponsableGestionbdDos = aP36_TicketResponsableGestionbdDos;
         this.AV82TicketResponsableGestionbdTres = aP37_TicketResponsableGestionbdTres;
         this.AV83TicketResponsableGestionbdCuatro = aP38_TicketResponsableGestionbdCuatro;
         this.AV84TicketResponsableMantenimientobdUno = aP39_TicketResponsableMantenimientobdUno;
         this.AV85TicketResponsableMantenimientobdDos = aP40_TicketResponsableMantenimientobdDos;
         this.AV48TicketResponsableMantenimientobdTres = aP41_TicketResponsableMantenimientobdTres;
         this.AV86TicketResponsableMantenimientobdCuatro = aP42_TicketResponsableMantenimientobdCuatro;
         this.AV87TicketResponsableMantenimientobdCinco = aP43_TicketResponsableMantenimientobdCinco;
         this.AV88TicketResponsableMantenimientobdSeis = aP44_TicketResponsableMantenimientobdSeis;
         this.AV89TicketResponsableMantenimientobdSiete = aP45_TicketResponsableMantenimientobdSiete;
         this.AV22TicketResponsableObservacion = aP46_TicketResponsableObservacion;
         this.AV43categoria_tareaid_tipo_categoria = aP47_categoria_tareaid_tipo_categoria;
         this.AV44id_actividad_categoria = aP48_id_actividad_categoria;
         this.AV41UsuarioNombre = aP49_UsuarioNombre;
         this.AV38UsuarioDepartamento = aP50_UsuarioDepartamento;
         this.AV42UsuarioEmail = aP51_UsuarioEmail;
         this.AV37detalle_infotecid_unidad = aP52_detalle_infotecid_unidad;
         this.AV36detalle_tarea = aP53_detalle_tarea;
         this.AV35prioridad = aP54_prioridad;
         this.AV39UsuarioFecha = aP55_UsuarioFecha;
         this.AV46EstadoTicketTicketId = aP56_EstadoTicketTicketId;
         this.AV47EtapaDesarrolloId = aP57_EtapaDesarrolloId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_TicketId ,
                                 long aP1_UsuarioId ,
                                 long aP2_TicketResponsableId ,
                                 short aP3_TicketTecnicoResponsableId ,
                                 bool aP4_TicketResponsableAnalasisUno ,
                                 bool aP5_TicketResponsableAnalasisDos ,
                                 bool aP6_TicketResponsableAnalasisTres ,
                                 bool aP7_TicketResponsableAnalasisCuatro ,
                                 bool aP8_TicketResponsableDisenioUno ,
                                 bool aP9_TicketResponsableDesarrolloUno ,
                                 bool aP10_TicketResponsableDesarrolloDos ,
                                 bool aP11_TicketResponsableDesarrolloTres ,
                                 bool aP12_TicketResponsableDesarrolloCuatro ,
                                 bool aP13_TicketResponsableDesarrolloCinco ,
                                 bool aP14_TicketResponsablePruebasUno ,
                                 bool aP15_TicketResponsablePruebasDos ,
                                 bool aP16_TicketResponsablePruebasTres ,
                                 bool aP17_TicketResponsablePruebasCuatro ,
                                 bool aP18_TicketResponsableDocumentacionUno ,
                                 bool aP19_TicketResponsableDocumentacionDos ,
                                 bool aP20_TicketResponsableDocumentacionTres ,
                                 bool aP21_TicketResponsableDocumentacionCuatro ,
                                 bool aP22_TicketResponsableImplementacionUno ,
                                 bool aP23_TicketResponsableImplementacionDos ,
                                 bool aP24_TicketResponsableImplementacionTres ,
                                 bool aP25_TicketResponsableImplementacionCuatro ,
                                 bool aP26_TicketResponsableImplementacionCinco ,
                                 bool aP27_TicketResponsableImplementacionSeis ,
                                 bool aP28_TicketResponsableMantenimientoUno ,
                                 bool aP29_TicketResponsableMantenimientoDos ,
                                 bool aP30_TicketResponsableMantenimientoTres ,
                                 bool aP31_TicketResponsableMantenimientoCuatro ,
                                 bool aP32_TicketResponsableMantenimientoCinco ,
                                 bool aP33_TicketResponsableMantenimientoSeis ,
                                 bool aP34_TicketResponsableMantenimientoSiete ,
                                 bool aP35_TicketResponsableGestionbdUno ,
                                 bool aP36_TicketResponsableGestionbdDos ,
                                 bool aP37_TicketResponsableGestionbdTres ,
                                 bool aP38_TicketResponsableGestionbdCuatro ,
                                 bool aP39_TicketResponsableMantenimientobdUno ,
                                 bool aP40_TicketResponsableMantenimientobdDos ,
                                 bool aP41_TicketResponsableMantenimientobdTres ,
                                 bool aP42_TicketResponsableMantenimientobdCuatro ,
                                 bool aP43_TicketResponsableMantenimientobdCinco ,
                                 bool aP44_TicketResponsableMantenimientobdSeis ,
                                 bool aP45_TicketResponsableMantenimientobdSiete ,
                                 string aP46_TicketResponsableObservacion ,
                                 int aP47_categoria_tareaid_tipo_categoria ,
                                 int aP48_id_actividad_categoria ,
                                 string aP49_UsuarioNombre ,
                                 string aP50_UsuarioDepartamento ,
                                 string aP51_UsuarioEmail ,
                                 int aP52_detalle_infotecid_unidad ,
                                 string aP53_detalle_tarea ,
                                 string aP54_prioridad ,
                                 DateTime aP55_UsuarioFecha ,
                                 short aP56_EstadoTicketTicketId ,
                                 short aP57_EtapaDesarrolloId )
      {
         pcrregistrardesarrollo objpcrregistrardesarrollo;
         objpcrregistrardesarrollo = new pcrregistrardesarrollo();
         objpcrregistrardesarrollo.AV24TicketId = aP0_TicketId;
         objpcrregistrardesarrollo.AV23UsuarioId = aP1_UsuarioId;
         objpcrregistrardesarrollo.AV8TicketResponsableId = aP2_TicketResponsableId;
         objpcrregistrardesarrollo.AV45TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         objpcrregistrardesarrollo.AV49TicketResponsableAnalasisUno = aP4_TicketResponsableAnalasisUno;
         objpcrregistrardesarrollo.AV50TicketResponsableAnalasisDos = aP5_TicketResponsableAnalasisDos;
         objpcrregistrardesarrollo.AV51TicketResponsableAnalasisTres = aP6_TicketResponsableAnalasisTres;
         objpcrregistrardesarrollo.AV52TicketResponsableAnalasisCuatro = aP7_TicketResponsableAnalasisCuatro;
         objpcrregistrardesarrollo.AV53TicketResponsableDisenioUno = aP8_TicketResponsableDisenioUno;
         objpcrregistrardesarrollo.AV54TicketResponsableDesarrolloUno = aP9_TicketResponsableDesarrolloUno;
         objpcrregistrardesarrollo.AV55TicketResponsableDesarrolloDos = aP10_TicketResponsableDesarrolloDos;
         objpcrregistrardesarrollo.AV56TicketResponsableDesarrolloTres = aP11_TicketResponsableDesarrolloTres;
         objpcrregistrardesarrollo.AV57TicketResponsableDesarrolloCuatro = aP12_TicketResponsableDesarrolloCuatro;
         objpcrregistrardesarrollo.AV58TicketResponsableDesarrolloCinco = aP13_TicketResponsableDesarrolloCinco;
         objpcrregistrardesarrollo.AV59TicketResponsablePruebasUno = aP14_TicketResponsablePruebasUno;
         objpcrregistrardesarrollo.AV60TicketResponsablePruebasDos = aP15_TicketResponsablePruebasDos;
         objpcrregistrardesarrollo.AV61TicketResponsablePruebasTres = aP16_TicketResponsablePruebasTres;
         objpcrregistrardesarrollo.AV62TicketResponsablePruebasCuatro = aP17_TicketResponsablePruebasCuatro;
         objpcrregistrardesarrollo.AV63TicketResponsableDocumentacionUno = aP18_TicketResponsableDocumentacionUno;
         objpcrregistrardesarrollo.AV64TicketResponsableDocumentacionDos = aP19_TicketResponsableDocumentacionDos;
         objpcrregistrardesarrollo.AV65TicketResponsableDocumentacionTres = aP20_TicketResponsableDocumentacionTres;
         objpcrregistrardesarrollo.AV66TicketResponsableDocumentacionCuatro = aP21_TicketResponsableDocumentacionCuatro;
         objpcrregistrardesarrollo.AV67TicketResponsableImplementacionUno = aP22_TicketResponsableImplementacionUno;
         objpcrregistrardesarrollo.AV68TicketResponsableImplementacionDos = aP23_TicketResponsableImplementacionDos;
         objpcrregistrardesarrollo.AV69TicketResponsableImplementacionTres = aP24_TicketResponsableImplementacionTres;
         objpcrregistrardesarrollo.AV70TicketResponsableImplementacionCuatro = aP25_TicketResponsableImplementacionCuatro;
         objpcrregistrardesarrollo.AV71TicketResponsableImplementacionCinco = aP26_TicketResponsableImplementacionCinco;
         objpcrregistrardesarrollo.AV72TicketResponsableImplementacionSeis = aP27_TicketResponsableImplementacionSeis;
         objpcrregistrardesarrollo.AV73TicketResponsableMantenimientoUno = aP28_TicketResponsableMantenimientoUno;
         objpcrregistrardesarrollo.AV74TicketResponsableMantenimientoDos = aP29_TicketResponsableMantenimientoDos;
         objpcrregistrardesarrollo.AV75TicketResponsableMantenimientoTres = aP30_TicketResponsableMantenimientoTres;
         objpcrregistrardesarrollo.AV76TicketResponsableMantenimientoCuatro = aP31_TicketResponsableMantenimientoCuatro;
         objpcrregistrardesarrollo.AV77TicketResponsableMantenimientoCinco = aP32_TicketResponsableMantenimientoCinco;
         objpcrregistrardesarrollo.AV78TicketResponsableMantenimientoSeis = aP33_TicketResponsableMantenimientoSeis;
         objpcrregistrardesarrollo.AV79TicketResponsableMantenimientoSiete = aP34_TicketResponsableMantenimientoSiete;
         objpcrregistrardesarrollo.AV80TicketResponsableGestionbdUno = aP35_TicketResponsableGestionbdUno;
         objpcrregistrardesarrollo.AV81TicketResponsableGestionbdDos = aP36_TicketResponsableGestionbdDos;
         objpcrregistrardesarrollo.AV82TicketResponsableGestionbdTres = aP37_TicketResponsableGestionbdTres;
         objpcrregistrardesarrollo.AV83TicketResponsableGestionbdCuatro = aP38_TicketResponsableGestionbdCuatro;
         objpcrregistrardesarrollo.AV84TicketResponsableMantenimientobdUno = aP39_TicketResponsableMantenimientobdUno;
         objpcrregistrardesarrollo.AV85TicketResponsableMantenimientobdDos = aP40_TicketResponsableMantenimientobdDos;
         objpcrregistrardesarrollo.AV48TicketResponsableMantenimientobdTres = aP41_TicketResponsableMantenimientobdTres;
         objpcrregistrardesarrollo.AV86TicketResponsableMantenimientobdCuatro = aP42_TicketResponsableMantenimientobdCuatro;
         objpcrregistrardesarrollo.AV87TicketResponsableMantenimientobdCinco = aP43_TicketResponsableMantenimientobdCinco;
         objpcrregistrardesarrollo.AV88TicketResponsableMantenimientobdSeis = aP44_TicketResponsableMantenimientobdSeis;
         objpcrregistrardesarrollo.AV89TicketResponsableMantenimientobdSiete = aP45_TicketResponsableMantenimientobdSiete;
         objpcrregistrardesarrollo.AV22TicketResponsableObservacion = aP46_TicketResponsableObservacion;
         objpcrregistrardesarrollo.AV43categoria_tareaid_tipo_categoria = aP47_categoria_tareaid_tipo_categoria;
         objpcrregistrardesarrollo.AV44id_actividad_categoria = aP48_id_actividad_categoria;
         objpcrregistrardesarrollo.AV41UsuarioNombre = aP49_UsuarioNombre;
         objpcrregistrardesarrollo.AV38UsuarioDepartamento = aP50_UsuarioDepartamento;
         objpcrregistrardesarrollo.AV42UsuarioEmail = aP51_UsuarioEmail;
         objpcrregistrardesarrollo.AV37detalle_infotecid_unidad = aP52_detalle_infotecid_unidad;
         objpcrregistrardesarrollo.AV36detalle_tarea = aP53_detalle_tarea;
         objpcrregistrardesarrollo.AV35prioridad = aP54_prioridad;
         objpcrregistrardesarrollo.AV39UsuarioFecha = aP55_UsuarioFecha;
         objpcrregistrardesarrollo.AV46EstadoTicketTicketId = aP56_EstadoTicketTicketId;
         objpcrregistrardesarrollo.AV47EtapaDesarrolloId = aP57_EtapaDesarrolloId;
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
            A305TicketResponsableAnalasisUno = P00752_A305TicketResponsableAnalasisUno[0];
            n305TicketResponsableAnalasisUno = P00752_n305TicketResponsableAnalasisUno[0];
            A306TicketResponsableAnalasisDos = P00752_A306TicketResponsableAnalasisDos[0];
            n306TicketResponsableAnalasisDos = P00752_n306TicketResponsableAnalasisDos[0];
            A307TicketResponsableAnalasisTres = P00752_A307TicketResponsableAnalasisTres[0];
            n307TicketResponsableAnalasisTres = P00752_n307TicketResponsableAnalasisTres[0];
            A308TicketResponsableAnalasisCuatro = P00752_A308TicketResponsableAnalasisCuatro[0];
            n308TicketResponsableAnalasisCuatro = P00752_n308TicketResponsableAnalasisCuatro[0];
            A309TicketResponsableDisenioUno = P00752_A309TicketResponsableDisenioUno[0];
            n309TicketResponsableDisenioUno = P00752_n309TicketResponsableDisenioUno[0];
            A310TicketResponsableDesarrolloUno = P00752_A310TicketResponsableDesarrolloUno[0];
            n310TicketResponsableDesarrolloUno = P00752_n310TicketResponsableDesarrolloUno[0];
            A311TicketResponsableDesarrolloDos = P00752_A311TicketResponsableDesarrolloDos[0];
            n311TicketResponsableDesarrolloDos = P00752_n311TicketResponsableDesarrolloDos[0];
            A312TicketResponsableDesarrolloTres = P00752_A312TicketResponsableDesarrolloTres[0];
            n312TicketResponsableDesarrolloTres = P00752_n312TicketResponsableDesarrolloTres[0];
            A313TicketResponsableDesarrolloCuatro = P00752_A313TicketResponsableDesarrolloCuatro[0];
            n313TicketResponsableDesarrolloCuatro = P00752_n313TicketResponsableDesarrolloCuatro[0];
            A314TicketResponsableDesarrolloCinco = P00752_A314TicketResponsableDesarrolloCinco[0];
            n314TicketResponsableDesarrolloCinco = P00752_n314TicketResponsableDesarrolloCinco[0];
            A315TicketResponsablePruebasUno = P00752_A315TicketResponsablePruebasUno[0];
            n315TicketResponsablePruebasUno = P00752_n315TicketResponsablePruebasUno[0];
            A316TicketResponsablePruebasDos = P00752_A316TicketResponsablePruebasDos[0];
            n316TicketResponsablePruebasDos = P00752_n316TicketResponsablePruebasDos[0];
            A317TicketResponsablePruebasTres = P00752_A317TicketResponsablePruebasTres[0];
            n317TicketResponsablePruebasTres = P00752_n317TicketResponsablePruebasTres[0];
            A318TicketResponsablePruebasCuatro = P00752_A318TicketResponsablePruebasCuatro[0];
            n318TicketResponsablePruebasCuatro = P00752_n318TicketResponsablePruebasCuatro[0];
            A319TicketResponsableDocumentacionUno = P00752_A319TicketResponsableDocumentacionUno[0];
            n319TicketResponsableDocumentacionUno = P00752_n319TicketResponsableDocumentacionUno[0];
            A320TicketResponsableDocumentacionDos = P00752_A320TicketResponsableDocumentacionDos[0];
            n320TicketResponsableDocumentacionDos = P00752_n320TicketResponsableDocumentacionDos[0];
            A321TicketResponsableDocumentacionTres = P00752_A321TicketResponsableDocumentacionTres[0];
            n321TicketResponsableDocumentacionTres = P00752_n321TicketResponsableDocumentacionTres[0];
            A322TicketResponsableDocumentacionCuatro = P00752_A322TicketResponsableDocumentacionCuatro[0];
            n322TicketResponsableDocumentacionCuatro = P00752_n322TicketResponsableDocumentacionCuatro[0];
            A323TicketResponsableImplementacionUno = P00752_A323TicketResponsableImplementacionUno[0];
            n323TicketResponsableImplementacionUno = P00752_n323TicketResponsableImplementacionUno[0];
            A324TicketResponsableImplementacionDos = P00752_A324TicketResponsableImplementacionDos[0];
            n324TicketResponsableImplementacionDos = P00752_n324TicketResponsableImplementacionDos[0];
            A325TicketResponsableImplementacionTres = P00752_A325TicketResponsableImplementacionTres[0];
            n325TicketResponsableImplementacionTres = P00752_n325TicketResponsableImplementacionTres[0];
            A326TicketResponsableImplementacionCuatro = P00752_A326TicketResponsableImplementacionCuatro[0];
            n326TicketResponsableImplementacionCuatro = P00752_n326TicketResponsableImplementacionCuatro[0];
            A327TicketResponsableImplementacionCinco = P00752_A327TicketResponsableImplementacionCinco[0];
            n327TicketResponsableImplementacionCinco = P00752_n327TicketResponsableImplementacionCinco[0];
            A328TicketResponsableImplementacionSeis = P00752_A328TicketResponsableImplementacionSeis[0];
            n328TicketResponsableImplementacionSeis = P00752_n328TicketResponsableImplementacionSeis[0];
            A329TicketResponsableMantenimientoUno = P00752_A329TicketResponsableMantenimientoUno[0];
            n329TicketResponsableMantenimientoUno = P00752_n329TicketResponsableMantenimientoUno[0];
            A330TicketResponsableMantenimientoDos = P00752_A330TicketResponsableMantenimientoDos[0];
            n330TicketResponsableMantenimientoDos = P00752_n330TicketResponsableMantenimientoDos[0];
            A331TicketResponsableMantenimientoTres = P00752_A331TicketResponsableMantenimientoTres[0];
            n331TicketResponsableMantenimientoTres = P00752_n331TicketResponsableMantenimientoTres[0];
            A332TicketResponsableMantenimientoCuatro = P00752_A332TicketResponsableMantenimientoCuatro[0];
            n332TicketResponsableMantenimientoCuatro = P00752_n332TicketResponsableMantenimientoCuatro[0];
            A333TicketResponsableMantenimientoCinco = P00752_A333TicketResponsableMantenimientoCinco[0];
            n333TicketResponsableMantenimientoCinco = P00752_n333TicketResponsableMantenimientoCinco[0];
            A334TicketResponsableMantenimientoSeis = P00752_A334TicketResponsableMantenimientoSeis[0];
            n334TicketResponsableMantenimientoSeis = P00752_n334TicketResponsableMantenimientoSeis[0];
            A335TicketResponsableMantenimientoSiete = P00752_A335TicketResponsableMantenimientoSiete[0];
            n335TicketResponsableMantenimientoSiete = P00752_n335TicketResponsableMantenimientoSiete[0];
            A336TicketResponsableGestionbdUno = P00752_A336TicketResponsableGestionbdUno[0];
            n336TicketResponsableGestionbdUno = P00752_n336TicketResponsableGestionbdUno[0];
            A337TicketResponsableGestionbdDos = P00752_A337TicketResponsableGestionbdDos[0];
            n337TicketResponsableGestionbdDos = P00752_n337TicketResponsableGestionbdDos[0];
            A338TicketResponsableGestionbdTres = P00752_A338TicketResponsableGestionbdTres[0];
            n338TicketResponsableGestionbdTres = P00752_n338TicketResponsableGestionbdTres[0];
            A339TicketResponsableGestionbdCuatro = P00752_A339TicketResponsableGestionbdCuatro[0];
            n339TicketResponsableGestionbdCuatro = P00752_n339TicketResponsableGestionbdCuatro[0];
            A340TicketResponsableMantenimientobdUno = P00752_A340TicketResponsableMantenimientobdUno[0];
            n340TicketResponsableMantenimientobdUno = P00752_n340TicketResponsableMantenimientobdUno[0];
            A341TicketResponsableMantenimientobdDos = P00752_A341TicketResponsableMantenimientobdDos[0];
            n341TicketResponsableMantenimientobdDos = P00752_n341TicketResponsableMantenimientobdDos[0];
            A342TicketResponsableMantenimientobdTres = P00752_A342TicketResponsableMantenimientobdTres[0];
            n342TicketResponsableMantenimientobdTres = P00752_n342TicketResponsableMantenimientobdTres[0];
            A343TicketResponsableMantenimientobdCuatro = P00752_A343TicketResponsableMantenimientobdCuatro[0];
            n343TicketResponsableMantenimientobdCuatro = P00752_n343TicketResponsableMantenimientobdCuatro[0];
            A344TicketResponsableMantenimientobdCinco = P00752_A344TicketResponsableMantenimientobdCinco[0];
            n344TicketResponsableMantenimientobdCinco = P00752_n344TicketResponsableMantenimientobdCinco[0];
            A345TicketResponsableMantenimientobdSeis = P00752_A345TicketResponsableMantenimientobdSeis[0];
            n345TicketResponsableMantenimientobdSeis = P00752_n345TicketResponsableMantenimientobdSeis[0];
            A346TicketResponsableMantenimientobdSiete = P00752_A346TicketResponsableMantenimientobdSiete[0];
            n346TicketResponsableMantenimientobdSiete = P00752_n346TicketResponsableMantenimientobdSiete[0];
            A165TicketResponsableCerrado = P00752_A165TicketResponsableCerrado[0];
            n165TicketResponsableCerrado = P00752_n165TicketResponsableCerrado[0];
            A168TicketResponsableObservacion = P00752_A168TicketResponsableObservacion[0];
            n168TicketResponsableObservacion = P00752_n168TicketResponsableObservacion[0];
            A175TicketResponsableFechaResuelve = P00752_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = P00752_n175TicketResponsableFechaResuelve[0];
            A176TicketResponsableHoraResuelve = P00752_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = P00752_n176TicketResponsableHoraResuelve[0];
            A14TicketId = P00752_A14TicketId[0];
            A17EstadoTicketTecnicoId = AV46EstadoTicketTicketId;
            A305TicketResponsableAnalasisUno = AV49TicketResponsableAnalasisUno;
            n305TicketResponsableAnalasisUno = false;
            A306TicketResponsableAnalasisDos = AV50TicketResponsableAnalasisDos;
            n306TicketResponsableAnalasisDos = false;
            A307TicketResponsableAnalasisTres = AV51TicketResponsableAnalasisTres;
            n307TicketResponsableAnalasisTres = false;
            A308TicketResponsableAnalasisCuatro = AV52TicketResponsableAnalasisCuatro;
            n308TicketResponsableAnalasisCuatro = false;
            A309TicketResponsableDisenioUno = AV53TicketResponsableDisenioUno;
            n309TicketResponsableDisenioUno = false;
            A310TicketResponsableDesarrolloUno = AV54TicketResponsableDesarrolloUno;
            n310TicketResponsableDesarrolloUno = false;
            A311TicketResponsableDesarrolloDos = AV55TicketResponsableDesarrolloDos;
            n311TicketResponsableDesarrolloDos = false;
            A312TicketResponsableDesarrolloTres = AV56TicketResponsableDesarrolloTres;
            n312TicketResponsableDesarrolloTres = false;
            A313TicketResponsableDesarrolloCuatro = AV57TicketResponsableDesarrolloCuatro;
            n313TicketResponsableDesarrolloCuatro = false;
            A314TicketResponsableDesarrolloCinco = AV58TicketResponsableDesarrolloCinco;
            n314TicketResponsableDesarrolloCinco = false;
            A315TicketResponsablePruebasUno = AV59TicketResponsablePruebasUno;
            n315TicketResponsablePruebasUno = false;
            A316TicketResponsablePruebasDos = AV60TicketResponsablePruebasDos;
            n316TicketResponsablePruebasDos = false;
            A317TicketResponsablePruebasTres = AV61TicketResponsablePruebasTres;
            n317TicketResponsablePruebasTres = false;
            A318TicketResponsablePruebasCuatro = AV62TicketResponsablePruebasCuatro;
            n318TicketResponsablePruebasCuatro = false;
            A319TicketResponsableDocumentacionUno = AV63TicketResponsableDocumentacionUno;
            n319TicketResponsableDocumentacionUno = false;
            A320TicketResponsableDocumentacionDos = AV64TicketResponsableDocumentacionDos;
            n320TicketResponsableDocumentacionDos = false;
            A321TicketResponsableDocumentacionTres = AV65TicketResponsableDocumentacionTres;
            n321TicketResponsableDocumentacionTres = false;
            A322TicketResponsableDocumentacionCuatro = AV66TicketResponsableDocumentacionCuatro;
            n322TicketResponsableDocumentacionCuatro = false;
            A323TicketResponsableImplementacionUno = AV67TicketResponsableImplementacionUno;
            n323TicketResponsableImplementacionUno = false;
            A324TicketResponsableImplementacionDos = AV68TicketResponsableImplementacionDos;
            n324TicketResponsableImplementacionDos = false;
            A325TicketResponsableImplementacionTres = AV69TicketResponsableImplementacionTres;
            n325TicketResponsableImplementacionTres = false;
            A326TicketResponsableImplementacionCuatro = AV70TicketResponsableImplementacionCuatro;
            n326TicketResponsableImplementacionCuatro = false;
            A327TicketResponsableImplementacionCinco = AV71TicketResponsableImplementacionCinco;
            n327TicketResponsableImplementacionCinco = false;
            A328TicketResponsableImplementacionSeis = AV72TicketResponsableImplementacionSeis;
            n328TicketResponsableImplementacionSeis = false;
            A329TicketResponsableMantenimientoUno = AV73TicketResponsableMantenimientoUno;
            n329TicketResponsableMantenimientoUno = false;
            A330TicketResponsableMantenimientoDos = AV74TicketResponsableMantenimientoDos;
            n330TicketResponsableMantenimientoDos = false;
            A331TicketResponsableMantenimientoTres = AV75TicketResponsableMantenimientoTres;
            n331TicketResponsableMantenimientoTres = false;
            A332TicketResponsableMantenimientoCuatro = AV76TicketResponsableMantenimientoCuatro;
            n332TicketResponsableMantenimientoCuatro = false;
            A333TicketResponsableMantenimientoCinco = AV77TicketResponsableMantenimientoCinco;
            n333TicketResponsableMantenimientoCinco = false;
            A334TicketResponsableMantenimientoSeis = AV78TicketResponsableMantenimientoSeis;
            n334TicketResponsableMantenimientoSeis = false;
            A335TicketResponsableMantenimientoSiete = AV79TicketResponsableMantenimientoSiete;
            n335TicketResponsableMantenimientoSiete = false;
            A336TicketResponsableGestionbdUno = AV80TicketResponsableGestionbdUno;
            n336TicketResponsableGestionbdUno = false;
            A337TicketResponsableGestionbdDos = AV81TicketResponsableGestionbdDos;
            n337TicketResponsableGestionbdDos = false;
            A338TicketResponsableGestionbdTres = AV82TicketResponsableGestionbdTres;
            n338TicketResponsableGestionbdTres = false;
            A339TicketResponsableGestionbdCuatro = AV83TicketResponsableGestionbdCuatro;
            n339TicketResponsableGestionbdCuatro = false;
            A340TicketResponsableMantenimientobdUno = AV84TicketResponsableMantenimientobdUno;
            n340TicketResponsableMantenimientobdUno = false;
            A341TicketResponsableMantenimientobdDos = AV85TicketResponsableMantenimientobdDos;
            n341TicketResponsableMantenimientobdDos = false;
            A342TicketResponsableMantenimientobdTres = AV48TicketResponsableMantenimientobdTres;
            n342TicketResponsableMantenimientobdTres = false;
            A343TicketResponsableMantenimientobdCuatro = AV86TicketResponsableMantenimientobdCuatro;
            n343TicketResponsableMantenimientobdCuatro = false;
            A344TicketResponsableMantenimientobdCinco = AV87TicketResponsableMantenimientobdCinco;
            n344TicketResponsableMantenimientobdCinco = false;
            A345TicketResponsableMantenimientobdSeis = AV88TicketResponsableMantenimientobdSeis;
            n345TicketResponsableMantenimientobdSeis = false;
            A346TicketResponsableMantenimientobdSiete = AV89TicketResponsableMantenimientobdSiete;
            n346TicketResponsableMantenimientobdSiete = false;
            A165TicketResponsableCerrado = true;
            n165TicketResponsableCerrado = false;
            A168TicketResponsableObservacion = AV22TicketResponsableObservacion;
            n168TicketResponsableObservacion = false;
            A175TicketResponsableFechaResuelve = DateTimeUtil.Today( context);
            n175TicketResponsableFechaResuelve = false;
            A176TicketResponsableHoraResuelve = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            n176TicketResponsableHoraResuelve = false;
            /* Using cursor P00753 */
            pr_default.execute(1, new Object[] {A17EstadoTicketTecnicoId, n305TicketResponsableAnalasisUno, A305TicketResponsableAnalasisUno, n306TicketResponsableAnalasisDos, A306TicketResponsableAnalasisDos, n307TicketResponsableAnalasisTres, A307TicketResponsableAnalasisTres, n308TicketResponsableAnalasisCuatro, A308TicketResponsableAnalasisCuatro, n309TicketResponsableDisenioUno, A309TicketResponsableDisenioUno, n310TicketResponsableDesarrolloUno, A310TicketResponsableDesarrolloUno, n311TicketResponsableDesarrolloDos, A311TicketResponsableDesarrolloDos, n312TicketResponsableDesarrolloTres, A312TicketResponsableDesarrolloTres, n313TicketResponsableDesarrolloCuatro, A313TicketResponsableDesarrolloCuatro, n314TicketResponsableDesarrolloCinco, A314TicketResponsableDesarrolloCinco, n315TicketResponsablePruebasUno, A315TicketResponsablePruebasUno, n316TicketResponsablePruebasDos, A316TicketResponsablePruebasDos, n317TicketResponsablePruebasTres, A317TicketResponsablePruebasTres, n318TicketResponsablePruebasCuatro, A318TicketResponsablePruebasCuatro, n319TicketResponsableDocumentacionUno, A319TicketResponsableDocumentacionUno, n320TicketResponsableDocumentacionDos, A320TicketResponsableDocumentacionDos, n321TicketResponsableDocumentacionTres, A321TicketResponsableDocumentacionTres, n322TicketResponsableDocumentacionCuatro, A322TicketResponsableDocumentacionCuatro, n323TicketResponsableImplementacionUno, A323TicketResponsableImplementacionUno, n324TicketResponsableImplementacionDos, A324TicketResponsableImplementacionDos, n325TicketResponsableImplementacionTres, A325TicketResponsableImplementacionTres, n326TicketResponsableImplementacionCuatro, A326TicketResponsableImplementacionCuatro, n327TicketResponsableImplementacionCinco, A327TicketResponsableImplementacionCinco, n328TicketResponsableImplementacionSeis, A328TicketResponsableImplementacionSeis, n329TicketResponsableMantenimientoUno, A329TicketResponsableMantenimientoUno, n330TicketResponsableMantenimientoDos, A330TicketResponsableMantenimientoDos, n331TicketResponsableMantenimientoTres, A331TicketResponsableMantenimientoTres, n332TicketResponsableMantenimientoCuatro, A332TicketResponsableMantenimientoCuatro, n333TicketResponsableMantenimientoCinco, A333TicketResponsableMantenimientoCinco, n334TicketResponsableMantenimientoSeis, A334TicketResponsableMantenimientoSeis, n335TicketResponsableMantenimientoSiete, A335TicketResponsableMantenimientoSiete, n336TicketResponsableGestionbdUno, A336TicketResponsableGestionbdUno, n337TicketResponsableGestionbdDos, A337TicketResponsableGestionbdDos, n338TicketResponsableGestionbdTres, A338TicketResponsableGestionbdTres, n339TicketResponsableGestionbdCuatro, A339TicketResponsableGestionbdCuatro, n340TicketResponsableMantenimientobdUno, A340TicketResponsableMantenimientobdUno, n341TicketResponsableMantenimientobdDos, A341TicketResponsableMantenimientobdDos, n342TicketResponsableMantenimientobdTres, A342TicketResponsableMantenimientobdTres, n343TicketResponsableMantenimientobdCuatro, A343TicketResponsableMantenimientobdCuatro, n344TicketResponsableMantenimientobdCinco, A344TicketResponsableMantenimientobdCinco, n345TicketResponsableMantenimientobdSeis, A345TicketResponsableMantenimientobdSeis, n346TicketResponsableMantenimientobdSiete, A346TicketResponsableMantenimientobdSiete, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n168TicketResponsableObservacion, A168TicketResponsableObservacion, n175TicketResponsableFechaResuelve, A175TicketResponsableFechaResuelve, n176TicketResponsableHoraResuelve, A176TicketResponsableHoraResuelve, A14TicketId, A16TicketResponsableId});
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
         A248detalle_infotecid_unidad = (int)(NumberUtil.Val( AV40WebSession.Get("id_unidad_tecnico"), "."));
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
            AV93Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV93Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 2;
            n290EtapaDesarrolloId = false;
            /* Using cursor P00757 */
            pr_default.execute(3, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
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
            /* Optimized UPDATE. */
            /* Using cursor P00758 */
            pr_default.execute(4, new Object[] {AV93Ticketresponsablesig, AV24TicketId, AV23UsuarioId});
            pr_default.close(4);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 2 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007510 */
            pr_default.execute(5);
            if ( (pr_default.getStatus(5) != 101) )
            {
               A40000GXC1 = P007510_A40000GXC1[0];
               n40000GXC1 = P007510_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(5);
            AV93Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV93Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 3;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007511 */
            pr_default.execute(6, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(6);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(6) == 1) )
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
            /* Optimized UPDATE. */
            /* Using cursor P007512 */
            pr_default.execute(7, new Object[] {AV93Ticketresponsablesig, AV24TicketId, AV23UsuarioId});
            pr_default.close(7);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 3 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007514 */
            pr_default.execute(8);
            if ( (pr_default.getStatus(8) != 101) )
            {
               A40000GXC1 = P007514_A40000GXC1[0];
               n40000GXC1 = P007514_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(8);
            AV93Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV93Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 4;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007515 */
            pr_default.execute(9, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
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
            /* Optimized UPDATE. */
            /* Using cursor P007516 */
            pr_default.execute(10, new Object[] {AV93Ticketresponsablesig, AV24TicketId, AV23UsuarioId});
            pr_default.close(10);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 4 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007518 */
            pr_default.execute(11);
            if ( (pr_default.getStatus(11) != 101) )
            {
               A40000GXC1 = P007518_A40000GXC1[0];
               n40000GXC1 = P007518_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(11);
            AV93Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV93Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 5;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007519 */
            pr_default.execute(12, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(12);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(12) == 1) )
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
            /* Optimized UPDATE. */
            /* Using cursor P007520 */
            pr_default.execute(13, new Object[] {AV93Ticketresponsablesig, AV24TicketId, AV23UsuarioId});
            pr_default.close(13);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 5 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007522 */
            pr_default.execute(14);
            if ( (pr_default.getStatus(14) != 101) )
            {
               A40000GXC1 = P007522_A40000GXC1[0];
               n40000GXC1 = P007522_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(14);
            AV93Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV93Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 6;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007523 */
            pr_default.execute(15, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(15);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(15) == 1) )
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
            /* Optimized UPDATE. */
            /* Using cursor P007524 */
            pr_default.execute(16, new Object[] {AV93Ticketresponsablesig, AV24TicketId, AV23UsuarioId});
            pr_default.close(16);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 6 )
         {
            /*
               INSERT RECORD ON TABLE TicketResponsable

            */
            /* Using cursor P007526 */
            pr_default.execute(17);
            if ( (pr_default.getStatus(17) != 101) )
            {
               A40000GXC1 = P007526_A40000GXC1[0];
               n40000GXC1 = P007526_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
            }
            pr_default.close(17);
            AV93Ticketresponsablesig = (long)(A40000GXC1+1);
            A14TicketId = AV24TicketId;
            A16TicketResponsableId = AV93Ticketresponsablesig;
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
            A198TicketTecnicoResponsableId = AV45TicketTecnicoResponsableId;
            A17EstadoTicketTecnicoId = 3;
            A290EtapaDesarrolloId = 7;
            n290EtapaDesarrolloId = false;
            /* Using cursor P007527 */
            pr_default.execute(18, new Object[] {A14TicketId, A16TicketResponsableId, A47TicketFechaResponsable, A49TicketHoraResponsable, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            pr_default.close(18);
            dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
            if ( (pr_default.getStatus(18) == 1) )
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
            /* Optimized UPDATE. */
            /* Using cursor P007528 */
            pr_default.execute(19, new Object[] {AV93Ticketresponsablesig, AV24TicketId, AV23UsuarioId});
            pr_default.close(19);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 7 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P007529 */
            pr_default.execute(20, new Object[] {AV24TicketId, AV23UsuarioId});
            pr_default.close(20);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
            /* Optimized UPDATE. */
            /* Using cursor P007530 */
            pr_default.execute(21, new Object[] {AV23UsuarioId});
            pr_default.close(21);
            dsDefault.SmartCacheProvider.SetUpdated("Usuario");
            /* End optimized UPDATE. */
         }
         if ( AV47EtapaDesarrolloId == 9 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P007531 */
            pr_default.execute(22, new Object[] {AV24TicketId, AV23UsuarioId});
            pr_default.close(22);
            dsDefault.SmartCacheProvider.SetUpdated("Ticket");
            /* End optimized UPDATE. */
            /* Optimized UPDATE. */
            /* Using cursor P007532 */
            pr_default.execute(23, new Object[] {AV23UsuarioId});
            pr_default.close(23);
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
         pr_default.close(17);
         pr_default.close(14);
         pr_default.close(11);
         pr_default.close(8);
         pr_default.close(5);
         pr_default.close(2);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P00752_A17EstadoTicketTecnicoId = new short[1] ;
         P00752_A198TicketTecnicoResponsableId = new short[1] ;
         P00752_A16TicketResponsableId = new long[1] ;
         P00752_A305TicketResponsableAnalasisUno = new bool[] {false} ;
         P00752_n305TicketResponsableAnalasisUno = new bool[] {false} ;
         P00752_A306TicketResponsableAnalasisDos = new bool[] {false} ;
         P00752_n306TicketResponsableAnalasisDos = new bool[] {false} ;
         P00752_A307TicketResponsableAnalasisTres = new bool[] {false} ;
         P00752_n307TicketResponsableAnalasisTres = new bool[] {false} ;
         P00752_A308TicketResponsableAnalasisCuatro = new bool[] {false} ;
         P00752_n308TicketResponsableAnalasisCuatro = new bool[] {false} ;
         P00752_A309TicketResponsableDisenioUno = new bool[] {false} ;
         P00752_n309TicketResponsableDisenioUno = new bool[] {false} ;
         P00752_A310TicketResponsableDesarrolloUno = new bool[] {false} ;
         P00752_n310TicketResponsableDesarrolloUno = new bool[] {false} ;
         P00752_A311TicketResponsableDesarrolloDos = new bool[] {false} ;
         P00752_n311TicketResponsableDesarrolloDos = new bool[] {false} ;
         P00752_A312TicketResponsableDesarrolloTres = new bool[] {false} ;
         P00752_n312TicketResponsableDesarrolloTres = new bool[] {false} ;
         P00752_A313TicketResponsableDesarrolloCuatro = new bool[] {false} ;
         P00752_n313TicketResponsableDesarrolloCuatro = new bool[] {false} ;
         P00752_A314TicketResponsableDesarrolloCinco = new bool[] {false} ;
         P00752_n314TicketResponsableDesarrolloCinco = new bool[] {false} ;
         P00752_A315TicketResponsablePruebasUno = new bool[] {false} ;
         P00752_n315TicketResponsablePruebasUno = new bool[] {false} ;
         P00752_A316TicketResponsablePruebasDos = new bool[] {false} ;
         P00752_n316TicketResponsablePruebasDos = new bool[] {false} ;
         P00752_A317TicketResponsablePruebasTres = new bool[] {false} ;
         P00752_n317TicketResponsablePruebasTres = new bool[] {false} ;
         P00752_A318TicketResponsablePruebasCuatro = new bool[] {false} ;
         P00752_n318TicketResponsablePruebasCuatro = new bool[] {false} ;
         P00752_A319TicketResponsableDocumentacionUno = new bool[] {false} ;
         P00752_n319TicketResponsableDocumentacionUno = new bool[] {false} ;
         P00752_A320TicketResponsableDocumentacionDos = new bool[] {false} ;
         P00752_n320TicketResponsableDocumentacionDos = new bool[] {false} ;
         P00752_A321TicketResponsableDocumentacionTres = new bool[] {false} ;
         P00752_n321TicketResponsableDocumentacionTres = new bool[] {false} ;
         P00752_A322TicketResponsableDocumentacionCuatro = new bool[] {false} ;
         P00752_n322TicketResponsableDocumentacionCuatro = new bool[] {false} ;
         P00752_A323TicketResponsableImplementacionUno = new bool[] {false} ;
         P00752_n323TicketResponsableImplementacionUno = new bool[] {false} ;
         P00752_A324TicketResponsableImplementacionDos = new bool[] {false} ;
         P00752_n324TicketResponsableImplementacionDos = new bool[] {false} ;
         P00752_A325TicketResponsableImplementacionTres = new bool[] {false} ;
         P00752_n325TicketResponsableImplementacionTres = new bool[] {false} ;
         P00752_A326TicketResponsableImplementacionCuatro = new bool[] {false} ;
         P00752_n326TicketResponsableImplementacionCuatro = new bool[] {false} ;
         P00752_A327TicketResponsableImplementacionCinco = new bool[] {false} ;
         P00752_n327TicketResponsableImplementacionCinco = new bool[] {false} ;
         P00752_A328TicketResponsableImplementacionSeis = new bool[] {false} ;
         P00752_n328TicketResponsableImplementacionSeis = new bool[] {false} ;
         P00752_A329TicketResponsableMantenimientoUno = new bool[] {false} ;
         P00752_n329TicketResponsableMantenimientoUno = new bool[] {false} ;
         P00752_A330TicketResponsableMantenimientoDos = new bool[] {false} ;
         P00752_n330TicketResponsableMantenimientoDos = new bool[] {false} ;
         P00752_A331TicketResponsableMantenimientoTres = new bool[] {false} ;
         P00752_n331TicketResponsableMantenimientoTres = new bool[] {false} ;
         P00752_A332TicketResponsableMantenimientoCuatro = new bool[] {false} ;
         P00752_n332TicketResponsableMantenimientoCuatro = new bool[] {false} ;
         P00752_A333TicketResponsableMantenimientoCinco = new bool[] {false} ;
         P00752_n333TicketResponsableMantenimientoCinco = new bool[] {false} ;
         P00752_A334TicketResponsableMantenimientoSeis = new bool[] {false} ;
         P00752_n334TicketResponsableMantenimientoSeis = new bool[] {false} ;
         P00752_A335TicketResponsableMantenimientoSiete = new bool[] {false} ;
         P00752_n335TicketResponsableMantenimientoSiete = new bool[] {false} ;
         P00752_A336TicketResponsableGestionbdUno = new bool[] {false} ;
         P00752_n336TicketResponsableGestionbdUno = new bool[] {false} ;
         P00752_A337TicketResponsableGestionbdDos = new bool[] {false} ;
         P00752_n337TicketResponsableGestionbdDos = new bool[] {false} ;
         P00752_A338TicketResponsableGestionbdTres = new bool[] {false} ;
         P00752_n338TicketResponsableGestionbdTres = new bool[] {false} ;
         P00752_A339TicketResponsableGestionbdCuatro = new bool[] {false} ;
         P00752_n339TicketResponsableGestionbdCuatro = new bool[] {false} ;
         P00752_A340TicketResponsableMantenimientobdUno = new bool[] {false} ;
         P00752_n340TicketResponsableMantenimientobdUno = new bool[] {false} ;
         P00752_A341TicketResponsableMantenimientobdDos = new bool[] {false} ;
         P00752_n341TicketResponsableMantenimientobdDos = new bool[] {false} ;
         P00752_A342TicketResponsableMantenimientobdTres = new bool[] {false} ;
         P00752_n342TicketResponsableMantenimientobdTres = new bool[] {false} ;
         P00752_A343TicketResponsableMantenimientobdCuatro = new bool[] {false} ;
         P00752_n343TicketResponsableMantenimientobdCuatro = new bool[] {false} ;
         P00752_A344TicketResponsableMantenimientobdCinco = new bool[] {false} ;
         P00752_n344TicketResponsableMantenimientobdCinco = new bool[] {false} ;
         P00752_A345TicketResponsableMantenimientobdSeis = new bool[] {false} ;
         P00752_n345TicketResponsableMantenimientobdSeis = new bool[] {false} ;
         P00752_A346TicketResponsableMantenimientobdSiete = new bool[] {false} ;
         P00752_n346TicketResponsableMantenimientobdSiete = new bool[] {false} ;
         P00752_A165TicketResponsableCerrado = new bool[] {false} ;
         P00752_n165TicketResponsableCerrado = new bool[] {false} ;
         P00752_A168TicketResponsableObservacion = new string[] {""} ;
         P00752_n168TicketResponsableObservacion = new bool[] {false} ;
         P00752_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         P00752_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         P00752_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         P00752_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         P00752_A14TicketId = new long[1] ;
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
         P007510_A40000GXC1 = new long[1] ;
         P007510_n40000GXC1 = new bool[] {false} ;
         P007514_A40000GXC1 = new long[1] ;
         P007514_n40000GXC1 = new bool[] {false} ;
         P007518_A40000GXC1 = new long[1] ;
         P007518_n40000GXC1 = new bool[] {false} ;
         P007522_A40000GXC1 = new long[1] ;
         P007522_n40000GXC1 = new bool[] {false} ;
         P007526_A40000GXC1 = new long[1] ;
         P007526_n40000GXC1 = new bool[] {false} ;
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
               P00752_A17EstadoTicketTecnicoId, P00752_A198TicketTecnicoResponsableId, P00752_A16TicketResponsableId, P00752_A305TicketResponsableAnalasisUno, P00752_n305TicketResponsableAnalasisUno, P00752_A306TicketResponsableAnalasisDos, P00752_n306TicketResponsableAnalasisDos, P00752_A307TicketResponsableAnalasisTres, P00752_n307TicketResponsableAnalasisTres, P00752_A308TicketResponsableAnalasisCuatro,
               P00752_n308TicketResponsableAnalasisCuatro, P00752_A309TicketResponsableDisenioUno, P00752_n309TicketResponsableDisenioUno, P00752_A310TicketResponsableDesarrolloUno, P00752_n310TicketResponsableDesarrolloUno, P00752_A311TicketResponsableDesarrolloDos, P00752_n311TicketResponsableDesarrolloDos, P00752_A312TicketResponsableDesarrolloTres, P00752_n312TicketResponsableDesarrolloTres, P00752_A313TicketResponsableDesarrolloCuatro,
               P00752_n313TicketResponsableDesarrolloCuatro, P00752_A314TicketResponsableDesarrolloCinco, P00752_n314TicketResponsableDesarrolloCinco, P00752_A315TicketResponsablePruebasUno, P00752_n315TicketResponsablePruebasUno, P00752_A316TicketResponsablePruebasDos, P00752_n316TicketResponsablePruebasDos, P00752_A317TicketResponsablePruebasTres, P00752_n317TicketResponsablePruebasTres, P00752_A318TicketResponsablePruebasCuatro,
               P00752_n318TicketResponsablePruebasCuatro, P00752_A319TicketResponsableDocumentacionUno, P00752_n319TicketResponsableDocumentacionUno, P00752_A320TicketResponsableDocumentacionDos, P00752_n320TicketResponsableDocumentacionDos, P00752_A321TicketResponsableDocumentacionTres, P00752_n321TicketResponsableDocumentacionTres, P00752_A322TicketResponsableDocumentacionCuatro, P00752_n322TicketResponsableDocumentacionCuatro, P00752_A323TicketResponsableImplementacionUno,
               P00752_n323TicketResponsableImplementacionUno, P00752_A324TicketResponsableImplementacionDos, P00752_n324TicketResponsableImplementacionDos, P00752_A325TicketResponsableImplementacionTres, P00752_n325TicketResponsableImplementacionTres, P00752_A326TicketResponsableImplementacionCuatro, P00752_n326TicketResponsableImplementacionCuatro, P00752_A327TicketResponsableImplementacionCinco, P00752_n327TicketResponsableImplementacionCinco, P00752_A328TicketResponsableImplementacionSeis,
               P00752_n328TicketResponsableImplementacionSeis, P00752_A329TicketResponsableMantenimientoUno, P00752_n329TicketResponsableMantenimientoUno, P00752_A330TicketResponsableMantenimientoDos, P00752_n330TicketResponsableMantenimientoDos, P00752_A331TicketResponsableMantenimientoTres, P00752_n331TicketResponsableMantenimientoTres, P00752_A332TicketResponsableMantenimientoCuatro, P00752_n332TicketResponsableMantenimientoCuatro, P00752_A333TicketResponsableMantenimientoCinco,
               P00752_n333TicketResponsableMantenimientoCinco, P00752_A334TicketResponsableMantenimientoSeis, P00752_n334TicketResponsableMantenimientoSeis, P00752_A335TicketResponsableMantenimientoSiete, P00752_n335TicketResponsableMantenimientoSiete, P00752_A336TicketResponsableGestionbdUno, P00752_n336TicketResponsableGestionbdUno, P00752_A337TicketResponsableGestionbdDos, P00752_n337TicketResponsableGestionbdDos, P00752_A338TicketResponsableGestionbdTres,
               P00752_n338TicketResponsableGestionbdTres, P00752_A339TicketResponsableGestionbdCuatro, P00752_n339TicketResponsableGestionbdCuatro, P00752_A340TicketResponsableMantenimientobdUno, P00752_n340TicketResponsableMantenimientobdUno, P00752_A341TicketResponsableMantenimientobdDos, P00752_n341TicketResponsableMantenimientobdDos, P00752_A342TicketResponsableMantenimientobdTres, P00752_n342TicketResponsableMantenimientobdTres, P00752_A343TicketResponsableMantenimientobdCuatro,
               P00752_n343TicketResponsableMantenimientobdCuatro, P00752_A344TicketResponsableMantenimientobdCinco, P00752_n344TicketResponsableMantenimientobdCinco, P00752_A345TicketResponsableMantenimientobdSeis, P00752_n345TicketResponsableMantenimientobdSeis, P00752_A346TicketResponsableMantenimientobdSiete, P00752_n346TicketResponsableMantenimientobdSiete, P00752_A165TicketResponsableCerrado, P00752_n165TicketResponsableCerrado, P00752_A168TicketResponsableObservacion,
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
               }
               , new Object[] {
               P007510_A40000GXC1, P007510_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P007514_A40000GXC1, P007514_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P007518_A40000GXC1, P007518_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P007522_A40000GXC1, P007522_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P007526_A40000GXC1, P007526_n40000GXC1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
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
      private long AV23UsuarioId ;
      private long AV8TicketResponsableId ;
      private long A16TicketResponsableId ;
      private long A14TicketId ;
      private long A40000GXC1 ;
      private long AV93Ticketresponsablesig ;
      private long A54TicketLastId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A176TicketResponsableHoraResuelve ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime AV39UsuarioFecha ;
      private DateTime A175TicketResponsableFechaResuelve ;
      private DateTime A241fecha_registro ;
      private DateTime A47TicketFechaResponsable ;
      private bool AV49TicketResponsableAnalasisUno ;
      private bool AV50TicketResponsableAnalasisDos ;
      private bool AV51TicketResponsableAnalasisTres ;
      private bool AV52TicketResponsableAnalasisCuatro ;
      private bool AV53TicketResponsableDisenioUno ;
      private bool AV54TicketResponsableDesarrolloUno ;
      private bool AV55TicketResponsableDesarrolloDos ;
      private bool AV56TicketResponsableDesarrolloTres ;
      private bool AV57TicketResponsableDesarrolloCuatro ;
      private bool AV58TicketResponsableDesarrolloCinco ;
      private bool AV59TicketResponsablePruebasUno ;
      private bool AV60TicketResponsablePruebasDos ;
      private bool AV61TicketResponsablePruebasTres ;
      private bool AV62TicketResponsablePruebasCuatro ;
      private bool AV63TicketResponsableDocumentacionUno ;
      private bool AV64TicketResponsableDocumentacionDos ;
      private bool AV65TicketResponsableDocumentacionTres ;
      private bool AV66TicketResponsableDocumentacionCuatro ;
      private bool AV67TicketResponsableImplementacionUno ;
      private bool AV68TicketResponsableImplementacionDos ;
      private bool AV69TicketResponsableImplementacionTres ;
      private bool AV70TicketResponsableImplementacionCuatro ;
      private bool AV71TicketResponsableImplementacionCinco ;
      private bool AV72TicketResponsableImplementacionSeis ;
      private bool AV73TicketResponsableMantenimientoUno ;
      private bool AV74TicketResponsableMantenimientoDos ;
      private bool AV75TicketResponsableMantenimientoTres ;
      private bool AV76TicketResponsableMantenimientoCuatro ;
      private bool AV77TicketResponsableMantenimientoCinco ;
      private bool AV78TicketResponsableMantenimientoSeis ;
      private bool AV79TicketResponsableMantenimientoSiete ;
      private bool AV80TicketResponsableGestionbdUno ;
      private bool AV81TicketResponsableGestionbdDos ;
      private bool AV82TicketResponsableGestionbdTres ;
      private bool AV83TicketResponsableGestionbdCuatro ;
      private bool AV84TicketResponsableMantenimientobdUno ;
      private bool AV85TicketResponsableMantenimientobdDos ;
      private bool AV48TicketResponsableMantenimientobdTres ;
      private bool AV86TicketResponsableMantenimientobdCuatro ;
      private bool AV87TicketResponsableMantenimientobdCinco ;
      private bool AV88TicketResponsableMantenimientobdSeis ;
      private bool AV89TicketResponsableMantenimientobdSiete ;
      private bool A305TicketResponsableAnalasisUno ;
      private bool n305TicketResponsableAnalasisUno ;
      private bool A306TicketResponsableAnalasisDos ;
      private bool n306TicketResponsableAnalasisDos ;
      private bool A307TicketResponsableAnalasisTres ;
      private bool n307TicketResponsableAnalasisTres ;
      private bool A308TicketResponsableAnalasisCuatro ;
      private bool n308TicketResponsableAnalasisCuatro ;
      private bool A309TicketResponsableDisenioUno ;
      private bool n309TicketResponsableDisenioUno ;
      private bool A310TicketResponsableDesarrolloUno ;
      private bool n310TicketResponsableDesarrolloUno ;
      private bool A311TicketResponsableDesarrolloDos ;
      private bool n311TicketResponsableDesarrolloDos ;
      private bool A312TicketResponsableDesarrolloTres ;
      private bool n312TicketResponsableDesarrolloTres ;
      private bool A313TicketResponsableDesarrolloCuatro ;
      private bool n313TicketResponsableDesarrolloCuatro ;
      private bool A314TicketResponsableDesarrolloCinco ;
      private bool n314TicketResponsableDesarrolloCinco ;
      private bool A315TicketResponsablePruebasUno ;
      private bool n315TicketResponsablePruebasUno ;
      private bool A316TicketResponsablePruebasDos ;
      private bool n316TicketResponsablePruebasDos ;
      private bool A317TicketResponsablePruebasTres ;
      private bool n317TicketResponsablePruebasTres ;
      private bool A318TicketResponsablePruebasCuatro ;
      private bool n318TicketResponsablePruebasCuatro ;
      private bool A319TicketResponsableDocumentacionUno ;
      private bool n319TicketResponsableDocumentacionUno ;
      private bool A320TicketResponsableDocumentacionDos ;
      private bool n320TicketResponsableDocumentacionDos ;
      private bool A321TicketResponsableDocumentacionTres ;
      private bool n321TicketResponsableDocumentacionTres ;
      private bool A322TicketResponsableDocumentacionCuatro ;
      private bool n322TicketResponsableDocumentacionCuatro ;
      private bool A323TicketResponsableImplementacionUno ;
      private bool n323TicketResponsableImplementacionUno ;
      private bool A324TicketResponsableImplementacionDos ;
      private bool n324TicketResponsableImplementacionDos ;
      private bool A325TicketResponsableImplementacionTres ;
      private bool n325TicketResponsableImplementacionTres ;
      private bool A326TicketResponsableImplementacionCuatro ;
      private bool n326TicketResponsableImplementacionCuatro ;
      private bool A327TicketResponsableImplementacionCinco ;
      private bool n327TicketResponsableImplementacionCinco ;
      private bool A328TicketResponsableImplementacionSeis ;
      private bool n328TicketResponsableImplementacionSeis ;
      private bool A329TicketResponsableMantenimientoUno ;
      private bool n329TicketResponsableMantenimientoUno ;
      private bool A330TicketResponsableMantenimientoDos ;
      private bool n330TicketResponsableMantenimientoDos ;
      private bool A331TicketResponsableMantenimientoTres ;
      private bool n331TicketResponsableMantenimientoTres ;
      private bool A332TicketResponsableMantenimientoCuatro ;
      private bool n332TicketResponsableMantenimientoCuatro ;
      private bool A333TicketResponsableMantenimientoCinco ;
      private bool n333TicketResponsableMantenimientoCinco ;
      private bool A334TicketResponsableMantenimientoSeis ;
      private bool n334TicketResponsableMantenimientoSeis ;
      private bool A335TicketResponsableMantenimientoSiete ;
      private bool n335TicketResponsableMantenimientoSiete ;
      private bool A336TicketResponsableGestionbdUno ;
      private bool n336TicketResponsableGestionbdUno ;
      private bool A337TicketResponsableGestionbdDos ;
      private bool n337TicketResponsableGestionbdDos ;
      private bool A338TicketResponsableGestionbdTres ;
      private bool n338TicketResponsableGestionbdTres ;
      private bool A339TicketResponsableGestionbdCuatro ;
      private bool n339TicketResponsableGestionbdCuatro ;
      private bool A340TicketResponsableMantenimientobdUno ;
      private bool n340TicketResponsableMantenimientobdUno ;
      private bool A341TicketResponsableMantenimientobdDos ;
      private bool n341TicketResponsableMantenimientobdDos ;
      private bool A342TicketResponsableMantenimientobdTres ;
      private bool n342TicketResponsableMantenimientobdTres ;
      private bool A343TicketResponsableMantenimientobdCuatro ;
      private bool n343TicketResponsableMantenimientobdCuatro ;
      private bool A344TicketResponsableMantenimientobdCinco ;
      private bool n344TicketResponsableMantenimientobdCinco ;
      private bool A345TicketResponsableMantenimientobdSeis ;
      private bool n345TicketResponsableMantenimientobdSeis ;
      private bool A346TicketResponsableMantenimientobdSiete ;
      private bool n346TicketResponsableMantenimientobdSiete ;
      private bool A165TicketResponsableCerrado ;
      private bool n165TicketResponsableCerrado ;
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
      private string AV22TicketResponsableObservacion ;
      private string AV41UsuarioNombre ;
      private string AV38UsuarioDepartamento ;
      private string AV42UsuarioEmail ;
      private string AV36detalle_tarea ;
      private string AV35prioridad ;
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
      private bool[] P00752_A305TicketResponsableAnalasisUno ;
      private bool[] P00752_n305TicketResponsableAnalasisUno ;
      private bool[] P00752_A306TicketResponsableAnalasisDos ;
      private bool[] P00752_n306TicketResponsableAnalasisDos ;
      private bool[] P00752_A307TicketResponsableAnalasisTres ;
      private bool[] P00752_n307TicketResponsableAnalasisTres ;
      private bool[] P00752_A308TicketResponsableAnalasisCuatro ;
      private bool[] P00752_n308TicketResponsableAnalasisCuatro ;
      private bool[] P00752_A309TicketResponsableDisenioUno ;
      private bool[] P00752_n309TicketResponsableDisenioUno ;
      private bool[] P00752_A310TicketResponsableDesarrolloUno ;
      private bool[] P00752_n310TicketResponsableDesarrolloUno ;
      private bool[] P00752_A311TicketResponsableDesarrolloDos ;
      private bool[] P00752_n311TicketResponsableDesarrolloDos ;
      private bool[] P00752_A312TicketResponsableDesarrolloTres ;
      private bool[] P00752_n312TicketResponsableDesarrolloTres ;
      private bool[] P00752_A313TicketResponsableDesarrolloCuatro ;
      private bool[] P00752_n313TicketResponsableDesarrolloCuatro ;
      private bool[] P00752_A314TicketResponsableDesarrolloCinco ;
      private bool[] P00752_n314TicketResponsableDesarrolloCinco ;
      private bool[] P00752_A315TicketResponsablePruebasUno ;
      private bool[] P00752_n315TicketResponsablePruebasUno ;
      private bool[] P00752_A316TicketResponsablePruebasDos ;
      private bool[] P00752_n316TicketResponsablePruebasDos ;
      private bool[] P00752_A317TicketResponsablePruebasTres ;
      private bool[] P00752_n317TicketResponsablePruebasTres ;
      private bool[] P00752_A318TicketResponsablePruebasCuatro ;
      private bool[] P00752_n318TicketResponsablePruebasCuatro ;
      private bool[] P00752_A319TicketResponsableDocumentacionUno ;
      private bool[] P00752_n319TicketResponsableDocumentacionUno ;
      private bool[] P00752_A320TicketResponsableDocumentacionDos ;
      private bool[] P00752_n320TicketResponsableDocumentacionDos ;
      private bool[] P00752_A321TicketResponsableDocumentacionTres ;
      private bool[] P00752_n321TicketResponsableDocumentacionTres ;
      private bool[] P00752_A322TicketResponsableDocumentacionCuatro ;
      private bool[] P00752_n322TicketResponsableDocumentacionCuatro ;
      private bool[] P00752_A323TicketResponsableImplementacionUno ;
      private bool[] P00752_n323TicketResponsableImplementacionUno ;
      private bool[] P00752_A324TicketResponsableImplementacionDos ;
      private bool[] P00752_n324TicketResponsableImplementacionDos ;
      private bool[] P00752_A325TicketResponsableImplementacionTres ;
      private bool[] P00752_n325TicketResponsableImplementacionTres ;
      private bool[] P00752_A326TicketResponsableImplementacionCuatro ;
      private bool[] P00752_n326TicketResponsableImplementacionCuatro ;
      private bool[] P00752_A327TicketResponsableImplementacionCinco ;
      private bool[] P00752_n327TicketResponsableImplementacionCinco ;
      private bool[] P00752_A328TicketResponsableImplementacionSeis ;
      private bool[] P00752_n328TicketResponsableImplementacionSeis ;
      private bool[] P00752_A329TicketResponsableMantenimientoUno ;
      private bool[] P00752_n329TicketResponsableMantenimientoUno ;
      private bool[] P00752_A330TicketResponsableMantenimientoDos ;
      private bool[] P00752_n330TicketResponsableMantenimientoDos ;
      private bool[] P00752_A331TicketResponsableMantenimientoTres ;
      private bool[] P00752_n331TicketResponsableMantenimientoTres ;
      private bool[] P00752_A332TicketResponsableMantenimientoCuatro ;
      private bool[] P00752_n332TicketResponsableMantenimientoCuatro ;
      private bool[] P00752_A333TicketResponsableMantenimientoCinco ;
      private bool[] P00752_n333TicketResponsableMantenimientoCinco ;
      private bool[] P00752_A334TicketResponsableMantenimientoSeis ;
      private bool[] P00752_n334TicketResponsableMantenimientoSeis ;
      private bool[] P00752_A335TicketResponsableMantenimientoSiete ;
      private bool[] P00752_n335TicketResponsableMantenimientoSiete ;
      private bool[] P00752_A336TicketResponsableGestionbdUno ;
      private bool[] P00752_n336TicketResponsableGestionbdUno ;
      private bool[] P00752_A337TicketResponsableGestionbdDos ;
      private bool[] P00752_n337TicketResponsableGestionbdDos ;
      private bool[] P00752_A338TicketResponsableGestionbdTres ;
      private bool[] P00752_n338TicketResponsableGestionbdTres ;
      private bool[] P00752_A339TicketResponsableGestionbdCuatro ;
      private bool[] P00752_n339TicketResponsableGestionbdCuatro ;
      private bool[] P00752_A340TicketResponsableMantenimientobdUno ;
      private bool[] P00752_n340TicketResponsableMantenimientobdUno ;
      private bool[] P00752_A341TicketResponsableMantenimientobdDos ;
      private bool[] P00752_n341TicketResponsableMantenimientobdDos ;
      private bool[] P00752_A342TicketResponsableMantenimientobdTres ;
      private bool[] P00752_n342TicketResponsableMantenimientobdTres ;
      private bool[] P00752_A343TicketResponsableMantenimientobdCuatro ;
      private bool[] P00752_n343TicketResponsableMantenimientobdCuatro ;
      private bool[] P00752_A344TicketResponsableMantenimientobdCinco ;
      private bool[] P00752_n344TicketResponsableMantenimientobdCinco ;
      private bool[] P00752_A345TicketResponsableMantenimientobdSeis ;
      private bool[] P00752_n345TicketResponsableMantenimientobdSeis ;
      private bool[] P00752_A346TicketResponsableMantenimientobdSiete ;
      private bool[] P00752_n346TicketResponsableMantenimientobdSiete ;
      private bool[] P00752_A165TicketResponsableCerrado ;
      private bool[] P00752_n165TicketResponsableCerrado ;
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
      private long[] P007510_A40000GXC1 ;
      private bool[] P007510_n40000GXC1 ;
      private long[] P007514_A40000GXC1 ;
      private bool[] P007514_n40000GXC1 ;
      private long[] P007518_A40000GXC1 ;
      private bool[] P007518_n40000GXC1 ;
      private long[] P007522_A40000GXC1 ;
      private bool[] P007522_n40000GXC1 ;
      private long[] P007526_A40000GXC1 ;
      private bool[] P007526_n40000GXC1 ;
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
       ,new UpdateCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
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
        string cmdBufferP00752;
        cmdBufferP00752=" SELECT [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [TicketResponsableId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableCerrado], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketId] FROM [TicketResponsable] WITH (UPDLOCK) "
        + " WHERE ([TicketResponsableId] = @AV8TicketResponsableId) AND ([TicketTecnicoResponsableId] = @AV45TicketTecnicoResponsableId) AND ([EstadoTicketTecnicoId] = 3) ORDER BY [TicketId], [TicketResponsableId]" ;
        Object[] prmP00753;
        prmP00753 = new Object[] {
        new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
        new ParDef("@TicketResponsableAnalasisUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableAnalasisDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableAnalasisTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableAnalasisCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDisenioUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDesarrolloUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDesarrolloDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDesarrolloTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDesarrolloCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDesarrolloCinco",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsablePruebasUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsablePruebasDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsablePruebasTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsablePruebasCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDocumentacionUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDocumentacionDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDocumentacionTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableDocumentacionCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableImplementacionUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableImplementacionDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableImplementacionTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableImplementacionCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableImplementacionCinco",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableImplementacionSeis",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoCinco",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoSeis",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientoSiete",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableGestionbdUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableGestionbdDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableGestionbdTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableGestionbdCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdUno",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdDos",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdTres",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdCuatro",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdCinco",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdSeis",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableMantenimientobdSiete",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableCerrado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@TicketResponsableObservacion",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@TicketResponsableFechaResuelve",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@TicketResponsableHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("@TicketId",GXType.Decimal,10,0) ,
        new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
        };
        string cmdBufferP00753;
        cmdBufferP00753=" UPDATE [TicketResponsable] SET [EstadoTicketTecnicoId]=@EstadoTicketTecnicoId, [TicketResponsableAnalasisUno]=@TicketResponsableAnalasisUno, [TicketResponsableAnalasisDos]=@TicketResponsableAnalasisDos, [TicketResponsableAnalasisTres]=@TicketResponsableAnalasisTres, [TicketResponsableAnalasisCuatro]=@TicketResponsableAnalasisCuatro, [TicketResponsableDisenioUno]=@TicketResponsableDisenioUno, [TicketResponsableDesarrolloUno]=@TicketResponsableDesarrolloUno, [TicketResponsableDesarrolloDos]=@TicketResponsableDesarrolloDos, [TicketResponsableDesarrolloTres]=@TicketResponsableDesarrolloTres, [TicketResponsableDesarrolloCuatro]=@TicketResponsableDesarrolloCuatro, [TicketResponsableDesarrolloCinco]=@TicketResponsableDesarrolloCinco, [TicketResponsablePruebasUno]=@TicketResponsablePruebasUno, [TicketResponsablePruebasDos]=@TicketResponsablePruebasDos, [TicketResponsablePruebasTres]=@TicketResponsablePruebasTres, [TicketResponsablePruebasCuatro]=@TicketResponsablePruebasCuatro, [TicketResponsableDocumentacionUno]=@TicketResponsableDocumentacionUno, [TicketResponsableDocumentacionDos]=@TicketResponsableDocumentacionDos, [TicketResponsableDocumentacionTres]=@TicketResponsableDocumentacionTres, [TicketResponsableDocumentacionCuatro]=@TicketResponsableDocumentacionCuatro, [TicketResponsableImplementacionUno]=@TicketResponsableImplementacionUno, [TicketResponsableImplementacionDos]=@TicketResponsableImplementacionDos, [TicketResponsableImplementacionTres]=@TicketResponsableImplementacionTres, [TicketResponsableImplementacionCuatro]=@TicketResponsableImplementacionCuatro, [TicketResponsableImplementacionCinco]=@TicketResponsableImplementacionCinco, [TicketResponsableImplementacionSeis]=@TicketResponsableImplementacionSeis, [TicketResponsableMantenimientoUno]=@TicketResponsableMantenimientoUno, "
        + " [TicketResponsableMantenimientoDos]=@TicketResponsableMantenimientoDos, [TicketResponsableMantenimientoTres]=@TicketResponsableMantenimientoTres, [TicketResponsableMantenimientoCuatro]=@TicketResponsableMantenimientoCuatro, [TicketResponsableMantenimientoCinco]=@TicketResponsableMantenimientoCinco, [TicketResponsableMantenimientoSeis]=@TicketResponsableMantenimientoSeis, [TicketResponsableMantenimientoSiete]=@TicketResponsableMantenimientoSiete, [TicketResponsableGestionbdUno]=@TicketResponsableGestionbdUno, [TicketResponsableGestionbdDos]=@TicketResponsableGestionbdDos, [TicketResponsableGestionbdTres]=@TicketResponsableGestionbdTres, [TicketResponsableGestionbdCuatro]=@TicketResponsableGestionbdCuatro, [TicketResponsableMantenimientobdUno]=@TicketResponsableMantenimientobdUno, [TicketResponsableMantenimientobdDos]=@TicketResponsableMantenimientobdDos, [TicketResponsableMantenimientobdTres]=@TicketResponsableMantenimientobdTres, [TicketResponsableMantenimientobdCuatro]=@TicketResponsableMantenimientobdCuatro, [TicketResponsableMantenimientobdCinco]=@TicketResponsableMantenimientobdCinco, [TicketResponsableMantenimientobdSeis]=@TicketResponsableMantenimientobdSeis, [TicketResponsableMantenimientobdSiete]=@TicketResponsableMantenimientobdSiete, [TicketResponsableCerrado]=@TicketResponsableCerrado, [TicketResponsableObservacion]=@TicketResponsableObservacion, [TicketResponsableFechaResuelve]=@TicketResponsableFechaResuelve, [TicketResponsableHoraResuelve]=@TicketResponsableHoraResuelve  WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId" ;
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
        new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
        new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferP00757;
        cmdBufferP00757=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
        + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
        + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
        Object[] prmP00758;
        prmP00758 = new Object[] {
        new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007510;
        prmP007510 = new Object[] {
        };
        Object[] prmP007511;
        prmP007511 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,10,0) ,
        new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
        new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
        new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
        new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
        new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
        new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferP007511;
        cmdBufferP007511=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
        + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
        + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
        Object[] prmP007512;
        prmP007512 = new Object[] {
        new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007514;
        prmP007514 = new Object[] {
        };
        Object[] prmP007515;
        prmP007515 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,10,0) ,
        new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
        new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
        new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
        new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
        new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
        new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferP007515;
        cmdBufferP007515=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
        + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
        + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
        Object[] prmP007516;
        prmP007516 = new Object[] {
        new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
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
        new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
        new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferP007519;
        cmdBufferP007519=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
        + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
        + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
        Object[] prmP007520;
        prmP007520 = new Object[] {
        new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007522;
        prmP007522 = new Object[] {
        };
        Object[] prmP007523;
        prmP007523 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,10,0) ,
        new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
        new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
        new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
        new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
        new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
        new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferP007523;
        cmdBufferP007523=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
        + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
        + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
        Object[] prmP007524;
        prmP007524 = new Object[] {
        new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007526;
        prmP007526 = new Object[] {
        };
        Object[] prmP007527;
        prmP007527 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,10,0) ,
        new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
        new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
        new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
        new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
        new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
        new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferP007527;
        cmdBufferP007527=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketFechaResponsable], [TicketHoraResponsable], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId], [EtapaDesarrolloId], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [CategoriaDetalleTareaId], [TicketResponsableAnalasisUno], [TicketResponsableAnalasisDos], [TicketResponsableAnalasisTres], [TicketResponsableAnalasisCuatro], [TicketResponsableDisenioUno], [TicketResponsableDesarrolloUno], [TicketResponsableDesarrolloDos], [TicketResponsableDesarrolloTres], [TicketResponsableDesarrolloCuatro], [TicketResponsableDesarrolloCinco], [TicketResponsablePruebasUno], [TicketResponsablePruebasDos], [TicketResponsablePruebasTres], [TicketResponsablePruebasCuatro], [TicketResponsableDocumentacionUno], [TicketResponsableDocumentacionDos], [TicketResponsableDocumentacionTres], [TicketResponsableDocumentacionCuatro], [TicketResponsableImplementacionUno], "
        + " [TicketResponsableImplementacionDos], [TicketResponsableImplementacionTres], [TicketResponsableImplementacionCuatro], [TicketResponsableImplementacionCinco], [TicketResponsableImplementacionSeis], [TicketResponsableMantenimientoUno], [TicketResponsableMantenimientoDos], [TicketResponsableMantenimientoTres], [TicketResponsableMantenimientoCuatro], [TicketResponsableMantenimientoCinco], [TicketResponsableMantenimientoSeis], [TicketResponsableMantenimientoSiete], [TicketResponsableGestionbdUno], [TicketResponsableGestionbdDos], [TicketResponsableGestionbdTres], [TicketResponsableGestionbdCuatro], [TicketResponsableMantenimientobdUno], [TicketResponsableMantenimientobdDos], [TicketResponsableMantenimientobdTres], [TicketResponsableMantenimientobdCuatro], [TicketResponsableMantenimientobdCinco], [TicketResponsableMantenimientobdSeis], [TicketResponsableMantenimientobdSiete], [TicketResponsableFechaHoraAtiende], [TicketResponsableFechaSistema]) VALUES(@TicketId, @TicketResponsableId, @TicketFechaResponsable, @TicketHoraResponsable, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId, @EtapaDesarrolloId, '', convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', '', '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit,"
        + " 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))" ;
        Object[] prmP007528;
        prmP007528 = new Object[] {
        new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007529;
        prmP007529 = new Object[] {
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007530;
        prmP007530 = new Object[] {
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007531;
        prmP007531 = new Object[] {
        new ParDef("@AV24TicketId",GXType.Decimal,10,0) ,
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        Object[] prmP007532;
        prmP007532 = new Object[] {
        new ParDef("@AV23UsuarioId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00752", cmdBufferP00752,true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00753", cmdBufferP00753, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00753)
           ,new CursorDef("P00756", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00756,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00757", cmdBufferP00757, GxErrorMask.GX_NOMASK,prmP00757)
           ,new CursorDef("P00758", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00758)
           ,new CursorDef("P007510", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007510,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007511", cmdBufferP007511, GxErrorMask.GX_NOMASK,prmP007511)
           ,new CursorDef("P007512", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007512)
           ,new CursorDef("P007514", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007514,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007515", cmdBufferP007515, GxErrorMask.GX_NOMASK,prmP007515)
           ,new CursorDef("P007516", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007516)
           ,new CursorDef("P007518", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007518,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007519", cmdBufferP007519, GxErrorMask.GX_NOMASK,prmP007519)
           ,new CursorDef("P007520", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007520)
           ,new CursorDef("P007522", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007522,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007523", cmdBufferP007523, GxErrorMask.GX_NOMASK,prmP007523)
           ,new CursorDef("P007524", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007524)
           ,new CursorDef("P007526", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([TicketResponsableId]) AS GXC1 FROM [TicketResponsable] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007526,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007527", cmdBufferP007527, GxErrorMask.GX_NOMASK,prmP007527)
           ,new CursorDef("P007528", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007528)
           ,new CursorDef("P007529", "UPDATE [Ticket] SET [EstadoTicketTicketId]=5  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007529)
           ,new CursorDef("P007530", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=5  WHERE [UsuarioId] = @AV23UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007530)
           ,new CursorDef("P007531", "UPDATE [Ticket] SET [EstadoTicketTicketId]=6  WHERE ([TicketId] = @AV24TicketId) AND ([UsuarioId] = @AV23UsuarioId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007531)
           ,new CursorDef("P007532", "UPDATE [Usuario] SET [EstadoTicketUsuarioId]=6  WHERE [UsuarioId] = @AV23UsuarioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007532)
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
              ((bool[]) buf[3])[0] = rslt.getBool(4);
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
              ((bool[]) buf[23])[0] = rslt.getBool(14);
              ((bool[]) buf[24])[0] = rslt.wasNull(14);
              ((bool[]) buf[25])[0] = rslt.getBool(15);
              ((bool[]) buf[26])[0] = rslt.wasNull(15);
              ((bool[]) buf[27])[0] = rslt.getBool(16);
              ((bool[]) buf[28])[0] = rslt.wasNull(16);
              ((bool[]) buf[29])[0] = rslt.getBool(17);
              ((bool[]) buf[30])[0] = rslt.wasNull(17);
              ((bool[]) buf[31])[0] = rslt.getBool(18);
              ((bool[]) buf[32])[0] = rslt.wasNull(18);
              ((bool[]) buf[33])[0] = rslt.getBool(19);
              ((bool[]) buf[34])[0] = rslt.wasNull(19);
              ((bool[]) buf[35])[0] = rslt.getBool(20);
              ((bool[]) buf[36])[0] = rslt.wasNull(20);
              ((bool[]) buf[37])[0] = rslt.getBool(21);
              ((bool[]) buf[38])[0] = rslt.wasNull(21);
              ((bool[]) buf[39])[0] = rslt.getBool(22);
              ((bool[]) buf[40])[0] = rslt.wasNull(22);
              ((bool[]) buf[41])[0] = rslt.getBool(23);
              ((bool[]) buf[42])[0] = rslt.wasNull(23);
              ((bool[]) buf[43])[0] = rslt.getBool(24);
              ((bool[]) buf[44])[0] = rslt.wasNull(24);
              ((bool[]) buf[45])[0] = rslt.getBool(25);
              ((bool[]) buf[46])[0] = rslt.wasNull(25);
              ((bool[]) buf[47])[0] = rslt.getBool(26);
              ((bool[]) buf[48])[0] = rslt.wasNull(26);
              ((bool[]) buf[49])[0] = rslt.getBool(27);
              ((bool[]) buf[50])[0] = rslt.wasNull(27);
              ((bool[]) buf[51])[0] = rslt.getBool(28);
              ((bool[]) buf[52])[0] = rslt.wasNull(28);
              ((bool[]) buf[53])[0] = rslt.getBool(29);
              ((bool[]) buf[54])[0] = rslt.wasNull(29);
              ((bool[]) buf[55])[0] = rslt.getBool(30);
              ((bool[]) buf[56])[0] = rslt.wasNull(30);
              ((bool[]) buf[57])[0] = rslt.getBool(31);
              ((bool[]) buf[58])[0] = rslt.wasNull(31);
              ((bool[]) buf[59])[0] = rslt.getBool(32);
              ((bool[]) buf[60])[0] = rslt.wasNull(32);
              ((bool[]) buf[61])[0] = rslt.getBool(33);
              ((bool[]) buf[62])[0] = rslt.wasNull(33);
              ((bool[]) buf[63])[0] = rslt.getBool(34);
              ((bool[]) buf[64])[0] = rslt.wasNull(34);
              ((bool[]) buf[65])[0] = rslt.getBool(35);
              ((bool[]) buf[66])[0] = rslt.wasNull(35);
              ((bool[]) buf[67])[0] = rslt.getBool(36);
              ((bool[]) buf[68])[0] = rslt.wasNull(36);
              ((bool[]) buf[69])[0] = rslt.getBool(37);
              ((bool[]) buf[70])[0] = rslt.wasNull(37);
              ((bool[]) buf[71])[0] = rslt.getBool(38);
              ((bool[]) buf[72])[0] = rslt.wasNull(38);
              ((bool[]) buf[73])[0] = rslt.getBool(39);
              ((bool[]) buf[74])[0] = rslt.wasNull(39);
              ((bool[]) buf[75])[0] = rslt.getBool(40);
              ((bool[]) buf[76])[0] = rslt.wasNull(40);
              ((bool[]) buf[77])[0] = rslt.getBool(41);
              ((bool[]) buf[78])[0] = rslt.wasNull(41);
              ((bool[]) buf[79])[0] = rslt.getBool(42);
              ((bool[]) buf[80])[0] = rslt.wasNull(42);
              ((bool[]) buf[81])[0] = rslt.getBool(43);
              ((bool[]) buf[82])[0] = rslt.wasNull(43);
              ((bool[]) buf[83])[0] = rslt.getBool(44);
              ((bool[]) buf[84])[0] = rslt.wasNull(44);
              ((bool[]) buf[85])[0] = rslt.getBool(45);
              ((bool[]) buf[86])[0] = rslt.wasNull(45);
              ((bool[]) buf[87])[0] = rslt.getBool(46);
              ((bool[]) buf[88])[0] = rslt.wasNull(46);
              ((string[]) buf[89])[0] = rslt.getVarchar(47);
              ((bool[]) buf[90])[0] = rslt.wasNull(47);
              ((DateTime[]) buf[91])[0] = rslt.getGXDate(48);
              ((bool[]) buf[92])[0] = rslt.wasNull(48);
              ((DateTime[]) buf[93])[0] = rslt.getGXDateTime(49);
              ((bool[]) buf[94])[0] = rslt.wasNull(49);
              ((long[]) buf[95])[0] = rslt.getLong(50);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
