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
   public class exportwwtickettecnico : GXProcedure
   {
      public exportwwtickettecnico( )
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

      public exportwwtickettecnico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_TicketTecnicoFecha_From ,
                           DateTime aP1_TicketTecnicoFecha_To ,
                           DateTime aP2_TicketTecnicoHora_From ,
                           DateTime aP3_TicketTecnicoHora_To ,
                           string aP4_K2BToolsGenericSearchField ,
                           short aP5_OrderedBy ,
                           out string aP6_OutFile )
      {
         this.AV14TicketTecnicoFecha_From = aP0_TicketTecnicoFecha_From;
         this.AV15TicketTecnicoFecha_To = aP1_TicketTecnicoFecha_To;
         this.AV17TicketTecnicoHora_From = aP2_TicketTecnicoHora_From;
         this.AV18TicketTecnicoHora_To = aP3_TicketTecnicoHora_To;
         this.AV12K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         this.AV19OrderedBy = aP5_OrderedBy;
         this.AV65OutFile = "" ;
         initialize();
         executePrivate();
         aP6_OutFile=this.AV65OutFile;
      }

      public string executeUdp( DateTime aP0_TicketTecnicoFecha_From ,
                                DateTime aP1_TicketTecnicoFecha_To ,
                                DateTime aP2_TicketTecnicoHora_From ,
                                DateTime aP3_TicketTecnicoHora_To ,
                                string aP4_K2BToolsGenericSearchField ,
                                short aP5_OrderedBy )
      {
         execute(aP0_TicketTecnicoFecha_From, aP1_TicketTecnicoFecha_To, aP2_TicketTecnicoHora_From, aP3_TicketTecnicoHora_To, aP4_K2BToolsGenericSearchField, aP5_OrderedBy, out aP6_OutFile);
         return AV65OutFile ;
      }

      public void executeSubmit( DateTime aP0_TicketTecnicoFecha_From ,
                                 DateTime aP1_TicketTecnicoFecha_To ,
                                 DateTime aP2_TicketTecnicoHora_From ,
                                 DateTime aP3_TicketTecnicoHora_To ,
                                 string aP4_K2BToolsGenericSearchField ,
                                 short aP5_OrderedBy ,
                                 out string aP6_OutFile )
      {
         exportwwtickettecnico objexportwwtickettecnico;
         objexportwwtickettecnico = new exportwwtickettecnico();
         objexportwwtickettecnico.AV14TicketTecnicoFecha_From = aP0_TicketTecnicoFecha_From;
         objexportwwtickettecnico.AV15TicketTecnicoFecha_To = aP1_TicketTecnicoFecha_To;
         objexportwwtickettecnico.AV17TicketTecnicoHora_From = aP2_TicketTecnicoHora_From;
         objexportwwtickettecnico.AV18TicketTecnicoHora_To = aP3_TicketTecnicoHora_To;
         objexportwwtickettecnico.AV12K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         objexportwwtickettecnico.AV19OrderedBy = aP5_OrderedBy;
         objexportwwtickettecnico.AV65OutFile = "" ;
         objexportwwtickettecnico.context.SetSubmitInitialConfig(context);
         objexportwwtickettecnico.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwtickettecnico);
         aP6_OutFile=this.AV65OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwtickettecnico)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV64Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV65OutFile = GxDirectory.TemporaryFilesPath + AV28File.Separator + "ExportWWTicketTecnico-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV20ExcelDocument.Open(AV65OutFile);
         AV20ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV20ExcelDocument.Clear();
         AV21CellRow = 1;
         AV22FirstColumn = 1;
         AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn, 1, 1).Size = 15;
         AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn, 1, 1).Bold = 1;
         AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn, 1, 1).Text = "Ticket tecnicos";
         AV21CellRow = (int)(AV21CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+0, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV21CellRow = (int)(AV21CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14TicketTecnicoFecha_From) || ! (DateTime.MinValue==AV15TicketTecnicoFecha_To) )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+0, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+0, 1, 1).Text = "Fecha";
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV14TicketTecnicoFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV15TicketTecnicoFecha_To, 2, "/");
            AV21CellRow = (int)(AV21CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV17TicketTecnicoHora_From) || ! (DateTime.MinValue==AV18TicketTecnicoHora_To) )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+0, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+0, 1, 1).Text = "Hora";
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV17TicketTecnicoHora_From, 0, 5, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV18TicketTecnicoHora_To, 0, 5, 0, 3, "/", ":", " ");
            AV21CellRow = (int)(AV21CellRow+1);
         }
         AV21CellRow = (int)(AV21CellRow+3);
         AV24ColumnIndex = 0;
         if ( AV29GridColumnVisible_TicketTecnicoId )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Ticket Tecnico";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV30GridColumnVisible_TicketTecnicoFecha )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Fecha";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_TicketTecnicoHora )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Hora";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_TicketId )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "RST No.";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_TicketResponsableId )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Id TR:";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV35GridColumnVisible_ResponsableNombre )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Técnico";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_UsuarioId )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Id Usuario";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_UsuarioNombre )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Usuario";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_UsuarioRequerimiento )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Requerimiento";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_UsuarioDepartamento )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Departamento";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_TicketTecnicoInventarioSerie )
         {
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Bold = 1;
            AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = "Serie";
            AV24ColumnIndex = (short)(AV24ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV15TicketTecnicoFecha_To ,
                                              AV14TicketTecnicoFecha_From ,
                                              AV18TicketTecnicoHora_To ,
                                              AV17TicketTecnicoHora_From ,
                                              AV12K2BToolsGenericSearchField ,
                                              A69TicketTecnicoFecha ,
                                              A71TicketTecnicoHora ,
                                              A18TicketTecnicoId ,
                                              A14TicketId ,
                                              A16TicketResponsableId ,
                                              A30ResponsableNombre ,
                                              A15UsuarioId ,
                                              A93UsuarioNombre ,
                                              A94UsuarioRequerimiento ,
                                              A88UsuarioDepartamento ,
                                              A74TicketTecnicoInventarioSerie ,
                                              AV19OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT
                                              }
         });
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003U2 */
         pr_default.execute(0, new Object[] {AV15TicketTecnicoFecha_To, AV14TicketTecnicoFecha_From, AV18TicketTecnicoHora_To, AV17TicketTecnicoHora_From, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A6ResponsableId = P003U2_A6ResponsableId[0];
            A74TicketTecnicoInventarioSerie = P003U2_A74TicketTecnicoInventarioSerie[0];
            A88UsuarioDepartamento = P003U2_A88UsuarioDepartamento[0];
            A94UsuarioRequerimiento = P003U2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P003U2_A93UsuarioNombre[0];
            A15UsuarioId = P003U2_A15UsuarioId[0];
            A30ResponsableNombre = P003U2_A30ResponsableNombre[0];
            A16TicketResponsableId = P003U2_A16TicketResponsableId[0];
            A14TicketId = P003U2_A14TicketId[0];
            A18TicketTecnicoId = P003U2_A18TicketTecnicoId[0];
            A71TicketTecnicoHora = P003U2_A71TicketTecnicoHora[0];
            A69TicketTecnicoFecha = P003U2_A69TicketTecnicoFecha[0];
            A30ResponsableNombre = P003U2_A30ResponsableNombre[0];
            A15UsuarioId = P003U2_A15UsuarioId[0];
            A88UsuarioDepartamento = P003U2_A88UsuarioDepartamento[0];
            A94UsuarioRequerimiento = P003U2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P003U2_A93UsuarioNombre[0];
            AV21CellRow = (int)(AV21CellRow+1);
            AV24ColumnIndex = 0;
            if ( AV29GridColumnVisible_TicketTecnicoId )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Number = A18TicketTecnicoId;
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV30GridColumnVisible_TicketTecnicoFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A69TicketTecnicoFecha ) ;
               AV20ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_TicketTecnicoHora )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = context.localUtil.Format( A71TicketTecnicoHora, "99:99");
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_TicketId )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Number = A14TicketId;
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_TicketResponsableId )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Number = A16TicketResponsableId;
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV35GridColumnVisible_ResponsableNombre )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = StringUtil.RTrim( A30ResponsableNombre);
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_UsuarioId )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Number = A15UsuarioId;
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_UsuarioNombre )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_UsuarioRequerimiento )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_UsuarioDepartamento )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = StringUtil.RTrim( A88UsuarioDepartamento);
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_TicketTecnicoInventarioSerie )
            {
               AV20ExcelDocument.get_Cells(AV21CellRow, AV22FirstColumn+AV24ColumnIndex, 1, 1).Text = StringUtil.RTrim( A74TicketTecnicoInventarioSerie);
               AV24ColumnIndex = (short)(AV24ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV20ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV20ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV20ExcelDocument.ErrCode != 0 )
         {
            AV65OutFile = "";
            AV26ErrorMessage = AV20ExcelDocument.ErrDescription;
            AV20ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "WWTicketTecnico",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV29GridColumnVisible_TicketTecnicoId = true;
         AV30GridColumnVisible_TicketTecnicoFecha = true;
         AV31GridColumnVisible_TicketTecnicoHora = true;
         AV32GridColumnVisible_TicketId = true;
         AV33GridColumnVisible_TicketResponsableId = true;
         AV35GridColumnVisible_ResponsableNombre = true;
         AV36GridColumnVisible_UsuarioId = true;
         AV37GridColumnVisible_UsuarioNombre = true;
         AV38GridColumnVisible_UsuarioRequerimiento = true;
         AV39GridColumnVisible_UsuarioDepartamento = true;
         AV40GridColumnVisible_TicketTecnicoInventarioSerie = true;
         new k2bsavegridconfiguration(context ).execute(  "WWTicketTecnico",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV69GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketTecnicoId") == 0 )
               {
                  AV29GridColumnVisible_TicketTecnicoId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketTecnicoFecha") == 0 )
               {
                  AV30GridColumnVisible_TicketTecnicoFecha = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketTecnicoHora") == 0 )
               {
                  AV31GridColumnVisible_TicketTecnicoHora = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV32GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketResponsableId") == 0 )
               {
                  AV33GridColumnVisible_TicketResponsableId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableNombre") == 0 )
               {
                  AV35GridColumnVisible_ResponsableNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV36GridColumnVisible_UsuarioId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV37GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV38GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
               {
                  AV39GridColumnVisible_UsuarioDepartamento = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketTecnicoInventarioSerie") == 0 )
               {
                  AV40GridColumnVisible_TicketTecnicoInventarioSerie = false;
               }
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketTecnicoId";
         AV11GridColumn.gxTpr_Columntitle = "Ticket Tecnico";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketTecnicoFecha";
         AV11GridColumn.gxTpr_Columntitle = "Fecha";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketTecnicoHora";
         AV11GridColumn.gxTpr_Columntitle = "Hora";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
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
         AV11GridColumn.gxTpr_Attributename = "ResponsableNombre";
         AV11GridColumn.gxTpr_Columntitle = "Técnico";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioId";
         AV11GridColumn.gxTpr_Columntitle = "Id Usuario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV11GridColumn.gxTpr_Columntitle = "Usuario";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV11GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioDepartamento";
         AV11GridColumn.gxTpr_Columntitle = "Departamento";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketTecnicoInventarioSerie";
         AV11GridColumn.gxTpr_Columntitle = "Serie";
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
         AV65OutFile = "";
         AV64Context = new SdtK2BContext(context);
         AV28File = new GxFile(context.GetPhysicalPath());
         AV20ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV12K2BToolsGenericSearchField = "";
         A69TicketTecnicoFecha = DateTime.MinValue;
         A71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         A30ResponsableNombre = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A88UsuarioDepartamento = "";
         A74TicketTecnicoInventarioSerie = "";
         P003U2_A6ResponsableId = new short[1] ;
         P003U2_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         P003U2_A88UsuarioDepartamento = new string[] {""} ;
         P003U2_A94UsuarioRequerimiento = new string[] {""} ;
         P003U2_A93UsuarioNombre = new string[] {""} ;
         P003U2_A15UsuarioId = new long[1] ;
         P003U2_A30ResponsableNombre = new string[] {""} ;
         P003U2_A16TicketResponsableId = new long[1] ;
         P003U2_A14TicketId = new long[1] ;
         P003U2_A18TicketTecnicoId = new long[1] ;
         P003U2_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         P003U2_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV26ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwtickettecnico__default(),
            new Object[][] {
                new Object[] {
               P003U2_A6ResponsableId, P003U2_A74TicketTecnicoInventarioSerie, P003U2_A88UsuarioDepartamento, P003U2_A94UsuarioRequerimiento, P003U2_A93UsuarioNombre, P003U2_A15UsuarioId, P003U2_A30ResponsableNombre, P003U2_A16TicketResponsableId, P003U2_A14TicketId, P003U2_A18TicketTecnicoId,
               P003U2_A71TicketTecnicoHora, P003U2_A69TicketTecnicoFecha
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19OrderedBy ;
      private short AV24ColumnIndex ;
      private short A6ResponsableId ;
      private int AV21CellRow ;
      private int AV22FirstColumn ;
      private int AV69GXV1 ;
      private long A18TicketTecnicoId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A15UsuarioId ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private DateTime AV17TicketTecnicoHora_From ;
      private DateTime AV18TicketTecnicoHora_To ;
      private DateTime A71TicketTecnicoHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV14TicketTecnicoFecha_From ;
      private DateTime AV15TicketTecnicoFecha_To ;
      private DateTime A69TicketTecnicoFecha ;
      private bool returnInSub ;
      private bool AV29GridColumnVisible_TicketTecnicoId ;
      private bool AV30GridColumnVisible_TicketTecnicoFecha ;
      private bool AV31GridColumnVisible_TicketTecnicoHora ;
      private bool AV32GridColumnVisible_TicketId ;
      private bool AV33GridColumnVisible_TicketResponsableId ;
      private bool AV35GridColumnVisible_ResponsableNombre ;
      private bool AV36GridColumnVisible_UsuarioId ;
      private bool AV37GridColumnVisible_UsuarioNombre ;
      private bool AV38GridColumnVisible_UsuarioRequerimiento ;
      private bool AV39GridColumnVisible_UsuarioDepartamento ;
      private bool AV40GridColumnVisible_TicketTecnicoInventarioSerie ;
      private string AV65OutFile ;
      private string A30ResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A88UsuarioDepartamento ;
      private string A74TicketTecnicoInventarioSerie ;
      private string AV26ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003U2_A6ResponsableId ;
      private string[] P003U2_A74TicketTecnicoInventarioSerie ;
      private string[] P003U2_A88UsuarioDepartamento ;
      private string[] P003U2_A94UsuarioRequerimiento ;
      private string[] P003U2_A93UsuarioNombre ;
      private long[] P003U2_A15UsuarioId ;
      private string[] P003U2_A30ResponsableNombre ;
      private long[] P003U2_A16TicketResponsableId ;
      private long[] P003U2_A14TicketId ;
      private long[] P003U2_A18TicketTecnicoId ;
      private DateTime[] P003U2_A71TicketTecnicoHora ;
      private DateTime[] P003U2_A69TicketTecnicoFecha ;
      private string aP6_OutFile ;
      private ExcelDocumentI AV20ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV28File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV64Context ;
   }

   public class exportwwtickettecnico__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003U2( IGxContext context ,
                                             DateTime AV15TicketTecnicoFecha_To ,
                                             DateTime AV14TicketTecnicoFecha_From ,
                                             DateTime AV18TicketTecnicoHora_To ,
                                             DateTime AV17TicketTecnicoHora_From ,
                                             string AV12K2BToolsGenericSearchField ,
                                             DateTime A69TicketTecnicoFecha ,
                                             DateTime A71TicketTecnicoHora ,
                                             long A18TicketTecnicoId ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             string A30ResponsableNombre ,
                                             long A15UsuarioId ,
                                             string A93UsuarioNombre ,
                                             string A94UsuarioRequerimiento ,
                                             string A88UsuarioDepartamento ,
                                             string A74TicketTecnicoInventarioSerie ,
                                             short AV19OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ResponsableId], T1.[TicketTecnicoInventarioSerie], T4.[UsuarioDepartamento], T4.[UsuarioRequerimiento], T4.[UsuarioNombre], T3.[UsuarioId], T2.[ResponsableNombre], T1.[TicketResponsableId], T1.[TicketId], T1.[TicketTecnicoId], T1.[TicketTecnicoHora], T1.[TicketTecnicoFecha] FROM ((([TicketTecnico] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[ResponsableId]) INNER JOIN [Ticket] T3 ON T3.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T3.[UsuarioId])";
         if ( ! (DateTime.MinValue==AV15TicketTecnicoFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] <= @AV15TicketTecnicoFecha_To)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TicketTecnicoFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoFecha] >= @AV14TicketTecnicoFecha_From)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV18TicketTecnicoHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] <= @AV18TicketTecnicoHora_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV17TicketTecnicoHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketTecnicoHora] >= @AV17TicketTecnicoHora_From)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketTecnicoId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketResponsableId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or T2.[ResponsableNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T3.[UsuarioId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or T4.[UsuarioNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or T4.[UsuarioRequerimiento] like '%' + @lV12K2BToolsGenericSearchField + '%' or T4.[UsuarioDepartamento] like '%' + @lV12K2BToolsGenericSearchField + '%' or T1.[TicketTecnicoInventarioSerie] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV19OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoId]";
         }
         else if ( AV19OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoId] DESC";
         }
         else if ( AV19OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoFecha]";
         }
         else if ( AV19OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[TicketTecnicoFecha] DESC";
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
                     return conditional_P003U2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmP003U2;
          prmP003U2 = new Object[] {
          new ParDef("@AV15TicketTecnicoFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV14TicketTecnicoFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV18TicketTecnicoHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV17TicketTecnicoHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                return;
       }
    }

 }

}
