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
   public class exportestadoticketticketwc : GXProcedure
   {
      public exportestadoticketticketwc( )
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

      public exportestadoticketticketwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EstadoTicketTecnicoId ,
                           DateTime aP1_TicketFecha_From ,
                           DateTime aP2_TicketFecha_To ,
                           DateTime aP3_TicketHora_From ,
                           DateTime aP4_TicketHora_To ,
                           string aP5_UsuarioNombre ,
                           string aP6_K2BToolsGenericSearchField ,
                           short aP7_OrderedBy ,
                           out string aP8_OutFile )
      {
         this.AV8EstadoTicketTecnicoId = aP0_EstadoTicketTecnicoId;
         this.AV11TicketFecha_From = aP1_TicketFecha_From;
         this.AV12TicketFecha_To = aP2_TicketFecha_To;
         this.AV14TicketHora_From = aP3_TicketHora_From;
         this.AV15TicketHora_To = aP4_TicketHora_To;
         this.AV16UsuarioNombre = aP5_UsuarioNombre;
         this.AV9K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         this.AV17OrderedBy = aP7_OrderedBy;
         this.AV60OutFile = "" ;
         initialize();
         executePrivate();
         aP8_OutFile=this.AV60OutFile;
      }

      public string executeUdp( short aP0_EstadoTicketTecnicoId ,
                                DateTime aP1_TicketFecha_From ,
                                DateTime aP2_TicketFecha_To ,
                                DateTime aP3_TicketHora_From ,
                                DateTime aP4_TicketHora_To ,
                                string aP5_UsuarioNombre ,
                                string aP6_K2BToolsGenericSearchField ,
                                short aP7_OrderedBy )
      {
         execute(aP0_EstadoTicketTecnicoId, aP1_TicketFecha_From, aP2_TicketFecha_To, aP3_TicketHora_From, aP4_TicketHora_To, aP5_UsuarioNombre, aP6_K2BToolsGenericSearchField, aP7_OrderedBy, out aP8_OutFile);
         return AV60OutFile ;
      }

      public void executeSubmit( short aP0_EstadoTicketTecnicoId ,
                                 DateTime aP1_TicketFecha_From ,
                                 DateTime aP2_TicketFecha_To ,
                                 DateTime aP3_TicketHora_From ,
                                 DateTime aP4_TicketHora_To ,
                                 string aP5_UsuarioNombre ,
                                 string aP6_K2BToolsGenericSearchField ,
                                 short aP7_OrderedBy ,
                                 out string aP8_OutFile )
      {
         exportestadoticketticketwc objexportestadoticketticketwc;
         objexportestadoticketticketwc = new exportestadoticketticketwc();
         objexportestadoticketticketwc.AV8EstadoTicketTecnicoId = aP0_EstadoTicketTecnicoId;
         objexportestadoticketticketwc.AV11TicketFecha_From = aP1_TicketFecha_From;
         objexportestadoticketticketwc.AV12TicketFecha_To = aP2_TicketFecha_To;
         objexportestadoticketticketwc.AV14TicketHora_From = aP3_TicketHora_From;
         objexportestadoticketticketwc.AV15TicketHora_To = aP4_TicketHora_To;
         objexportestadoticketticketwc.AV16UsuarioNombre = aP5_UsuarioNombre;
         objexportestadoticketticketwc.AV9K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         objexportestadoticketticketwc.AV17OrderedBy = aP7_OrderedBy;
         objexportestadoticketticketwc.AV60OutFile = "" ;
         objexportestadoticketticketwc.context.SetSubmitInitialConfig(context);
         objexportestadoticketticketwc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportestadoticketticketwc);
         aP8_OutFile=this.AV60OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportestadoticketticketwc)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV58Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV60OutFile = GxDirectory.TemporaryFilesPath + AV26File.Separator + "ExportEstadoTicketTicketWC-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV18ExcelDocument.Open(AV60OutFile);
         AV18ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Clear();
         AV19CellRow = 1;
         AV20FirstColumn = 1;
         AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn, 1, 1).Size = 15;
         AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn, 1, 1).Bold = 1;
         AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn, 1, 1).Text = "Ticketes";
         AV19CellRow = (int)(AV19CellRow+4);
         /* Using cursor P003E2 */
         pr_default.execute(0, new Object[] {AV8EstadoTicketTecnicoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5EstadoTicketId = P003E2_A5EstadoTicketId[0];
            A24EstadoTicketNombre = P003E2_A24EstadoTicketNombre[0];
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Estado Ticket:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A24EstadoTicketNombre);
            AV19CellRow = (int)(AV19CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV19CellRow = (int)(AV19CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV11TicketFecha_From) || ! (DateTime.MinValue==AV12TicketFecha_To) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Fecha:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV11TicketFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV12TicketFecha_To, 2, "/");
            AV19CellRow = (int)(AV19CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14TicketHora_From) || ! (DateTime.MinValue==AV15TicketHora_To) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Hora:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV14TicketHora_From, 0, 5, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV15TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
            AV19CellRow = (int)(AV19CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioNombre)) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Usuario";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV16UsuarioNombre);
            AV19CellRow = (int)(AV19CellRow+1);
         }
         AV19CellRow = (int)(AV19CellRow+3);
         AV22ColumnIndex = 0;
         if ( AV31GridColumnVisible_TicketId )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "RST No.";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_TicketFecha )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Fecha:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_TicketHora )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Hora:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_UsuarioId )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Id Usuario";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV35GridColumnVisible_UsuarioNombre )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Usuario";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_UsuarioRequerimiento )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Requerimiento";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_EstadoTicketId )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Id";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_EstadoTicketNombre )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Estado Ticket";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_TicketLastId )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Last Id";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_TicketLaptop )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "aptop";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_TicketDesktop )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Desktop";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_TicketMonitor )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Monitor";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_TicketImpresora )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Impresora";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_TicketEscaner )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Escaner";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV45GridColumnVisible_TicketRouter )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Internet/Router/Access Point";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV46GridColumnVisible_TicketSistemaOperativo )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Operativo";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV47GridColumnVisible_TicketOffice )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Office";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV48GridColumnVisible_TicketAntivirus )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Antivirus";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV49GridColumnVisible_TicketAplicacion )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Aplicación";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV50GridColumnVisible_TicketDisenio )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Diseño";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV51GridColumnVisible_TicketIngenieria )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Ingeniería";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV52GridColumnVisible_TicketDiscoDuroExterno )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Duro ";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV53GridColumnVisible_TicketPerifericos )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Periféricos";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV54GridColumnVisible_TicketUps )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "UPS";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV55GridColumnVisible_TicketApoyoUsuario )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Usuario";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV56GridColumnVisible_TicketInstalarDataShow )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Data Show";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV57GridColumnVisible_TicketOtros )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Otros";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV12TicketFecha_To ,
                                              AV11TicketFecha_From ,
                                              AV15TicketHora_To ,
                                              AV14TicketHora_From ,
                                              AV16UsuarioNombre ,
                                              AV9K2BToolsGenericSearchField ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A93UsuarioNombre ,
                                              A14TicketId ,
                                              A15UsuarioId ,
                                              A94UsuarioRequerimiento ,
                                              A5EstadoTicketId ,
                                              A24EstadoTicketNombre ,
                                              A54TicketLastId ,
                                              AV17OrderedBy ,
                                              AV8EstadoTicketTecnicoId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV16UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV16UsuarioNombre), "%", "");
         /* Using cursor P003E3 */
         pr_default.execute(1, new Object[] {AV12TicketFecha_To, AV11TicketFecha_From, AV15TicketHora_To, AV14TicketHora_From, lV16UsuarioNombre});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A54TicketLastId = P003E3_A54TicketLastId[0];
            A94UsuarioRequerimiento = P003E3_A94UsuarioRequerimiento[0];
            A15UsuarioId = P003E3_A15UsuarioId[0];
            A14TicketId = P003E3_A14TicketId[0];
            A93UsuarioNombre = P003E3_A93UsuarioNombre[0];
            A48TicketHora = P003E3_A48TicketHora[0];
            A46TicketFecha = P003E3_A46TicketFecha[0];
            A53TicketLaptop = P003E3_A53TicketLaptop[0];
            n53TicketLaptop = P003E3_n53TicketLaptop[0];
            A42TicketDesktop = P003E3_A42TicketDesktop[0];
            n42TicketDesktop = P003E3_n42TicketDesktop[0];
            A55TicketMonitor = P003E3_A55TicketMonitor[0];
            n55TicketMonitor = P003E3_n55TicketMonitor[0];
            A50TicketImpresora = P003E3_A50TicketImpresora[0];
            n50TicketImpresora = P003E3_n50TicketImpresora[0];
            A45TicketEscaner = P003E3_A45TicketEscaner[0];
            n45TicketEscaner = P003E3_n45TicketEscaner[0];
            A59TicketRouter = P003E3_A59TicketRouter[0];
            n59TicketRouter = P003E3_n59TicketRouter[0];
            A60TicketSistemaOperativo = P003E3_A60TicketSistemaOperativo[0];
            n60TicketSistemaOperativo = P003E3_n60TicketSistemaOperativo[0];
            A56TicketOffice = P003E3_A56TicketOffice[0];
            n56TicketOffice = P003E3_n56TicketOffice[0];
            A39TicketAntivirus = P003E3_A39TicketAntivirus[0];
            n39TicketAntivirus = P003E3_n39TicketAntivirus[0];
            A40TicketAplicacion = P003E3_A40TicketAplicacion[0];
            n40TicketAplicacion = P003E3_n40TicketAplicacion[0];
            A44TicketDisenio = P003E3_A44TicketDisenio[0];
            n44TicketDisenio = P003E3_n44TicketDisenio[0];
            A51TicketIngenieria = P003E3_A51TicketIngenieria[0];
            n51TicketIngenieria = P003E3_n51TicketIngenieria[0];
            A43TicketDiscoDuroExterno = P003E3_A43TicketDiscoDuroExterno[0];
            n43TicketDiscoDuroExterno = P003E3_n43TicketDiscoDuroExterno[0];
            A58TicketPerifericos = P003E3_A58TicketPerifericos[0];
            n58TicketPerifericos = P003E3_n58TicketPerifericos[0];
            A87TicketUps = P003E3_A87TicketUps[0];
            n87TicketUps = P003E3_n87TicketUps[0];
            A41TicketApoyoUsuario = P003E3_A41TicketApoyoUsuario[0];
            n41TicketApoyoUsuario = P003E3_n41TicketApoyoUsuario[0];
            A52TicketInstalarDataShow = P003E3_A52TicketInstalarDataShow[0];
            n52TicketInstalarDataShow = P003E3_n52TicketInstalarDataShow[0];
            A57TicketOtros = P003E3_A57TicketOtros[0];
            n57TicketOtros = P003E3_n57TicketOtros[0];
            A94UsuarioRequerimiento = P003E3_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P003E3_A93UsuarioNombre[0];
            AV19CellRow = (int)(AV19CellRow+1);
            AV22ColumnIndex = 0;
            if ( AV31GridColumnVisible_TicketId )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Number = A14TicketId;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_TicketFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A46TicketFecha ) ;
               AV18ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_TicketHora )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = context.localUtil.Format( A48TicketHora, "99:99");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_UsuarioId )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Number = A15UsuarioId;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV35GridColumnVisible_UsuarioNombre )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_UsuarioRequerimiento )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_EstadoTicketId )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Number = A5EstadoTicketId;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_EstadoTicketNombre )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A24EstadoTicketNombre);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_TicketLastId )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Number = A54TicketLastId;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_TicketLaptop )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A53TicketLaptop ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_TicketDesktop )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A42TicketDesktop ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_TicketMonitor )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A55TicketMonitor ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_TicketImpresora )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A50TicketImpresora ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_TicketEscaner )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A45TicketEscaner ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV45GridColumnVisible_TicketRouter )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A59TicketRouter ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV46GridColumnVisible_TicketSistemaOperativo )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A60TicketSistemaOperativo ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV47GridColumnVisible_TicketOffice )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A56TicketOffice ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV48GridColumnVisible_TicketAntivirus )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A39TicketAntivirus ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV49GridColumnVisible_TicketAplicacion )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A40TicketAplicacion ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV50GridColumnVisible_TicketDisenio )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A44TicketDisenio ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV51GridColumnVisible_TicketIngenieria )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A51TicketIngenieria ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV52GridColumnVisible_TicketDiscoDuroExterno )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A43TicketDiscoDuroExterno ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV53GridColumnVisible_TicketPerifericos )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A58TicketPerifericos ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV54GridColumnVisible_TicketUps )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A87TicketUps ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV55GridColumnVisible_TicketApoyoUsuario )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A41TicketApoyoUsuario ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV56GridColumnVisible_TicketInstalarDataShow )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A52TicketInstalarDataShow ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV57GridColumnVisible_TicketOtros )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = (A57TicketOtros ? "Si" : "No");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV18ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV18ExcelDocument.ErrCode != 0 )
         {
            AV60OutFile = "";
            AV24ErrorMessage = AV18ExcelDocument.ErrDescription;
            AV18ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "EstadoTicketTicketWC",  "Grid", ref  AV27GridConfiguration) ;
         AV29GridColumns = AV27GridConfiguration.gxTpr_Gridcolumns;
         AV31GridColumnVisible_TicketId = true;
         AV32GridColumnVisible_TicketFecha = true;
         AV33GridColumnVisible_TicketHora = true;
         AV34GridColumnVisible_UsuarioId = true;
         AV35GridColumnVisible_UsuarioNombre = true;
         AV36GridColumnVisible_UsuarioRequerimiento = true;
         AV37GridColumnVisible_EstadoTicketId = true;
         AV38GridColumnVisible_EstadoTicketNombre = true;
         AV39GridColumnVisible_TicketLastId = true;
         AV40GridColumnVisible_TicketLaptop = true;
         AV41GridColumnVisible_TicketDesktop = true;
         AV42GridColumnVisible_TicketMonitor = true;
         AV43GridColumnVisible_TicketImpresora = true;
         AV44GridColumnVisible_TicketEscaner = true;
         AV45GridColumnVisible_TicketRouter = true;
         AV46GridColumnVisible_TicketSistemaOperativo = true;
         AV47GridColumnVisible_TicketOffice = true;
         AV48GridColumnVisible_TicketAntivirus = true;
         AV49GridColumnVisible_TicketAplicacion = true;
         AV50GridColumnVisible_TicketDisenio = true;
         AV51GridColumnVisible_TicketIngenieria = true;
         AV52GridColumnVisible_TicketDiscoDuroExterno = true;
         AV53GridColumnVisible_TicketPerifericos = true;
         AV54GridColumnVisible_TicketUps = true;
         AV55GridColumnVisible_TicketApoyoUsuario = true;
         AV56GridColumnVisible_TicketInstalarDataShow = true;
         AV57GridColumnVisible_TicketOtros = true;
         new k2bsavegridconfiguration(context ).execute(  "EstadoTicketTicketWC",  "Grid",  AV27GridConfiguration,  false) ;
         AV29GridColumns = AV27GridConfiguration.gxTpr_Gridcolumns;
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV29GridColumns.Count )
         {
            AV30GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV29GridColumns.Item(AV65GXV1));
            if ( ! AV30GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV31GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
               {
                  AV32GridColumnVisible_TicketFecha = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
               {
                  AV33GridColumnVisible_TicketHora = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV34GridColumnVisible_UsuarioId = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV35GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV36GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "EstadoTicketId") == 0 )
               {
                  AV37GridColumnVisible_EstadoTicketId = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "EstadoTicketNombre") == 0 )
               {
                  AV38GridColumnVisible_EstadoTicketNombre = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketLastId") == 0 )
               {
                  AV39GridColumnVisible_TicketLastId = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketLaptop") == 0 )
               {
                  AV40GridColumnVisible_TicketLaptop = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketDesktop") == 0 )
               {
                  AV41GridColumnVisible_TicketDesktop = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketMonitor") == 0 )
               {
                  AV42GridColumnVisible_TicketMonitor = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketImpresora") == 0 )
               {
                  AV43GridColumnVisible_TicketImpresora = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketEscaner") == 0 )
               {
                  AV44GridColumnVisible_TicketEscaner = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketRouter") == 0 )
               {
                  AV45GridColumnVisible_TicketRouter = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketSistemaOperativo") == 0 )
               {
                  AV46GridColumnVisible_TicketSistemaOperativo = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketOffice") == 0 )
               {
                  AV47GridColumnVisible_TicketOffice = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketAntivirus") == 0 )
               {
                  AV48GridColumnVisible_TicketAntivirus = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketAplicacion") == 0 )
               {
                  AV49GridColumnVisible_TicketAplicacion = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketDisenio") == 0 )
               {
                  AV50GridColumnVisible_TicketDisenio = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketIngenieria") == 0 )
               {
                  AV51GridColumnVisible_TicketIngenieria = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketDiscoDuroExterno") == 0 )
               {
                  AV52GridColumnVisible_TicketDiscoDuroExterno = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketPerifericos") == 0 )
               {
                  AV53GridColumnVisible_TicketPerifericos = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketUps") == 0 )
               {
                  AV54GridColumnVisible_TicketUps = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketApoyoUsuario") == 0 )
               {
                  AV55GridColumnVisible_TicketApoyoUsuario = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketInstalarDataShow") == 0 )
               {
                  AV56GridColumnVisible_TicketInstalarDataShow = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "TicketOtros") == 0 )
               {
                  AV57GridColumnVisible_TicketOtros = false;
               }
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV29GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketId";
         AV30GridColumn.gxTpr_Columntitle = "RST No.";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketFecha";
         AV30GridColumn.gxTpr_Columntitle = "Fecha:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketHora";
         AV30GridColumn.gxTpr_Columntitle = "Hora:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioId";
         AV30GridColumn.gxTpr_Columntitle = "Id Usuario";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV30GridColumn.gxTpr_Columntitle = "Usuario";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV30GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "EstadoTicketId";
         AV30GridColumn.gxTpr_Columntitle = "Id";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "EstadoTicketNombre";
         AV30GridColumn.gxTpr_Columntitle = "Estado Ticket";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketLastId";
         AV30GridColumn.gxTpr_Columntitle = "Last Id";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketLaptop";
         AV30GridColumn.gxTpr_Columntitle = "aptop";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketDesktop";
         AV30GridColumn.gxTpr_Columntitle = "Desktop";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketMonitor";
         AV30GridColumn.gxTpr_Columntitle = "Monitor";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketImpresora";
         AV30GridColumn.gxTpr_Columntitle = "Impresora";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketEscaner";
         AV30GridColumn.gxTpr_Columntitle = "Escaner";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketRouter";
         AV30GridColumn.gxTpr_Columntitle = "Internet/Router/Access Point";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketSistemaOperativo";
         AV30GridColumn.gxTpr_Columntitle = "Operativo";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketOffice";
         AV30GridColumn.gxTpr_Columntitle = "Office";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketAntivirus";
         AV30GridColumn.gxTpr_Columntitle = "Antivirus";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketAplicacion";
         AV30GridColumn.gxTpr_Columntitle = "Aplicación";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketDisenio";
         AV30GridColumn.gxTpr_Columntitle = "Diseño";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketIngenieria";
         AV30GridColumn.gxTpr_Columntitle = "Ingeniería";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketDiscoDuroExterno";
         AV30GridColumn.gxTpr_Columntitle = "Duro ";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketPerifericos";
         AV30GridColumn.gxTpr_Columntitle = "Periféricos";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketUps";
         AV30GridColumn.gxTpr_Columntitle = "UPS";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketApoyoUsuario";
         AV30GridColumn.gxTpr_Columntitle = "Usuario";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketInstalarDataShow";
         AV30GridColumn.gxTpr_Columntitle = "Data Show";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "TicketOtros";
         AV30GridColumn.gxTpr_Columntitle = "Otros";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV27GridConfiguration.gxTpr_Gridcolumns = AV29GridColumns;
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
         AV60OutFile = "";
         AV58Context = new SdtK2BContext(context);
         AV26File = new GxFile(context.GetPhysicalPath());
         AV18ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P003E2_A5EstadoTicketId = new short[1] ;
         P003E2_A24EstadoTicketNombre = new string[] {""} ;
         A24EstadoTicketNombre = "";
         lV16UsuarioNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         P003E3_A54TicketLastId = new long[1] ;
         P003E3_A94UsuarioRequerimiento = new string[] {""} ;
         P003E3_A15UsuarioId = new long[1] ;
         P003E3_A14TicketId = new long[1] ;
         P003E3_A93UsuarioNombre = new string[] {""} ;
         P003E3_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P003E3_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         P003E3_A53TicketLaptop = new bool[] {false} ;
         P003E3_n53TicketLaptop = new bool[] {false} ;
         P003E3_A42TicketDesktop = new bool[] {false} ;
         P003E3_n42TicketDesktop = new bool[] {false} ;
         P003E3_A55TicketMonitor = new bool[] {false} ;
         P003E3_n55TicketMonitor = new bool[] {false} ;
         P003E3_A50TicketImpresora = new bool[] {false} ;
         P003E3_n50TicketImpresora = new bool[] {false} ;
         P003E3_A45TicketEscaner = new bool[] {false} ;
         P003E3_n45TicketEscaner = new bool[] {false} ;
         P003E3_A59TicketRouter = new bool[] {false} ;
         P003E3_n59TicketRouter = new bool[] {false} ;
         P003E3_A60TicketSistemaOperativo = new bool[] {false} ;
         P003E3_n60TicketSistemaOperativo = new bool[] {false} ;
         P003E3_A56TicketOffice = new bool[] {false} ;
         P003E3_n56TicketOffice = new bool[] {false} ;
         P003E3_A39TicketAntivirus = new bool[] {false} ;
         P003E3_n39TicketAntivirus = new bool[] {false} ;
         P003E3_A40TicketAplicacion = new bool[] {false} ;
         P003E3_n40TicketAplicacion = new bool[] {false} ;
         P003E3_A44TicketDisenio = new bool[] {false} ;
         P003E3_n44TicketDisenio = new bool[] {false} ;
         P003E3_A51TicketIngenieria = new bool[] {false} ;
         P003E3_n51TicketIngenieria = new bool[] {false} ;
         P003E3_A43TicketDiscoDuroExterno = new bool[] {false} ;
         P003E3_n43TicketDiscoDuroExterno = new bool[] {false} ;
         P003E3_A58TicketPerifericos = new bool[] {false} ;
         P003E3_n58TicketPerifericos = new bool[] {false} ;
         P003E3_A87TicketUps = new bool[] {false} ;
         P003E3_n87TicketUps = new bool[] {false} ;
         P003E3_A41TicketApoyoUsuario = new bool[] {false} ;
         P003E3_n41TicketApoyoUsuario = new bool[] {false} ;
         P003E3_A52TicketInstalarDataShow = new bool[] {false} ;
         P003E3_n52TicketInstalarDataShow = new bool[] {false} ;
         P003E3_A57TicketOtros = new bool[] {false} ;
         P003E3_n57TicketOtros = new bool[] {false} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV24ErrorMessage = "";
         AV27GridConfiguration = new SdtK2BGridConfiguration(context);
         AV29GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportestadoticketticketwc__default(),
            new Object[][] {
                new Object[] {
               P003E2_A5EstadoTicketId, P003E2_A24EstadoTicketNombre
               }
               , new Object[] {
               P003E3_A54TicketLastId, P003E3_A94UsuarioRequerimiento, P003E3_A15UsuarioId, P003E3_A14TicketId, P003E3_A93UsuarioNombre, P003E3_A48TicketHora, P003E3_A46TicketFecha, P003E3_A53TicketLaptop, P003E3_n53TicketLaptop, P003E3_A42TicketDesktop,
               P003E3_n42TicketDesktop, P003E3_A55TicketMonitor, P003E3_n55TicketMonitor, P003E3_A50TicketImpresora, P003E3_n50TicketImpresora, P003E3_A45TicketEscaner, P003E3_n45TicketEscaner, P003E3_A59TicketRouter, P003E3_n59TicketRouter, P003E3_A60TicketSistemaOperativo,
               P003E3_n60TicketSistemaOperativo, P003E3_A56TicketOffice, P003E3_n56TicketOffice, P003E3_A39TicketAntivirus, P003E3_n39TicketAntivirus, P003E3_A40TicketAplicacion, P003E3_n40TicketAplicacion, P003E3_A44TicketDisenio, P003E3_n44TicketDisenio, P003E3_A51TicketIngenieria,
               P003E3_n51TicketIngenieria, P003E3_A43TicketDiscoDuroExterno, P003E3_n43TicketDiscoDuroExterno, P003E3_A58TicketPerifericos, P003E3_n58TicketPerifericos, P003E3_A87TicketUps, P003E3_n87TicketUps, P003E3_A41TicketApoyoUsuario, P003E3_n41TicketApoyoUsuario, P003E3_A52TicketInstalarDataShow,
               P003E3_n52TicketInstalarDataShow, P003E3_A57TicketOtros, P003E3_n57TicketOtros
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8EstadoTicketTecnicoId ;
      private short AV17OrderedBy ;
      private short A5EstadoTicketId ;
      private short AV22ColumnIndex ;
      private int AV19CellRow ;
      private int AV20FirstColumn ;
      private int AV65GXV1 ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long A54TicketLastId ;
      private string AV9K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV14TicketHora_From ;
      private DateTime AV15TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV11TicketFecha_From ;
      private DateTime AV12TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private bool returnInSub ;
      private bool AV31GridColumnVisible_TicketId ;
      private bool AV32GridColumnVisible_TicketFecha ;
      private bool AV33GridColumnVisible_TicketHora ;
      private bool AV34GridColumnVisible_UsuarioId ;
      private bool AV35GridColumnVisible_UsuarioNombre ;
      private bool AV36GridColumnVisible_UsuarioRequerimiento ;
      private bool AV37GridColumnVisible_EstadoTicketId ;
      private bool AV38GridColumnVisible_EstadoTicketNombre ;
      private bool AV39GridColumnVisible_TicketLastId ;
      private bool AV40GridColumnVisible_TicketLaptop ;
      private bool AV41GridColumnVisible_TicketDesktop ;
      private bool AV42GridColumnVisible_TicketMonitor ;
      private bool AV43GridColumnVisible_TicketImpresora ;
      private bool AV44GridColumnVisible_TicketEscaner ;
      private bool AV45GridColumnVisible_TicketRouter ;
      private bool AV46GridColumnVisible_TicketSistemaOperativo ;
      private bool AV47GridColumnVisible_TicketOffice ;
      private bool AV48GridColumnVisible_TicketAntivirus ;
      private bool AV49GridColumnVisible_TicketAplicacion ;
      private bool AV50GridColumnVisible_TicketDisenio ;
      private bool AV51GridColumnVisible_TicketIngenieria ;
      private bool AV52GridColumnVisible_TicketDiscoDuroExterno ;
      private bool AV53GridColumnVisible_TicketPerifericos ;
      private bool AV54GridColumnVisible_TicketUps ;
      private bool AV55GridColumnVisible_TicketApoyoUsuario ;
      private bool AV56GridColumnVisible_TicketInstalarDataShow ;
      private bool AV57GridColumnVisible_TicketOtros ;
      private bool A53TicketLaptop ;
      private bool n53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool n42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool n55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool n50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool n45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool n59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool n60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool n56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool n39TicketAntivirus ;
      private bool A40TicketAplicacion ;
      private bool n40TicketAplicacion ;
      private bool A44TicketDisenio ;
      private bool n44TicketDisenio ;
      private bool A51TicketIngenieria ;
      private bool n51TicketIngenieria ;
      private bool A43TicketDiscoDuroExterno ;
      private bool n43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool n58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool n87TicketUps ;
      private bool A41TicketApoyoUsuario ;
      private bool n41TicketApoyoUsuario ;
      private bool A52TicketInstalarDataShow ;
      private bool n52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private bool n57TicketOtros ;
      private string AV16UsuarioNombre ;
      private string AV60OutFile ;
      private string A24EstadoTicketNombre ;
      private string lV16UsuarioNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string AV24ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003E2_A5EstadoTicketId ;
      private string[] P003E2_A24EstadoTicketNombre ;
      private long[] P003E3_A54TicketLastId ;
      private string[] P003E3_A94UsuarioRequerimiento ;
      private long[] P003E3_A15UsuarioId ;
      private long[] P003E3_A14TicketId ;
      private string[] P003E3_A93UsuarioNombre ;
      private DateTime[] P003E3_A48TicketHora ;
      private DateTime[] P003E3_A46TicketFecha ;
      private bool[] P003E3_A53TicketLaptop ;
      private bool[] P003E3_n53TicketLaptop ;
      private bool[] P003E3_A42TicketDesktop ;
      private bool[] P003E3_n42TicketDesktop ;
      private bool[] P003E3_A55TicketMonitor ;
      private bool[] P003E3_n55TicketMonitor ;
      private bool[] P003E3_A50TicketImpresora ;
      private bool[] P003E3_n50TicketImpresora ;
      private bool[] P003E3_A45TicketEscaner ;
      private bool[] P003E3_n45TicketEscaner ;
      private bool[] P003E3_A59TicketRouter ;
      private bool[] P003E3_n59TicketRouter ;
      private bool[] P003E3_A60TicketSistemaOperativo ;
      private bool[] P003E3_n60TicketSistemaOperativo ;
      private bool[] P003E3_A56TicketOffice ;
      private bool[] P003E3_n56TicketOffice ;
      private bool[] P003E3_A39TicketAntivirus ;
      private bool[] P003E3_n39TicketAntivirus ;
      private bool[] P003E3_A40TicketAplicacion ;
      private bool[] P003E3_n40TicketAplicacion ;
      private bool[] P003E3_A44TicketDisenio ;
      private bool[] P003E3_n44TicketDisenio ;
      private bool[] P003E3_A51TicketIngenieria ;
      private bool[] P003E3_n51TicketIngenieria ;
      private bool[] P003E3_A43TicketDiscoDuroExterno ;
      private bool[] P003E3_n43TicketDiscoDuroExterno ;
      private bool[] P003E3_A58TicketPerifericos ;
      private bool[] P003E3_n58TicketPerifericos ;
      private bool[] P003E3_A87TicketUps ;
      private bool[] P003E3_n87TicketUps ;
      private bool[] P003E3_A41TicketApoyoUsuario ;
      private bool[] P003E3_n41TicketApoyoUsuario ;
      private bool[] P003E3_A52TicketInstalarDataShow ;
      private bool[] P003E3_n52TicketInstalarDataShow ;
      private bool[] P003E3_A57TicketOtros ;
      private bool[] P003E3_n57TicketOtros ;
      private string aP8_OutFile ;
      private ExcelDocumentI AV18ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV29GridColumns ;
      private GxFile AV26File ;
      private SdtK2BGridConfiguration AV27GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV30GridColumn ;
      private SdtK2BContext AV58Context ;
   }

   public class exportestadoticketticketwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003E3( IGxContext context ,
                                             DateTime AV12TicketFecha_To ,
                                             DateTime AV11TicketFecha_From ,
                                             DateTime AV15TicketHora_To ,
                                             DateTime AV14TicketHora_From ,
                                             string AV16UsuarioNombre ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             long A14TicketId ,
                                             long A15UsuarioId ,
                                             string A94UsuarioRequerimiento ,
                                             short A5EstadoTicketId ,
                                             string A24EstadoTicketNombre ,
                                             long A54TicketLastId ,
                                             short AV17OrderedBy ,
                                             short AV8EstadoTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TicketLastId], T2.[UsuarioRequerimiento], T1.[UsuarioId], T1.[TicketId], T2.[UsuarioNombre], T1.[TicketHora], T1.[TicketFecha], T1.[TicketLaptop], T1.[TicketDesktop], T1.[TicketMonitor], T1.[TicketImpresora], T1.[TicketEscaner], T1.[TicketRouter], T1.[TicketSistemaOperativo], T1.[TicketOffice], T1.[TicketAntivirus], T1.[TicketAplicacion], T1.[TicketDisenio], T1.[TicketIngenieria], T1.[TicketDiscoDuroExterno], T1.[TicketPerifericos], T1.[TicketUps], T1.[TicketApoyoUsuario], T1.[TicketInstalarDataShow], T1.[TicketOtros] FROM ([Ticket] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId])";
         if ( ! (DateTime.MinValue==AV12TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV12TicketFecha_To)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV11TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV11TicketFecha_From)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV15TicketHora_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV14TicketHora_From)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T2.[UsuarioNombre] like @lV16UsuarioNombre)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV17OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV17OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha] DESC";
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
                     return conditional_P003E3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[17] );
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
          Object[] prmP003E2;
          prmP003E2 = new Object[] {
          new ParDef("@AV8EstadoTicketTecnicoId",GXType.Int16,4,0)
          };
          Object[] prmP003E3;
          prmP003E3 = new Object[] {
          new ParDef("@AV12TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV11TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV15TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV14TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV16UsuarioNombre",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003E2", "SELECT TOP 1 [EstadoTicketId], [EstadoTicketNombre] FROM [EstadoTicket] WHERE [EstadoTicketId] = @AV8EstadoTicketTecnicoId ORDER BY [EstadoTicketId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003E2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003E3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((bool[]) buf[11])[0] = rslt.getBool(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((bool[]) buf[13])[0] = rslt.getBool(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((bool[]) buf[15])[0] = rslt.getBool(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((bool[]) buf[17])[0] = rslt.getBool(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((bool[]) buf[19])[0] = rslt.getBool(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((bool[]) buf[21])[0] = rslt.getBool(15);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((bool[]) buf[23])[0] = rslt.getBool(16);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((bool[]) buf[25])[0] = rslt.getBool(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((bool[]) buf[27])[0] = rslt.getBool(18);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((bool[]) buf[29])[0] = rslt.getBool(19);
                ((bool[]) buf[30])[0] = rslt.wasNull(19);
                ((bool[]) buf[31])[0] = rslt.getBool(20);
                ((bool[]) buf[32])[0] = rslt.wasNull(20);
                ((bool[]) buf[33])[0] = rslt.getBool(21);
                ((bool[]) buf[34])[0] = rslt.wasNull(21);
                ((bool[]) buf[35])[0] = rslt.getBool(22);
                ((bool[]) buf[36])[0] = rslt.wasNull(22);
                ((bool[]) buf[37])[0] = rslt.getBool(23);
                ((bool[]) buf[38])[0] = rslt.wasNull(23);
                ((bool[]) buf[39])[0] = rslt.getBool(24);
                ((bool[]) buf[40])[0] = rslt.wasNull(24);
                ((bool[]) buf[41])[0] = rslt.getBool(25);
                ((bool[]) buf[42])[0] = rslt.wasNull(25);
                return;
       }
    }

 }

}
