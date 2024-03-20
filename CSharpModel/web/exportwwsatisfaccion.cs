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
   public class exportwwsatisfaccion : GXProcedure
   {
      public exportwwsatisfaccion( )
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

      public exportwwsatisfaccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_SatisfaccionFecha_From ,
                           DateTime aP1_SatisfaccionFecha_To ,
                           DateTime aP2_UsuarioFecha_From ,
                           DateTime aP3_UsuarioFecha_To ,
                           string aP4_SatisfaccionResueltoNombre ,
                           string aP5_SatisfaccionTecnicoProblemaNombre ,
                           string aP6_SatisfaccionTecnicoCompetenteNombre ,
                           string aP7_SatisfaccionTecnicoProfesionalismoNombre ,
                           string aP8_SatisfaccionTiempoNombre ,
                           string aP9_SatisfaccionAtencionNombre ,
                           string aP10_UsuarioNombre ,
                           string aP11_K2BToolsGenericSearchField ,
                           short aP12_OrderedBy ,
                           out string aP13_OutFile )
      {
         this.AV14SatisfaccionFecha_From = aP0_SatisfaccionFecha_From;
         this.AV15SatisfaccionFecha_To = aP1_SatisfaccionFecha_To;
         this.AV17UsuarioFecha_From = aP2_UsuarioFecha_From;
         this.AV18UsuarioFecha_To = aP3_UsuarioFecha_To;
         this.AV19SatisfaccionResueltoNombre = aP4_SatisfaccionResueltoNombre;
         this.AV20SatisfaccionTecnicoProblemaNombre = aP5_SatisfaccionTecnicoProblemaNombre;
         this.AV21SatisfaccionTecnicoCompetenteNombre = aP6_SatisfaccionTecnicoCompetenteNombre;
         this.AV22SatisfaccionTecnicoProfesionalismoNombre = aP7_SatisfaccionTecnicoProfesionalismoNombre;
         this.AV23SatisfaccionTiempoNombre = aP8_SatisfaccionTiempoNombre;
         this.AV24SatisfaccionAtencionNombre = aP9_SatisfaccionAtencionNombre;
         this.AV53UsuarioNombre = aP10_UsuarioNombre;
         this.AV12K2BToolsGenericSearchField = aP11_K2BToolsGenericSearchField;
         this.AV25OrderedBy = aP12_OrderedBy;
         this.AV54OutFile = "" ;
         initialize();
         executePrivate();
         aP13_OutFile=this.AV54OutFile;
      }

      public string executeUdp( DateTime aP0_SatisfaccionFecha_From ,
                                DateTime aP1_SatisfaccionFecha_To ,
                                DateTime aP2_UsuarioFecha_From ,
                                DateTime aP3_UsuarioFecha_To ,
                                string aP4_SatisfaccionResueltoNombre ,
                                string aP5_SatisfaccionTecnicoProblemaNombre ,
                                string aP6_SatisfaccionTecnicoCompetenteNombre ,
                                string aP7_SatisfaccionTecnicoProfesionalismoNombre ,
                                string aP8_SatisfaccionTiempoNombre ,
                                string aP9_SatisfaccionAtencionNombre ,
                                string aP10_UsuarioNombre ,
                                string aP11_K2BToolsGenericSearchField ,
                                short aP12_OrderedBy )
      {
         execute(aP0_SatisfaccionFecha_From, aP1_SatisfaccionFecha_To, aP2_UsuarioFecha_From, aP3_UsuarioFecha_To, aP4_SatisfaccionResueltoNombre, aP5_SatisfaccionTecnicoProblemaNombre, aP6_SatisfaccionTecnicoCompetenteNombre, aP7_SatisfaccionTecnicoProfesionalismoNombre, aP8_SatisfaccionTiempoNombre, aP9_SatisfaccionAtencionNombre, aP10_UsuarioNombre, aP11_K2BToolsGenericSearchField, aP12_OrderedBy, out aP13_OutFile);
         return AV54OutFile ;
      }

      public void executeSubmit( DateTime aP0_SatisfaccionFecha_From ,
                                 DateTime aP1_SatisfaccionFecha_To ,
                                 DateTime aP2_UsuarioFecha_From ,
                                 DateTime aP3_UsuarioFecha_To ,
                                 string aP4_SatisfaccionResueltoNombre ,
                                 string aP5_SatisfaccionTecnicoProblemaNombre ,
                                 string aP6_SatisfaccionTecnicoCompetenteNombre ,
                                 string aP7_SatisfaccionTecnicoProfesionalismoNombre ,
                                 string aP8_SatisfaccionTiempoNombre ,
                                 string aP9_SatisfaccionAtencionNombre ,
                                 string aP10_UsuarioNombre ,
                                 string aP11_K2BToolsGenericSearchField ,
                                 short aP12_OrderedBy ,
                                 out string aP13_OutFile )
      {
         exportwwsatisfaccion objexportwwsatisfaccion;
         objexportwwsatisfaccion = new exportwwsatisfaccion();
         objexportwwsatisfaccion.AV14SatisfaccionFecha_From = aP0_SatisfaccionFecha_From;
         objexportwwsatisfaccion.AV15SatisfaccionFecha_To = aP1_SatisfaccionFecha_To;
         objexportwwsatisfaccion.AV17UsuarioFecha_From = aP2_UsuarioFecha_From;
         objexportwwsatisfaccion.AV18UsuarioFecha_To = aP3_UsuarioFecha_To;
         objexportwwsatisfaccion.AV19SatisfaccionResueltoNombre = aP4_SatisfaccionResueltoNombre;
         objexportwwsatisfaccion.AV20SatisfaccionTecnicoProblemaNombre = aP5_SatisfaccionTecnicoProblemaNombre;
         objexportwwsatisfaccion.AV21SatisfaccionTecnicoCompetenteNombre = aP6_SatisfaccionTecnicoCompetenteNombre;
         objexportwwsatisfaccion.AV22SatisfaccionTecnicoProfesionalismoNombre = aP7_SatisfaccionTecnicoProfesionalismoNombre;
         objexportwwsatisfaccion.AV23SatisfaccionTiempoNombre = aP8_SatisfaccionTiempoNombre;
         objexportwwsatisfaccion.AV24SatisfaccionAtencionNombre = aP9_SatisfaccionAtencionNombre;
         objexportwwsatisfaccion.AV53UsuarioNombre = aP10_UsuarioNombre;
         objexportwwsatisfaccion.AV12K2BToolsGenericSearchField = aP11_K2BToolsGenericSearchField;
         objexportwwsatisfaccion.AV25OrderedBy = aP12_OrderedBy;
         objexportwwsatisfaccion.AV54OutFile = "" ;
         objexportwwsatisfaccion.context.SetSubmitInitialConfig(context);
         objexportwwsatisfaccion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwsatisfaccion);
         aP13_OutFile=this.AV54OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwsatisfaccion)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV49Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV54OutFile = GxDirectory.TemporaryFilesPath + AV34File.Separator + "ExportWWSatisfaccion-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV26ExcelDocument.Open(AV54OutFile);
         AV26ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26ExcelDocument.Clear();
         AV27CellRow = 1;
         AV28FirstColumn = 1;
         AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn, 1, 1).Size = 15;
         AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn, 1, 1).Text = "Satisfacciones";
         AV27CellRow = (int)(AV27CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV27CellRow = (int)(AV27CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14SatisfaccionFecha_From) || ! (DateTime.MinValue==AV15SatisfaccionFecha_To) )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Text = "Fecha Encuesta:";
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV14SatisfaccionFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV15SatisfaccionFecha_To, 2, "/");
            AV27CellRow = (int)(AV27CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV17UsuarioFecha_From) || ! (DateTime.MinValue==AV18UsuarioFecha_To) )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Text = "Fecha";
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV17UsuarioFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV18UsuarioFecha_To, 2, "/");
            AV27CellRow = (int)(AV27CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53UsuarioNombre)) )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+0, 1, 1).Text = "Usuario";
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV53UsuarioNombre);
            AV27CellRow = (int)(AV27CellRow+1);
         }
         AV27CellRow = (int)(AV27CellRow+3);
         AV30ColumnIndex = 0;
         if ( AV37GridColumnVisible_TicketId )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = "RST No.";
            AV30ColumnIndex = (short)(AV30ColumnIndex+1);
         }
         if ( AV51GridColumnVisible_TicketResponsableId )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = "Id TR:";
            AV30ColumnIndex = (short)(AV30ColumnIndex+1);
         }
         if ( AV52GridColumnVisible_TicketTecnicoResponsableNombre )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = "Técnico";
            AV30ColumnIndex = (short)(AV30ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_UsuarioNombre )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = "Usuario";
            AV30ColumnIndex = (short)(AV30ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_UsuarioFecha )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = "Fecha Inicio:";
            AV30ColumnIndex = (short)(AV30ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_UsuarioRequerimiento )
         {
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = "Requerimiento";
            AV30ColumnIndex = (short)(AV30ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV15SatisfaccionFecha_To ,
                                              AV14SatisfaccionFecha_From ,
                                              AV18UsuarioFecha_To ,
                                              AV17UsuarioFecha_From ,
                                              AV19SatisfaccionResueltoNombre ,
                                              AV20SatisfaccionTecnicoProblemaNombre ,
                                              AV21SatisfaccionTecnicoCompetenteNombre ,
                                              AV22SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV23SatisfaccionTiempoNombre ,
                                              AV24SatisfaccionAtencionNombre ,
                                              AV53UsuarioNombre ,
                                              AV12K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A36SatisfaccionTecnicoProblemaNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A31SatisfaccionAtencionNombre ,
                                              A93UsuarioNombre ,
                                              A14TicketId ,
                                              A16TicketResponsableId ,
                                              A199TicketTecnicoResponsableNombre ,
                                              A94UsuarioRequerimiento ,
                                              AV25OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV19SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV19SatisfaccionResueltoNombre), "%", "");
         lV20SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV20SatisfaccionTecnicoProblemaNombre), "%", "");
         lV21SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV21SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV22SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV22SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV23SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV23SatisfaccionTiempoNombre), "%", "");
         lV24SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV24SatisfaccionAtencionNombre), "%", "");
         lV53UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV53UsuarioNombre), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003W2 */
         pr_default.execute(0, new Object[] {AV15SatisfaccionFecha_To, AV14SatisfaccionFecha_From, AV18UsuarioFecha_To, AV17UsuarioFecha_From, lV19SatisfaccionResueltoNombre, lV20SatisfaccionTecnicoProblemaNombre, lV21SatisfaccionTecnicoCompetenteNombre, lV22SatisfaccionTecnicoProfesionalismoNombre, lV23SatisfaccionTiempoNombre, lV24SatisfaccionAtencionNombre, lV53UsuarioNombre, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A198TicketTecnicoResponsableId = P003W2_A198TicketTecnicoResponsableId[0];
            A15UsuarioId = P003W2_A15UsuarioId[0];
            A8SatisfaccionResueltoId = P003W2_A8SatisfaccionResueltoId[0];
            A9SatisfaccionTecnicoProblemaId = P003W2_A9SatisfaccionTecnicoProblemaId[0];
            A10SatisfaccionTecnicoCompetenteId = P003W2_A10SatisfaccionTecnicoCompetenteId[0];
            A11SatisfaccionTecnicoProfesionalismoId = P003W2_A11SatisfaccionTecnicoProfesionalismoId[0];
            A12SatisfaccionTiempoId = P003W2_A12SatisfaccionTiempoId[0];
            A13SatisfaccionAtencionId = P003W2_A13SatisfaccionAtencionId[0];
            A94UsuarioRequerimiento = P003W2_A94UsuarioRequerimiento[0];
            A199TicketTecnicoResponsableNombre = P003W2_A199TicketTecnicoResponsableNombre[0];
            A16TicketResponsableId = P003W2_A16TicketResponsableId[0];
            A14TicketId = P003W2_A14TicketId[0];
            A93UsuarioNombre = P003W2_A93UsuarioNombre[0];
            A31SatisfaccionAtencionNombre = P003W2_A31SatisfaccionAtencionNombre[0];
            A38SatisfaccionTiempoNombre = P003W2_A38SatisfaccionTiempoNombre[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = P003W2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            A35SatisfaccionTecnicoCompetenteNombre = P003W2_A35SatisfaccionTecnicoCompetenteNombre[0];
            A36SatisfaccionTecnicoProblemaNombre = P003W2_A36SatisfaccionTecnicoProblemaNombre[0];
            A33SatisfaccionResueltoNombre = P003W2_A33SatisfaccionResueltoNombre[0];
            A90UsuarioFecha = P003W2_A90UsuarioFecha[0];
            A32SatisfaccionFecha = P003W2_A32SatisfaccionFecha[0];
            A7SatisfaccionId = P003W2_A7SatisfaccionId[0];
            A33SatisfaccionResueltoNombre = P003W2_A33SatisfaccionResueltoNombre[0];
            A36SatisfaccionTecnicoProblemaNombre = P003W2_A36SatisfaccionTecnicoProblemaNombre[0];
            A35SatisfaccionTecnicoCompetenteNombre = P003W2_A35SatisfaccionTecnicoCompetenteNombre[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = P003W2_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            A38SatisfaccionTiempoNombre = P003W2_A38SatisfaccionTiempoNombre[0];
            A31SatisfaccionAtencionNombre = P003W2_A31SatisfaccionAtencionNombre[0];
            A15UsuarioId = P003W2_A15UsuarioId[0];
            A94UsuarioRequerimiento = P003W2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P003W2_A93UsuarioNombre[0];
            A90UsuarioFecha = P003W2_A90UsuarioFecha[0];
            A198TicketTecnicoResponsableId = P003W2_A198TicketTecnicoResponsableId[0];
            A199TicketTecnicoResponsableNombre = P003W2_A199TicketTecnicoResponsableNombre[0];
            AV27CellRow = (int)(AV27CellRow+1);
            AV30ColumnIndex = 0;
            if ( AV37GridColumnVisible_TicketId )
            {
               AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Number = A14TicketId;
               AV30ColumnIndex = (short)(AV30ColumnIndex+1);
            }
            if ( AV51GridColumnVisible_TicketResponsableId )
            {
               AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Number = A16TicketResponsableId;
               AV30ColumnIndex = (short)(AV30ColumnIndex+1);
            }
            if ( AV52GridColumnVisible_TicketTecnicoResponsableNombre )
            {
               AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = StringUtil.RTrim( A199TicketTecnicoResponsableNombre);
               AV30ColumnIndex = (short)(AV30ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_UsuarioNombre )
            {
               AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV30ColumnIndex = (short)(AV30ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_UsuarioFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A90UsuarioFecha ) ;
               AV26ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV30ColumnIndex = (short)(AV30ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_UsuarioRequerimiento )
            {
               AV26ExcelDocument.get_Cells(AV27CellRow, AV28FirstColumn+AV30ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV30ColumnIndex = (short)(AV30ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV26ExcelDocument.ErrCode != 0 )
         {
            AV54OutFile = "";
            AV32ErrorMessage = AV26ExcelDocument.ErrDescription;
            AV26ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "WWSatisfaccion",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV37GridColumnVisible_TicketId = true;
         AV51GridColumnVisible_TicketResponsableId = true;
         AV52GridColumnVisible_TicketTecnicoResponsableNombre = true;
         AV39GridColumnVisible_UsuarioNombre = true;
         AV40GridColumnVisible_UsuarioFecha = true;
         AV41GridColumnVisible_UsuarioRequerimiento = true;
         new k2bsavegridconfiguration(context ).execute(  "WWSatisfaccion",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV58GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV37GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketResponsableId") == 0 )
               {
                  AV51GridColumnVisible_TicketResponsableId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketTecnicoResponsableNombre") == 0 )
               {
                  AV52GridColumnVisible_TicketTecnicoResponsableNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV39GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  AV40GridColumnVisible_UsuarioFecha = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV41GridColumnVisible_UsuarioRequerimiento = false;
               }
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketId";
         AV11GridColumn.gxTpr_Columntitle = "RST No.";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketResponsableId";
         AV11GridColumn.gxTpr_Columntitle = "Id TR:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketTecnicoResponsableNombre";
         AV11GridColumn.gxTpr_Columntitle = "Técnico";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV11GridColumn.gxTpr_Columntitle = "Usuario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV11GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV11GridColumn.gxTpr_Columntitle = "Requerimiento";
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
         AV54OutFile = "";
         AV49Context = new SdtK2BContext(context);
         AV34File = new GxFile(context.GetPhysicalPath());
         AV26ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV19SatisfaccionResueltoNombre = "";
         lV20SatisfaccionTecnicoProblemaNombre = "";
         lV21SatisfaccionTecnicoCompetenteNombre = "";
         lV22SatisfaccionTecnicoProfesionalismoNombre = "";
         lV23SatisfaccionTiempoNombre = "";
         lV24SatisfaccionAtencionNombre = "";
         lV53UsuarioNombre = "";
         lV12K2BToolsGenericSearchField = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         A90UsuarioFecha = DateTime.MinValue;
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A93UsuarioNombre = "";
         A199TicketTecnicoResponsableNombre = "";
         A94UsuarioRequerimiento = "";
         P003W2_A198TicketTecnicoResponsableId = new short[1] ;
         P003W2_A15UsuarioId = new long[1] ;
         P003W2_A8SatisfaccionResueltoId = new short[1] ;
         P003W2_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         P003W2_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         P003W2_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         P003W2_A12SatisfaccionTiempoId = new short[1] ;
         P003W2_A13SatisfaccionAtencionId = new short[1] ;
         P003W2_A94UsuarioRequerimiento = new string[] {""} ;
         P003W2_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         P003W2_A16TicketResponsableId = new long[1] ;
         P003W2_A14TicketId = new long[1] ;
         P003W2_A93UsuarioNombre = new string[] {""} ;
         P003W2_A31SatisfaccionAtencionNombre = new string[] {""} ;
         P003W2_A38SatisfaccionTiempoNombre = new string[] {""} ;
         P003W2_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         P003W2_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         P003W2_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         P003W2_A33SatisfaccionResueltoNombre = new string[] {""} ;
         P003W2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P003W2_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         P003W2_A7SatisfaccionId = new long[1] ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV32ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               P003W2_A198TicketTecnicoResponsableId, P003W2_A15UsuarioId, P003W2_A8SatisfaccionResueltoId, P003W2_A9SatisfaccionTecnicoProblemaId, P003W2_A10SatisfaccionTecnicoCompetenteId, P003W2_A11SatisfaccionTecnicoProfesionalismoId, P003W2_A12SatisfaccionTiempoId, P003W2_A13SatisfaccionAtencionId, P003W2_A94UsuarioRequerimiento, P003W2_A199TicketTecnicoResponsableNombre,
               P003W2_A16TicketResponsableId, P003W2_A14TicketId, P003W2_A93UsuarioNombre, P003W2_A31SatisfaccionAtencionNombre, P003W2_A38SatisfaccionTiempoNombre, P003W2_A37SatisfaccionTecnicoProfesionalismoNombre, P003W2_A35SatisfaccionTecnicoCompetenteNombre, P003W2_A36SatisfaccionTecnicoProblemaNombre, P003W2_A33SatisfaccionResueltoNombre, P003W2_A90UsuarioFecha,
               P003W2_A32SatisfaccionFecha, P003W2_A7SatisfaccionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV25OrderedBy ;
      private short AV30ColumnIndex ;
      private short A198TicketTecnicoResponsableId ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private int AV27CellRow ;
      private int AV28FirstColumn ;
      private int AV58GXV1 ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private long A7SatisfaccionId ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private DateTime GXt_dtime1 ;
      private DateTime AV14SatisfaccionFecha_From ;
      private DateTime AV15SatisfaccionFecha_To ;
      private DateTime AV17UsuarioFecha_From ;
      private DateTime AV18UsuarioFecha_To ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private bool returnInSub ;
      private bool AV37GridColumnVisible_TicketId ;
      private bool AV51GridColumnVisible_TicketResponsableId ;
      private bool AV52GridColumnVisible_TicketTecnicoResponsableNombre ;
      private bool AV39GridColumnVisible_UsuarioNombre ;
      private bool AV40GridColumnVisible_UsuarioFecha ;
      private bool AV41GridColumnVisible_UsuarioRequerimiento ;
      private string AV19SatisfaccionResueltoNombre ;
      private string AV20SatisfaccionTecnicoProblemaNombre ;
      private string AV21SatisfaccionTecnicoCompetenteNombre ;
      private string AV22SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV23SatisfaccionTiempoNombre ;
      private string AV24SatisfaccionAtencionNombre ;
      private string AV53UsuarioNombre ;
      private string AV54OutFile ;
      private string lV19SatisfaccionResueltoNombre ;
      private string lV20SatisfaccionTecnicoProblemaNombre ;
      private string lV21SatisfaccionTecnicoCompetenteNombre ;
      private string lV22SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV23SatisfaccionTiempoNombre ;
      private string lV24SatisfaccionAtencionNombre ;
      private string lV53UsuarioNombre ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A93UsuarioNombre ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A94UsuarioRequerimiento ;
      private string AV32ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003W2_A198TicketTecnicoResponsableId ;
      private long[] P003W2_A15UsuarioId ;
      private short[] P003W2_A8SatisfaccionResueltoId ;
      private short[] P003W2_A9SatisfaccionTecnicoProblemaId ;
      private short[] P003W2_A10SatisfaccionTecnicoCompetenteId ;
      private short[] P003W2_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] P003W2_A12SatisfaccionTiempoId ;
      private short[] P003W2_A13SatisfaccionAtencionId ;
      private string[] P003W2_A94UsuarioRequerimiento ;
      private string[] P003W2_A199TicketTecnicoResponsableNombre ;
      private long[] P003W2_A16TicketResponsableId ;
      private long[] P003W2_A14TicketId ;
      private string[] P003W2_A93UsuarioNombre ;
      private string[] P003W2_A31SatisfaccionAtencionNombre ;
      private string[] P003W2_A38SatisfaccionTiempoNombre ;
      private string[] P003W2_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string[] P003W2_A35SatisfaccionTecnicoCompetenteNombre ;
      private string[] P003W2_A36SatisfaccionTecnicoProblemaNombre ;
      private string[] P003W2_A33SatisfaccionResueltoNombre ;
      private DateTime[] P003W2_A90UsuarioFecha ;
      private DateTime[] P003W2_A32SatisfaccionFecha ;
      private long[] P003W2_A7SatisfaccionId ;
      private string aP13_OutFile ;
      private ExcelDocumentI AV26ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV34File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV49Context ;
   }

   public class exportwwsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003W2( IGxContext context ,
                                             DateTime AV15SatisfaccionFecha_To ,
                                             DateTime AV14SatisfaccionFecha_From ,
                                             DateTime AV18UsuarioFecha_To ,
                                             DateTime AV17UsuarioFecha_From ,
                                             string AV19SatisfaccionResueltoNombre ,
                                             string AV20SatisfaccionTecnicoProblemaNombre ,
                                             string AV21SatisfaccionTecnicoCompetenteNombre ,
                                             string AV22SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV23SatisfaccionTiempoNombre ,
                                             string AV24SatisfaccionAtencionNombre ,
                                             string AV53UsuarioNombre ,
                                             string AV12K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A199TicketTecnicoResponsableNombre ,
                                             string A94UsuarioRequerimiento ,
                                             short AV25OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[16];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T10.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T8.[UsuarioId], T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T9.[UsuarioRequerimiento], T11.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketResponsableId], T1.[TicketId], T9.[UsuarioNombre], T7.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T6.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T2.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T9.[UsuarioFecha], T1.[SatisfaccionFecha], T1.[SatisfaccionId] FROM (((((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [Ticket] T8 ON T8.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T9 ON T9.[UsuarioId]";
         scmdbuf += " = T8.[UsuarioId]) INNER JOIN [TicketResponsable] T10 ON T10.[TicketId] = T1.[TicketId] AND T10.[TicketResponsableId] = T1.[TicketResponsableId]) INNER JOIN [Responsable] T11 ON T11.[ResponsableId] = T10.[TicketTecnicoResponsableId])";
         if ( ! (DateTime.MinValue==AV15SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV15SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV14SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV14SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV18UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] <= @AV18UsuarioFecha_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV17UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] >= @AV17UsuarioFecha_From)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV19SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV20SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV21SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV22SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV23SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV24SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioNombre] like @lV53UsuarioNombre)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or T11.[ResponsableNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or T9.[UsuarioNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or T9.[UsuarioRequerimiento] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV25OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV25OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV25OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV25OrderedBy == 3 )
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
               case 0 :
                     return conditional_P003W2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP003W2;
          prmP003W2 = new Object[] {
          new ParDef("@AV15SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV14SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV18UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV17UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV19SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV20SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV21SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV22SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV23SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV24SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV53UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(20);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(21);
                ((long[]) buf[21])[0] = rslt.getLong(22);
                return;
       }
    }

 }

}
