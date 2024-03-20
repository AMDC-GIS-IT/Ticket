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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportwwdetalle_infotec : GXProcedure
   {
      public exportwwdetalle_infotec( )
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

      public exportwwdetalle_infotec( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_nombre_emp ,
                           DateTime aP1_fecha_registro_From ,
                           DateTime aP2_fecha_registro_To ,
                           string aP3_K2BToolsGenericSearchField ,
                           short aP4_OrderedBy ,
                           out string aP5_OutFile )
      {
         this.AV13nombre_emp = aP0_nombre_emp;
         this.AV57fecha_registro_From = aP1_fecha_registro_From;
         this.AV58fecha_registro_To = aP2_fecha_registro_To;
         this.AV12K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         this.AV26OrderedBy = aP4_OrderedBy;
         this.AV59OutFile = "" ;
         initialize();
         executePrivate();
         aP5_OutFile=this.AV59OutFile;
      }

      public string executeUdp( string aP0_nombre_emp ,
                                DateTime aP1_fecha_registro_From ,
                                DateTime aP2_fecha_registro_To ,
                                string aP3_K2BToolsGenericSearchField ,
                                short aP4_OrderedBy )
      {
         execute(aP0_nombre_emp, aP1_fecha_registro_From, aP2_fecha_registro_To, aP3_K2BToolsGenericSearchField, aP4_OrderedBy, out aP5_OutFile);
         return AV59OutFile ;
      }

      public void executeSubmit( string aP0_nombre_emp ,
                                 DateTime aP1_fecha_registro_From ,
                                 DateTime aP2_fecha_registro_To ,
                                 string aP3_K2BToolsGenericSearchField ,
                                 short aP4_OrderedBy ,
                                 out string aP5_OutFile )
      {
         exportwwdetalle_infotec objexportwwdetalle_infotec;
         objexportwwdetalle_infotec = new exportwwdetalle_infotec();
         objexportwwdetalle_infotec.AV13nombre_emp = aP0_nombre_emp;
         objexportwwdetalle_infotec.AV57fecha_registro_From = aP1_fecha_registro_From;
         objexportwwdetalle_infotec.AV58fecha_registro_To = aP2_fecha_registro_To;
         objexportwwdetalle_infotec.AV12K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         objexportwwdetalle_infotec.AV26OrderedBy = aP4_OrderedBy;
         objexportwwdetalle_infotec.AV59OutFile = "" ;
         objexportwwdetalle_infotec.context.SetSubmitInitialConfig(context);
         objexportwwdetalle_infotec.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwdetalle_infotec);
         aP5_OutFile=this.AV59OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwdetalle_infotec)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV55Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV59OutFile = GxDirectory.TemporaryFilesPath + AV35File.Separator + "ExportWWdetalle_infotec-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV27ExcelDocument.Open(AV59OutFile);
         AV27ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV27ExcelDocument.Clear();
         AV28CellRow = 1;
         AV29FirstColumn = 1;
         AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn, 1, 1).Size = 15;
         AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn, 1, 1).Bold = 1;
         AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn, 1, 1).Text = "detalle_infoteces";
         AV28CellRow = (int)(AV28CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+0, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV28CellRow = (int)(AV28CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13nombre_emp)) )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+0, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+0, 1, 1).Text = "nombre_emp";
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV13nombre_emp);
            AV28CellRow = (int)(AV28CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV57fecha_registro_From) || ! (DateTime.MinValue==AV58fecha_registro_To) )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+0, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+0, 1, 1).Text = "fecha_registro";
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV57fecha_registro_From, 2, "/")+" - "+context.localUtil.DToC( AV58fecha_registro_To, 2, "/");
            AV28CellRow = (int)(AV28CellRow+1);
         }
         AV28CellRow = (int)(AV28CellRow+3);
         AV31ColumnIndex = 0;
         if ( AV36GridColumnVisible_correlativo )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "correlativo";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_nombre_emp )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "nombre_emp";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_cargo_emp )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "cargo_emp";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_fecha_registro )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "fecha_registro";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_estatus )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "estatus";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_trabajo )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "trabajo";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_nombre_usuario )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "nombre_usuario";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_depto_usuario )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "depto_usuario";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV45GridColumnVisible_correo_usuario )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "correo_usuario";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV46GridColumnVisible_detalle_infotecid_unidad )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "id_unidad";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV47GridColumnVisible_id_categoria )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "id_categoria";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV48GridColumnVisible_id_actividad )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "id_actividad";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV49GridColumnVisible_detalle_tarea )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "detalle_tarea";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV50GridColumnVisible_prioridad )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "prioridad";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV51GridColumnVisible_observaciones )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "observaciones";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         if ( AV52GridColumnVisible_fecha_solicitud )
         {
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Bold = 1;
            AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = "fecha_solicitud";
            AV31ColumnIndex = (short)(AV31ColumnIndex+1);
         }
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV13nombre_emp ,
                                              AV58fecha_registro_To ,
                                              AV57fecha_registro_From ,
                                              AV12K2BToolsGenericSearchField ,
                                              A239nombre_emp ,
                                              A241fecha_registro ,
                                              A238correlativo ,
                                              A240cargo_emp ,
                                              A243estatus ,
                                              A244trabajo ,
                                              A245nombre_usuario ,
                                              A246depto_usuario ,
                                              A247correo_usuario ,
                                              A248detalle_infotecid_unidad ,
                                              A249id_categoria ,
                                              A250id_actividad ,
                                              A251detalle_tarea ,
                                              A252prioridad ,
                                              A253observaciones ,
                                              A254fecha_solicitud ,
                                              AV26OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV13nombre_emp = StringUtil.Concat( StringUtil.RTrim( AV13nombre_emp), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P007A2 */
         pr_datastore1.execute(0, new Object[] {lV13nombre_emp, AV58fecha_registro_To, AV57fecha_registro_From, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A254fecha_solicitud = P007A2_A254fecha_solicitud[0];
            n254fecha_solicitud = P007A2_n254fecha_solicitud[0];
            A253observaciones = P007A2_A253observaciones[0];
            n253observaciones = P007A2_n253observaciones[0];
            A252prioridad = P007A2_A252prioridad[0];
            n252prioridad = P007A2_n252prioridad[0];
            A251detalle_tarea = P007A2_A251detalle_tarea[0];
            n251detalle_tarea = P007A2_n251detalle_tarea[0];
            A250id_actividad = P007A2_A250id_actividad[0];
            n250id_actividad = P007A2_n250id_actividad[0];
            A249id_categoria = P007A2_A249id_categoria[0];
            n249id_categoria = P007A2_n249id_categoria[0];
            A248detalle_infotecid_unidad = P007A2_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = P007A2_n248detalle_infotecid_unidad[0];
            A247correo_usuario = P007A2_A247correo_usuario[0];
            n247correo_usuario = P007A2_n247correo_usuario[0];
            A246depto_usuario = P007A2_A246depto_usuario[0];
            n246depto_usuario = P007A2_n246depto_usuario[0];
            A245nombre_usuario = P007A2_A245nombre_usuario[0];
            n245nombre_usuario = P007A2_n245nombre_usuario[0];
            A244trabajo = P007A2_A244trabajo[0];
            n244trabajo = P007A2_n244trabajo[0];
            A243estatus = P007A2_A243estatus[0];
            n243estatus = P007A2_n243estatus[0];
            A240cargo_emp = P007A2_A240cargo_emp[0];
            n240cargo_emp = P007A2_n240cargo_emp[0];
            A238correlativo = P007A2_A238correlativo[0];
            A241fecha_registro = P007A2_A241fecha_registro[0];
            n241fecha_registro = P007A2_n241fecha_registro[0];
            A239nombre_emp = P007A2_A239nombre_emp[0];
            n239nombre_emp = P007A2_n239nombre_emp[0];
            AV28CellRow = (int)(AV28CellRow+1);
            AV31ColumnIndex = 0;
            if ( AV36GridColumnVisible_correlativo )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Number = A238correlativo;
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_nombre_emp )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A239nombre_emp);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_cargo_emp )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A240cargo_emp);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_fecha_registro )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A241fecha_registro ) ;
               AV27ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_estatus )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A243estatus);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_trabajo )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A244trabajo);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_nombre_usuario )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A245nombre_usuario);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_depto_usuario )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A246depto_usuario);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV45GridColumnVisible_correo_usuario )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A247correo_usuario);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV46GridColumnVisible_detalle_infotecid_unidad )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Number = A248detalle_infotecid_unidad;
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV47GridColumnVisible_id_categoria )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Number = A249id_categoria;
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV48GridColumnVisible_id_actividad )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Number = A250id_actividad;
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV49GridColumnVisible_detalle_tarea )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A251detalle_tarea);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV50GridColumnVisible_prioridad )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A252prioridad);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV51GridColumnVisible_observaciones )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A253observaciones);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            if ( AV52GridColumnVisible_fecha_solicitud )
            {
               AV27ExcelDocument.get_Cells(AV28CellRow, AV29FirstColumn+AV31ColumnIndex, 1, 1).Text = StringUtil.RTrim( A254fecha_solicitud);
               AV31ColumnIndex = (short)(AV31ColumnIndex+1);
            }
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
         AV27ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV27ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV27ExcelDocument.ErrCode != 0 )
         {
            AV59OutFile = "";
            AV33ErrorMessage = AV27ExcelDocument.ErrDescription;
            AV27ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S131 ();
         if (returnInSub) return;
         new k2bloadgridconfiguration(context ).execute(  "WWdetalle_infotec",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV36GridColumnVisible_correlativo = true;
         AV37GridColumnVisible_nombre_emp = true;
         AV38GridColumnVisible_cargo_emp = true;
         AV39GridColumnVisible_fecha_registro = true;
         AV41GridColumnVisible_estatus = true;
         AV42GridColumnVisible_trabajo = true;
         AV43GridColumnVisible_nombre_usuario = true;
         AV44GridColumnVisible_depto_usuario = true;
         AV45GridColumnVisible_correo_usuario = true;
         AV46GridColumnVisible_detalle_infotecid_unidad = true;
         AV47GridColumnVisible_id_categoria = true;
         AV48GridColumnVisible_id_actividad = true;
         AV49GridColumnVisible_detalle_tarea = true;
         AV50GridColumnVisible_prioridad = true;
         AV51GridColumnVisible_observaciones = true;
         AV52GridColumnVisible_fecha_solicitud = true;
         new k2bsavegridconfiguration(context ).execute(  "WWdetalle_infotec",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV63GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "correlativo") == 0 )
               {
                  AV36GridColumnVisible_correlativo = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_emp") == 0 )
               {
                  AV37GridColumnVisible_nombre_emp = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "cargo_emp") == 0 )
               {
                  AV38GridColumnVisible_cargo_emp = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "fecha_registro") == 0 )
               {
                  AV39GridColumnVisible_fecha_registro = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "estatus") == 0 )
               {
                  AV41GridColumnVisible_estatus = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "trabajo") == 0 )
               {
                  AV42GridColumnVisible_trabajo = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_usuario") == 0 )
               {
                  AV43GridColumnVisible_nombre_usuario = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "depto_usuario") == 0 )
               {
                  AV44GridColumnVisible_depto_usuario = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "correo_usuario") == 0 )
               {
                  AV45GridColumnVisible_correo_usuario = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "detalle_infotecid_unidad") == 0 )
               {
                  AV46GridColumnVisible_detalle_infotecid_unidad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_categoria") == 0 )
               {
                  AV47GridColumnVisible_id_categoria = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_actividad") == 0 )
               {
                  AV48GridColumnVisible_id_actividad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "detalle_tarea") == 0 )
               {
                  AV49GridColumnVisible_detalle_tarea = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "prioridad") == 0 )
               {
                  AV50GridColumnVisible_prioridad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "observaciones") == 0 )
               {
                  AV51GridColumnVisible_observaciones = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "fecha_solicitud") == 0 )
               {
                  AV52GridColumnVisible_fecha_solicitud = false;
               }
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "correlativo";
         AV11GridColumn.gxTpr_Columntitle = "correlativo";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_emp";
         AV11GridColumn.gxTpr_Columntitle = "nombre_emp";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "cargo_emp";
         AV11GridColumn.gxTpr_Columntitle = "cargo_emp";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "fecha_registro";
         AV11GridColumn.gxTpr_Columntitle = "fecha_registro";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "estatus";
         AV11GridColumn.gxTpr_Columntitle = "estatus";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "trabajo";
         AV11GridColumn.gxTpr_Columntitle = "trabajo";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_usuario";
         AV11GridColumn.gxTpr_Columntitle = "nombre_usuario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "depto_usuario";
         AV11GridColumn.gxTpr_Columntitle = "depto_usuario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "correo_usuario";
         AV11GridColumn.gxTpr_Columntitle = "correo_usuario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "detalle_infotecid_unidad";
         AV11GridColumn.gxTpr_Columntitle = "id_unidad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_categoria";
         AV11GridColumn.gxTpr_Columntitle = "id_categoria";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_actividad";
         AV11GridColumn.gxTpr_Columntitle = "id_actividad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "detalle_tarea";
         AV11GridColumn.gxTpr_Columntitle = "detalle_tarea";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "prioridad";
         AV11GridColumn.gxTpr_Columntitle = "prioridad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "observaciones";
         AV11GridColumn.gxTpr_Columntitle = "observaciones";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "fecha_solicitud";
         AV11GridColumn.gxTpr_Columntitle = "fecha_solicitud";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV8GridConfiguration.gxTpr_Gridcolumns = AV10GridColumns;
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
         AV59OutFile = "";
         AV55Context = new SdtK2BContext(context);
         AV35File = new GxFile(context.GetPhysicalPath());
         AV27ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV13nombre_emp = "";
         lV12K2BToolsGenericSearchField = "";
         A239nombre_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A240cargo_emp = "";
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         P007A2_A254fecha_solicitud = new string[] {""} ;
         P007A2_n254fecha_solicitud = new bool[] {false} ;
         P007A2_A253observaciones = new string[] {""} ;
         P007A2_n253observaciones = new bool[] {false} ;
         P007A2_A252prioridad = new string[] {""} ;
         P007A2_n252prioridad = new bool[] {false} ;
         P007A2_A251detalle_tarea = new string[] {""} ;
         P007A2_n251detalle_tarea = new bool[] {false} ;
         P007A2_A250id_actividad = new int[1] ;
         P007A2_n250id_actividad = new bool[] {false} ;
         P007A2_A249id_categoria = new int[1] ;
         P007A2_n249id_categoria = new bool[] {false} ;
         P007A2_A248detalle_infotecid_unidad = new int[1] ;
         P007A2_n248detalle_infotecid_unidad = new bool[] {false} ;
         P007A2_A247correo_usuario = new string[] {""} ;
         P007A2_n247correo_usuario = new bool[] {false} ;
         P007A2_A246depto_usuario = new string[] {""} ;
         P007A2_n246depto_usuario = new bool[] {false} ;
         P007A2_A245nombre_usuario = new string[] {""} ;
         P007A2_n245nombre_usuario = new bool[] {false} ;
         P007A2_A244trabajo = new string[] {""} ;
         P007A2_n244trabajo = new bool[] {false} ;
         P007A2_A243estatus = new string[] {""} ;
         P007A2_n243estatus = new bool[] {false} ;
         P007A2_A240cargo_emp = new string[] {""} ;
         P007A2_n240cargo_emp = new bool[] {false} ;
         P007A2_A238correlativo = new int[1] ;
         P007A2_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         P007A2_n241fecha_registro = new bool[] {false} ;
         P007A2_A239nombre_emp = new string[] {""} ;
         P007A2_n239nombre_emp = new bool[] {false} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV33ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.exportwwdetalle_infotec__datastore1(),
            new Object[][] {
                new Object[] {
               P007A2_A254fecha_solicitud, P007A2_n254fecha_solicitud, P007A2_A253observaciones, P007A2_n253observaciones, P007A2_A252prioridad, P007A2_n252prioridad, P007A2_A251detalle_tarea, P007A2_n251detalle_tarea, P007A2_A250id_actividad, P007A2_n250id_actividad,
               P007A2_A249id_categoria, P007A2_n249id_categoria, P007A2_A248detalle_infotecid_unidad, P007A2_n248detalle_infotecid_unidad, P007A2_A247correo_usuario, P007A2_n247correo_usuario, P007A2_A246depto_usuario, P007A2_n246depto_usuario, P007A2_A245nombre_usuario, P007A2_n245nombre_usuario,
               P007A2_A244trabajo, P007A2_n244trabajo, P007A2_A243estatus, P007A2_n243estatus, P007A2_A240cargo_emp, P007A2_n240cargo_emp, P007A2_A238correlativo, P007A2_A241fecha_registro, P007A2_n241fecha_registro, P007A2_A239nombre_emp,
               P007A2_n239nombre_emp
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV26OrderedBy ;
      private short AV31ColumnIndex ;
      private int AV28CellRow ;
      private int AV29FirstColumn ;
      private int A238correlativo ;
      private int A248detalle_infotecid_unidad ;
      private int A249id_categoria ;
      private int A250id_actividad ;
      private int AV63GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private DateTime GXt_dtime1 ;
      private DateTime AV57fecha_registro_From ;
      private DateTime AV58fecha_registro_To ;
      private DateTime A241fecha_registro ;
      private bool returnInSub ;
      private bool AV36GridColumnVisible_correlativo ;
      private bool AV37GridColumnVisible_nombre_emp ;
      private bool AV38GridColumnVisible_cargo_emp ;
      private bool AV39GridColumnVisible_fecha_registro ;
      private bool AV41GridColumnVisible_estatus ;
      private bool AV42GridColumnVisible_trabajo ;
      private bool AV43GridColumnVisible_nombre_usuario ;
      private bool AV44GridColumnVisible_depto_usuario ;
      private bool AV45GridColumnVisible_correo_usuario ;
      private bool AV46GridColumnVisible_detalle_infotecid_unidad ;
      private bool AV47GridColumnVisible_id_categoria ;
      private bool AV48GridColumnVisible_id_actividad ;
      private bool AV49GridColumnVisible_detalle_tarea ;
      private bool AV50GridColumnVisible_prioridad ;
      private bool AV51GridColumnVisible_observaciones ;
      private bool AV52GridColumnVisible_fecha_solicitud ;
      private bool n254fecha_solicitud ;
      private bool n253observaciones ;
      private bool n252prioridad ;
      private bool n251detalle_tarea ;
      private bool n250id_actividad ;
      private bool n249id_categoria ;
      private bool n248detalle_infotecid_unidad ;
      private bool n247correo_usuario ;
      private bool n246depto_usuario ;
      private bool n245nombre_usuario ;
      private bool n244trabajo ;
      private bool n243estatus ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n239nombre_emp ;
      private string AV13nombre_emp ;
      private string AV59OutFile ;
      private string lV13nombre_emp ;
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
      private string AV33ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P007A2_A254fecha_solicitud ;
      private bool[] P007A2_n254fecha_solicitud ;
      private string[] P007A2_A253observaciones ;
      private bool[] P007A2_n253observaciones ;
      private string[] P007A2_A252prioridad ;
      private bool[] P007A2_n252prioridad ;
      private string[] P007A2_A251detalle_tarea ;
      private bool[] P007A2_n251detalle_tarea ;
      private int[] P007A2_A250id_actividad ;
      private bool[] P007A2_n250id_actividad ;
      private int[] P007A2_A249id_categoria ;
      private bool[] P007A2_n249id_categoria ;
      private int[] P007A2_A248detalle_infotecid_unidad ;
      private bool[] P007A2_n248detalle_infotecid_unidad ;
      private string[] P007A2_A247correo_usuario ;
      private bool[] P007A2_n247correo_usuario ;
      private string[] P007A2_A246depto_usuario ;
      private bool[] P007A2_n246depto_usuario ;
      private string[] P007A2_A245nombre_usuario ;
      private bool[] P007A2_n245nombre_usuario ;
      private string[] P007A2_A244trabajo ;
      private bool[] P007A2_n244trabajo ;
      private string[] P007A2_A243estatus ;
      private bool[] P007A2_n243estatus ;
      private string[] P007A2_A240cargo_emp ;
      private bool[] P007A2_n240cargo_emp ;
      private int[] P007A2_A238correlativo ;
      private DateTime[] P007A2_A241fecha_registro ;
      private bool[] P007A2_n241fecha_registro ;
      private string[] P007A2_A239nombre_emp ;
      private bool[] P007A2_n239nombre_emp ;
      private string aP5_OutFile ;
      private ExcelDocumentI AV27ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV35File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV55Context ;
   }

   public class exportwwdetalle_infotec__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007A2( IGxContext context ,
                                             string AV13nombre_emp ,
                                             DateTime AV58fecha_registro_To ,
                                             DateTime AV57fecha_registro_From ,
                                             string AV12K2BToolsGenericSearchField ,
                                             string A239nombre_emp ,
                                             DateTime A241fecha_registro ,
                                             int A238correlativo ,
                                             string A240cargo_emp ,
                                             string A243estatus ,
                                             string A244trabajo ,
                                             string A245nombre_usuario ,
                                             string A246depto_usuario ,
                                             string A247correo_usuario ,
                                             int A248detalle_infotecid_unidad ,
                                             int A249id_categoria ,
                                             int A250id_actividad ,
                                             string A251detalle_tarea ,
                                             string A252prioridad ,
                                             string A253observaciones ,
                                             string A254fecha_solicitud ,
                                             short AV26OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [fecha_solicitud], [observaciones], [prioridad], [detalle_tarea], [id_actividad], [id_categoria], [id_unidad], [correo_usuario], [depto_usuario], [nombre_usuario], [trabajo], [estatus], [cargo_emp], [correlativo], [fecha_registro], [nombre_emp] FROM dbo.[detalle_infotec]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13nombre_emp)) )
         {
            AddWhere(sWhereString, "([nombre_emp] like @lV13nombre_emp)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV58fecha_registro_To) )
         {
            AddWhere(sWhereString, "([fecha_registro] <= @AV58fecha_registro_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57fecha_registro_From) )
         {
            AddWhere(sWhereString, "([fecha_registro] >= @AV57fecha_registro_From)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([correlativo] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [nombre_emp] like '%' + @lV12K2BToolsGenericSearchField + '%' or [cargo_emp] like '%' + @lV12K2BToolsGenericSearchField + '%' or [estatus] like '%' + @lV12K2BToolsGenericSearchField + '%' or [trabajo] like '%' + @lV12K2BToolsGenericSearchField + '%' or [nombre_usuario] like '%' + @lV12K2BToolsGenericSearchField + '%' or [depto_usuario] like '%' + @lV12K2BToolsGenericSearchField + '%' or [correo_usuario] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_categoria] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_actividad] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [detalle_tarea] like '%' + @lV12K2BToolsGenericSearchField + '%' or [prioridad] like '%' + @lV12K2BToolsGenericSearchField + '%' or [observaciones] like '%' + @lV12K2BToolsGenericSearchField + '%' or [fecha_solicitud] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV26OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [correlativo]";
         }
         else if ( AV26OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [correlativo] DESC";
         }
         else if ( AV26OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [nombre_emp]";
         }
         else if ( AV26OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [nombre_emp] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007A2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("@lV13nombre_emp",GXType.NVarChar,300,0) ,
          new ParDef("@AV58fecha_registro_To",GXType.Date,8,0) ,
          new ParDef("@AV57fecha_registro_From",GXType.Date,8,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
