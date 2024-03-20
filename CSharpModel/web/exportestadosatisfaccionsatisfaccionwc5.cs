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
   public class exportestadosatisfaccionsatisfaccionwc5 : GXProcedure
   {
      public exportestadosatisfaccionsatisfaccionwc5( )
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

      public exportestadosatisfaccionsatisfaccionwc5( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SatisfaccionAtencionId ,
                           DateTime aP1_SatisfaccionFecha_From ,
                           DateTime aP2_SatisfaccionFecha_To ,
                           DateTime aP3_UsuarioFecha_From ,
                           DateTime aP4_UsuarioFecha_To ,
                           string aP5_SatisfaccionResueltoNombre ,
                           string aP6_SatisfaccionTecnicoProblemaNombre ,
                           string aP7_SatisfaccionTecnicoCompetenteNombre ,
                           string aP8_SatisfaccionTecnicoProfesionalismoNombre ,
                           string aP9_SatisfaccionTiempoNombre ,
                           string aP10_K2BToolsGenericSearchField ,
                           short aP11_OrderedBy ,
                           out string aP12_OutFile )
      {
         this.AV8SatisfaccionAtencionId = aP0_SatisfaccionAtencionId;
         this.AV11SatisfaccionFecha_From = aP1_SatisfaccionFecha_From;
         this.AV12SatisfaccionFecha_To = aP2_SatisfaccionFecha_To;
         this.AV14UsuarioFecha_From = aP3_UsuarioFecha_From;
         this.AV15UsuarioFecha_To = aP4_UsuarioFecha_To;
         this.AV16SatisfaccionResueltoNombre = aP5_SatisfaccionResueltoNombre;
         this.AV17SatisfaccionTecnicoProblemaNombre = aP6_SatisfaccionTecnicoProblemaNombre;
         this.AV18SatisfaccionTecnicoCompetenteNombre = aP7_SatisfaccionTecnicoCompetenteNombre;
         this.AV19SatisfaccionTecnicoProfesionalismoNombre = aP8_SatisfaccionTecnicoProfesionalismoNombre;
         this.AV20SatisfaccionTiempoNombre = aP9_SatisfaccionTiempoNombre;
         this.AV9K2BToolsGenericSearchField = aP10_K2BToolsGenericSearchField;
         this.AV21OrderedBy = aP11_OrderedBy;
         this.AV50OutFile = "" ;
         initialize();
         executePrivate();
         aP12_OutFile=this.AV50OutFile;
      }

      public string executeUdp( short aP0_SatisfaccionAtencionId ,
                                DateTime aP1_SatisfaccionFecha_From ,
                                DateTime aP2_SatisfaccionFecha_To ,
                                DateTime aP3_UsuarioFecha_From ,
                                DateTime aP4_UsuarioFecha_To ,
                                string aP5_SatisfaccionResueltoNombre ,
                                string aP6_SatisfaccionTecnicoProblemaNombre ,
                                string aP7_SatisfaccionTecnicoCompetenteNombre ,
                                string aP8_SatisfaccionTecnicoProfesionalismoNombre ,
                                string aP9_SatisfaccionTiempoNombre ,
                                string aP10_K2BToolsGenericSearchField ,
                                short aP11_OrderedBy )
      {
         execute(aP0_SatisfaccionAtencionId, aP1_SatisfaccionFecha_From, aP2_SatisfaccionFecha_To, aP3_UsuarioFecha_From, aP4_UsuarioFecha_To, aP5_SatisfaccionResueltoNombre, aP6_SatisfaccionTecnicoProblemaNombre, aP7_SatisfaccionTecnicoCompetenteNombre, aP8_SatisfaccionTecnicoProfesionalismoNombre, aP9_SatisfaccionTiempoNombre, aP10_K2BToolsGenericSearchField, aP11_OrderedBy, out aP12_OutFile);
         return AV50OutFile ;
      }

      public void executeSubmit( short aP0_SatisfaccionAtencionId ,
                                 DateTime aP1_SatisfaccionFecha_From ,
                                 DateTime aP2_SatisfaccionFecha_To ,
                                 DateTime aP3_UsuarioFecha_From ,
                                 DateTime aP4_UsuarioFecha_To ,
                                 string aP5_SatisfaccionResueltoNombre ,
                                 string aP6_SatisfaccionTecnicoProblemaNombre ,
                                 string aP7_SatisfaccionTecnicoCompetenteNombre ,
                                 string aP8_SatisfaccionTecnicoProfesionalismoNombre ,
                                 string aP9_SatisfaccionTiempoNombre ,
                                 string aP10_K2BToolsGenericSearchField ,
                                 short aP11_OrderedBy ,
                                 out string aP12_OutFile )
      {
         exportestadosatisfaccionsatisfaccionwc5 objexportestadosatisfaccionsatisfaccionwc5;
         objexportestadosatisfaccionsatisfaccionwc5 = new exportestadosatisfaccionsatisfaccionwc5();
         objexportestadosatisfaccionsatisfaccionwc5.AV8SatisfaccionAtencionId = aP0_SatisfaccionAtencionId;
         objexportestadosatisfaccionsatisfaccionwc5.AV11SatisfaccionFecha_From = aP1_SatisfaccionFecha_From;
         objexportestadosatisfaccionsatisfaccionwc5.AV12SatisfaccionFecha_To = aP2_SatisfaccionFecha_To;
         objexportestadosatisfaccionsatisfaccionwc5.AV14UsuarioFecha_From = aP3_UsuarioFecha_From;
         objexportestadosatisfaccionsatisfaccionwc5.AV15UsuarioFecha_To = aP4_UsuarioFecha_To;
         objexportestadosatisfaccionsatisfaccionwc5.AV16SatisfaccionResueltoNombre = aP5_SatisfaccionResueltoNombre;
         objexportestadosatisfaccionsatisfaccionwc5.AV17SatisfaccionTecnicoProblemaNombre = aP6_SatisfaccionTecnicoProblemaNombre;
         objexportestadosatisfaccionsatisfaccionwc5.AV18SatisfaccionTecnicoCompetenteNombre = aP7_SatisfaccionTecnicoCompetenteNombre;
         objexportestadosatisfaccionsatisfaccionwc5.AV19SatisfaccionTecnicoProfesionalismoNombre = aP8_SatisfaccionTecnicoProfesionalismoNombre;
         objexportestadosatisfaccionsatisfaccionwc5.AV20SatisfaccionTiempoNombre = aP9_SatisfaccionTiempoNombre;
         objexportestadosatisfaccionsatisfaccionwc5.AV9K2BToolsGenericSearchField = aP10_K2BToolsGenericSearchField;
         objexportestadosatisfaccionsatisfaccionwc5.AV21OrderedBy = aP11_OrderedBy;
         objexportestadosatisfaccionsatisfaccionwc5.AV50OutFile = "" ;
         objexportestadosatisfaccionsatisfaccionwc5.context.SetSubmitInitialConfig(context);
         objexportestadosatisfaccionsatisfaccionwc5.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportestadosatisfaccionsatisfaccionwc5);
         aP12_OutFile=this.AV50OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportestadosatisfaccionsatisfaccionwc5)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV48Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV50OutFile = GxDirectory.TemporaryFilesPath + AV30File.Separator + "ExportEstadoSatisfaccionSatisfaccionWC5-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV22ExcelDocument.Open(AV50OutFile);
         AV22ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV22ExcelDocument.Clear();
         AV23CellRow = 1;
         AV24FirstColumn = 1;
         AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn, 1, 1).Size = 15;
         AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn, 1, 1).Bold = 1;
         AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn, 1, 1).Text = "Satisfacciones";
         AV23CellRow = (int)(AV23CellRow+4);
         /* Using cursor P00342 */
         pr_default.execute(0, new Object[] {AV8SatisfaccionAtencionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4EstadoSatisfaccionId = P00342_A4EstadoSatisfaccionId[0];
            A22EstadoSatisfaccionNombre = P00342_A22EstadoSatisfaccionNombre[0];
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Satisfacción";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A22EstadoSatisfaccionNombre);
            AV23CellRow = (int)(AV23CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV11SatisfaccionFecha_From) || ! (DateTime.MinValue==AV12SatisfaccionFecha_To) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Fecha Encuesta:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV11SatisfaccionFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV12SatisfaccionFecha_To, 2, "/");
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14UsuarioFecha_From) || ! (DateTime.MinValue==AV15UsuarioFecha_To) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Fecha";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV14UsuarioFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV15UsuarioFecha_To, 2, "/");
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SatisfaccionResueltoNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Respuesta:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV16SatisfaccionResueltoNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Respuesta:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Respuesta:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Respuesta:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SatisfaccionTiempoNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Respuesta:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV20SatisfaccionTiempoNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         AV23CellRow = (int)(AV23CellRow+3);
         AV26ColumnIndex = 0;
         if ( AV35GridColumnVisible_SatisfaccionId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Id";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_SatisfaccionFecha )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Fecha Encuesta:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_TicketId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "RST No.";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_UsuarioId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Id Usuario";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_UsuarioNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Usuario";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_UsuarioFecha )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Fecha Inicio:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_UsuarioRequerimiento )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Requerimiento";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_SatisfaccionResueltoNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Respuesta:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_SatisfaccionTecnicoProblemaNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Respuesta:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_SatisfaccionTecnicoCompetenteNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Respuesta:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV45GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Respuesta:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV46GridColumnVisible_SatisfaccionTiempoNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Respuesta:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV47GridColumnVisible_SatisfaccionSugerencia )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Sugerencia:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV12SatisfaccionFecha_To ,
                                              AV11SatisfaccionFecha_From ,
                                              AV15UsuarioFecha_To ,
                                              AV14UsuarioFecha_From ,
                                              AV16SatisfaccionResueltoNombre ,
                                              AV17SatisfaccionTecnicoProblemaNombre ,
                                              AV18SatisfaccionTecnicoCompetenteNombre ,
                                              AV19SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV20SatisfaccionTiempoNombre ,
                                              AV9K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A36SatisfaccionTecnicoProblemaNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A7SatisfaccionId ,
                                              A14TicketId ,
                                              A15UsuarioId ,
                                              A93UsuarioNombre ,
                                              A94UsuarioRequerimiento ,
                                              A34SatisfaccionSugerencia ,
                                              AV21OrderedBy ,
                                              AV8SatisfaccionAtencionId ,
                                              A13SatisfaccionAtencionId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV16SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV16SatisfaccionResueltoNombre), "%", "");
         lV17SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre), "%", "");
         lV18SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV19SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV20SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV20SatisfaccionTiempoNombre), "%", "");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P00343 */
         pr_default.execute(1, new Object[] {AV8SatisfaccionAtencionId, AV12SatisfaccionFecha_To, AV11SatisfaccionFecha_From, AV15UsuarioFecha_To, AV14UsuarioFecha_From, lV16SatisfaccionResueltoNombre, lV17SatisfaccionTecnicoProblemaNombre, lV18SatisfaccionTecnicoCompetenteNombre, lV19SatisfaccionTecnicoProfesionalismoNombre, lV20SatisfaccionTiempoNombre, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A8SatisfaccionResueltoId = P00343_A8SatisfaccionResueltoId[0];
            A9SatisfaccionTecnicoProblemaId = P00343_A9SatisfaccionTecnicoProblemaId[0];
            A10SatisfaccionTecnicoCompetenteId = P00343_A10SatisfaccionTecnicoCompetenteId[0];
            A11SatisfaccionTecnicoProfesionalismoId = P00343_A11SatisfaccionTecnicoProfesionalismoId[0];
            A12SatisfaccionTiempoId = P00343_A12SatisfaccionTiempoId[0];
            A34SatisfaccionSugerencia = P00343_A34SatisfaccionSugerencia[0];
            n34SatisfaccionSugerencia = P00343_n34SatisfaccionSugerencia[0];
            A94UsuarioRequerimiento = P00343_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P00343_A93UsuarioNombre[0];
            A15UsuarioId = P00343_A15UsuarioId[0];
            A14TicketId = P00343_A14TicketId[0];
            A7SatisfaccionId = P00343_A7SatisfaccionId[0];
            A38SatisfaccionTiempoNombre = P00343_A38SatisfaccionTiempoNombre[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = P00343_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            A35SatisfaccionTecnicoCompetenteNombre = P00343_A35SatisfaccionTecnicoCompetenteNombre[0];
            A36SatisfaccionTecnicoProblemaNombre = P00343_A36SatisfaccionTecnicoProblemaNombre[0];
            A33SatisfaccionResueltoNombre = P00343_A33SatisfaccionResueltoNombre[0];
            A90UsuarioFecha = P00343_A90UsuarioFecha[0];
            A32SatisfaccionFecha = P00343_A32SatisfaccionFecha[0];
            A13SatisfaccionAtencionId = P00343_A13SatisfaccionAtencionId[0];
            A33SatisfaccionResueltoNombre = P00343_A33SatisfaccionResueltoNombre[0];
            A36SatisfaccionTecnicoProblemaNombre = P00343_A36SatisfaccionTecnicoProblemaNombre[0];
            A35SatisfaccionTecnicoCompetenteNombre = P00343_A35SatisfaccionTecnicoCompetenteNombre[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = P00343_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            A38SatisfaccionTiempoNombre = P00343_A38SatisfaccionTiempoNombre[0];
            A15UsuarioId = P00343_A15UsuarioId[0];
            A94UsuarioRequerimiento = P00343_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P00343_A93UsuarioNombre[0];
            A90UsuarioFecha = P00343_A90UsuarioFecha[0];
            AV23CellRow = (int)(AV23CellRow+1);
            AV26ColumnIndex = 0;
            if ( AV35GridColumnVisible_SatisfaccionId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A7SatisfaccionId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_SatisfaccionFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A32SatisfaccionFecha ) ;
               AV22ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_TicketId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A14TicketId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_UsuarioId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A15UsuarioId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_UsuarioNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_UsuarioFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A90UsuarioFecha ) ;
               AV22ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_UsuarioRequerimiento )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_SatisfaccionResueltoNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A33SatisfaccionResueltoNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_SatisfaccionTecnicoProblemaNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A36SatisfaccionTecnicoProblemaNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_SatisfaccionTecnicoCompetenteNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A35SatisfaccionTecnicoCompetenteNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV45GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A37SatisfaccionTecnicoProfesionalismoNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV46GridColumnVisible_SatisfaccionTiempoNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A38SatisfaccionTiempoNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV47GridColumnVisible_SatisfaccionSugerencia )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A34SatisfaccionSugerencia);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV22ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV22ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV22ExcelDocument.ErrCode != 0 )
         {
            AV50OutFile = "";
            AV28ErrorMessage = AV22ExcelDocument.ErrDescription;
            AV22ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "EstadoSatisfaccionSatisfaccionWC5",  "Grid", ref  AV31GridConfiguration) ;
         AV33GridColumns = AV31GridConfiguration.gxTpr_Gridcolumns;
         AV35GridColumnVisible_SatisfaccionId = true;
         AV36GridColumnVisible_SatisfaccionFecha = true;
         AV37GridColumnVisible_TicketId = true;
         AV38GridColumnVisible_UsuarioId = true;
         AV39GridColumnVisible_UsuarioNombre = true;
         AV40GridColumnVisible_UsuarioFecha = true;
         AV41GridColumnVisible_UsuarioRequerimiento = true;
         AV42GridColumnVisible_SatisfaccionResueltoNombre = true;
         AV43GridColumnVisible_SatisfaccionTecnicoProblemaNombre = true;
         AV44GridColumnVisible_SatisfaccionTecnicoCompetenteNombre = true;
         AV45GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre = true;
         AV46GridColumnVisible_SatisfaccionTiempoNombre = true;
         AV47GridColumnVisible_SatisfaccionSugerencia = true;
         new k2bsavegridconfiguration(context ).execute(  "EstadoSatisfaccionSatisfaccionWC5",  "Grid",  AV31GridConfiguration,  false) ;
         AV33GridColumns = AV31GridConfiguration.gxTpr_Gridcolumns;
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV33GridColumns.Count )
         {
            AV34GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV33GridColumns.Item(AV55GXV1));
            if ( ! AV34GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionId") == 0 )
               {
                  AV35GridColumnVisible_SatisfaccionId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionFecha") == 0 )
               {
                  AV36GridColumnVisible_SatisfaccionFecha = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV37GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV38GridColumnVisible_UsuarioId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV39GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  AV40GridColumnVisible_UsuarioFecha = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV41GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionResueltoNombre") == 0 )
               {
                  AV42GridColumnVisible_SatisfaccionResueltoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProblemaNombre") == 0 )
               {
                  AV43GridColumnVisible_SatisfaccionTecnicoProblemaNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteNombre") == 0 )
               {
                  AV44GridColumnVisible_SatisfaccionTecnicoCompetenteNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
               {
                  AV45GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionTiempoNombre") == 0 )
               {
                  AV46GridColumnVisible_SatisfaccionTiempoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "SatisfaccionSugerencia") == 0 )
               {
                  AV47GridColumnVisible_SatisfaccionSugerencia = false;
               }
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV33GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionId";
         AV34GridColumn.gxTpr_Columntitle = "Id";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionFecha";
         AV34GridColumn.gxTpr_Columntitle = "Fecha Encuesta:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketId";
         AV34GridColumn.gxTpr_Columntitle = "RST No.";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioId";
         AV34GridColumn.gxTpr_Columntitle = "Id Usuario";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV34GridColumn.gxTpr_Columntitle = "Usuario";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV34GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV34GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionResueltoNombre";
         AV34GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoProblemaNombre";
         AV34GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoCompetenteNombre";
         AV34GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoProfesionalismoNombre";
         AV34GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionTiempoNombre";
         AV34GridColumn.gxTpr_Columntitle = "Respuesta:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "SatisfaccionSugerencia";
         AV34GridColumn.gxTpr_Columntitle = "Sugerencia:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV31GridConfiguration.gxTpr_Gridcolumns = AV33GridColumns;
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
         AV50OutFile = "";
         AV48Context = new SdtK2BContext(context);
         AV30File = new GxFile(context.GetPhysicalPath());
         AV22ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00342_A4EstadoSatisfaccionId = new short[1] ;
         P00342_A22EstadoSatisfaccionNombre = new string[] {""} ;
         A22EstadoSatisfaccionNombre = "";
         lV16SatisfaccionResueltoNombre = "";
         lV17SatisfaccionTecnicoProblemaNombre = "";
         lV18SatisfaccionTecnicoCompetenteNombre = "";
         lV19SatisfaccionTecnicoProfesionalismoNombre = "";
         lV20SatisfaccionTiempoNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         A90UsuarioFecha = DateTime.MinValue;
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A34SatisfaccionSugerencia = "";
         P00343_A8SatisfaccionResueltoId = new short[1] ;
         P00343_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         P00343_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         P00343_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         P00343_A12SatisfaccionTiempoId = new short[1] ;
         P00343_A34SatisfaccionSugerencia = new string[] {""} ;
         P00343_n34SatisfaccionSugerencia = new bool[] {false} ;
         P00343_A94UsuarioRequerimiento = new string[] {""} ;
         P00343_A93UsuarioNombre = new string[] {""} ;
         P00343_A15UsuarioId = new long[1] ;
         P00343_A14TicketId = new long[1] ;
         P00343_A7SatisfaccionId = new long[1] ;
         P00343_A38SatisfaccionTiempoNombre = new string[] {""} ;
         P00343_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         P00343_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         P00343_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         P00343_A33SatisfaccionResueltoNombre = new string[] {""} ;
         P00343_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P00343_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         P00343_A13SatisfaccionAtencionId = new short[1] ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV28ErrorMessage = "";
         AV31GridConfiguration = new SdtK2BGridConfiguration(context);
         AV33GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportestadosatisfaccionsatisfaccionwc5__default(),
            new Object[][] {
                new Object[] {
               P00342_A4EstadoSatisfaccionId, P00342_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               P00343_A8SatisfaccionResueltoId, P00343_A9SatisfaccionTecnicoProblemaId, P00343_A10SatisfaccionTecnicoCompetenteId, P00343_A11SatisfaccionTecnicoProfesionalismoId, P00343_A12SatisfaccionTiempoId, P00343_A34SatisfaccionSugerencia, P00343_n34SatisfaccionSugerencia, P00343_A94UsuarioRequerimiento, P00343_A93UsuarioNombre, P00343_A15UsuarioId,
               P00343_A14TicketId, P00343_A7SatisfaccionId, P00343_A38SatisfaccionTiempoNombre, P00343_A37SatisfaccionTecnicoProfesionalismoNombre, P00343_A35SatisfaccionTecnicoCompetenteNombre, P00343_A36SatisfaccionTecnicoProblemaNombre, P00343_A33SatisfaccionResueltoNombre, P00343_A90UsuarioFecha, P00343_A32SatisfaccionFecha, P00343_A13SatisfaccionAtencionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8SatisfaccionAtencionId ;
      private short AV21OrderedBy ;
      private short A4EstadoSatisfaccionId ;
      private short AV26ColumnIndex ;
      private short A13SatisfaccionAtencionId ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private int AV23CellRow ;
      private int AV24FirstColumn ;
      private int AV55GXV1 ;
      private long A7SatisfaccionId ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private string AV9K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime GXt_dtime1 ;
      private DateTime AV11SatisfaccionFecha_From ;
      private DateTime AV12SatisfaccionFecha_To ;
      private DateTime AV14UsuarioFecha_From ;
      private DateTime AV15UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private bool returnInSub ;
      private bool AV35GridColumnVisible_SatisfaccionId ;
      private bool AV36GridColumnVisible_SatisfaccionFecha ;
      private bool AV37GridColumnVisible_TicketId ;
      private bool AV38GridColumnVisible_UsuarioId ;
      private bool AV39GridColumnVisible_UsuarioNombre ;
      private bool AV40GridColumnVisible_UsuarioFecha ;
      private bool AV41GridColumnVisible_UsuarioRequerimiento ;
      private bool AV42GridColumnVisible_SatisfaccionResueltoNombre ;
      private bool AV43GridColumnVisible_SatisfaccionTecnicoProblemaNombre ;
      private bool AV44GridColumnVisible_SatisfaccionTecnicoCompetenteNombre ;
      private bool AV45GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre ;
      private bool AV46GridColumnVisible_SatisfaccionTiempoNombre ;
      private bool AV47GridColumnVisible_SatisfaccionSugerencia ;
      private bool n34SatisfaccionSugerencia ;
      private string AV16SatisfaccionResueltoNombre ;
      private string AV17SatisfaccionTecnicoProblemaNombre ;
      private string AV18SatisfaccionTecnicoCompetenteNombre ;
      private string AV19SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV20SatisfaccionTiempoNombre ;
      private string AV50OutFile ;
      private string A22EstadoSatisfaccionNombre ;
      private string lV16SatisfaccionResueltoNombre ;
      private string lV17SatisfaccionTecnicoProblemaNombre ;
      private string lV18SatisfaccionTecnicoCompetenteNombre ;
      private string lV19SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV20SatisfaccionTiempoNombre ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A34SatisfaccionSugerencia ;
      private string AV28ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00342_A4EstadoSatisfaccionId ;
      private string[] P00342_A22EstadoSatisfaccionNombre ;
      private short[] P00343_A8SatisfaccionResueltoId ;
      private short[] P00343_A9SatisfaccionTecnicoProblemaId ;
      private short[] P00343_A10SatisfaccionTecnicoCompetenteId ;
      private short[] P00343_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] P00343_A12SatisfaccionTiempoId ;
      private string[] P00343_A34SatisfaccionSugerencia ;
      private bool[] P00343_n34SatisfaccionSugerencia ;
      private string[] P00343_A94UsuarioRequerimiento ;
      private string[] P00343_A93UsuarioNombre ;
      private long[] P00343_A15UsuarioId ;
      private long[] P00343_A14TicketId ;
      private long[] P00343_A7SatisfaccionId ;
      private string[] P00343_A38SatisfaccionTiempoNombre ;
      private string[] P00343_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string[] P00343_A35SatisfaccionTecnicoCompetenteNombre ;
      private string[] P00343_A36SatisfaccionTecnicoProblemaNombre ;
      private string[] P00343_A33SatisfaccionResueltoNombre ;
      private DateTime[] P00343_A90UsuarioFecha ;
      private DateTime[] P00343_A32SatisfaccionFecha ;
      private short[] P00343_A13SatisfaccionAtencionId ;
      private string aP12_OutFile ;
      private ExcelDocumentI AV22ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV33GridColumns ;
      private GxFile AV30File ;
      private SdtK2BGridConfiguration AV31GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV34GridColumn ;
      private SdtK2BContext AV48Context ;
   }

   public class exportestadosatisfaccionsatisfaccionwc5__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00343( IGxContext context ,
                                             DateTime AV12SatisfaccionFecha_To ,
                                             DateTime AV11SatisfaccionFecha_From ,
                                             DateTime AV15UsuarioFecha_To ,
                                             DateTime AV14UsuarioFecha_From ,
                                             string AV16SatisfaccionResueltoNombre ,
                                             string AV17SatisfaccionTecnicoProblemaNombre ,
                                             string AV18SatisfaccionTecnicoCompetenteNombre ,
                                             string AV19SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV20SatisfaccionTiempoNombre ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             long A7SatisfaccionId ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV21OrderedBy ,
                                             short AV8SatisfaccionAtencionId ,
                                             short A13SatisfaccionAtencionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[21];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T1.[SatisfaccionSugerencia], T8.[UsuarioRequerimiento], T8.[UsuarioNombre], T7.[UsuarioId], T1.[TicketId], T1.[SatisfaccionId], T6.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T2.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T8.[UsuarioFecha], T1.[SatisfaccionFecha], T1.[SatisfaccionAtencionId] FROM ((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [Ticket] T7 ON T7.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T8 ON T8.[UsuarioId] = T7.[UsuarioId])";
         AddWhere(sWhereString, "(T1.[SatisfaccionAtencionId] = @AV8SatisfaccionAtencionId)");
         if ( ! (DateTime.MinValue==AV12SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV12SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV11SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV15UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T8.[UsuarioFecha] <= @AV15UsuarioFecha_To)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV14UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T8.[UsuarioFecha] >= @AV14UsuarioFecha_From)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV16SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV17SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV18SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV19SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV20SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T7.[UsuarioId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T8.[UsuarioNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T8.[UsuarioRequerimiento] like '%' + @lV9K2BToolsGenericSearchField + '%' or T2.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
            GXv_int2[18] = 1;
            GXv_int2[19] = 1;
            GXv_int2[20] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV21OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV21OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV21OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV21OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha] DESC";
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
               case 1 :
                     return conditional_P00343(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00342;
          prmP00342 = new Object[] {
          new ParDef("@AV8SatisfaccionAtencionId",GXType.Int16,4,0)
          };
          Object[] prmP00343;
          prmP00343 = new Object[] {
          new ParDef("@AV8SatisfaccionAtencionId",GXType.Int16,4,0) ,
          new ParDef("@AV12SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV11SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV15UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV14UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV16SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV17SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV18SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV19SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV20SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00342", "SELECT TOP 1 [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @AV8SatisfaccionAtencionId ORDER BY [EstadoSatisfaccionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00342,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00343", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00343,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(17);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(18);
                ((short[]) buf[19])[0] = rslt.getShort(19);
                return;
       }
    }

 }

}
