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
   public class exportwwticket : GXProcedure
   {
      public exportwwticket( )
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

      public exportwwticket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_TicketFecha_From ,
                           DateTime aP1_TicketFecha_To ,
                           DateTime aP2_TicketHora_From ,
                           DateTime aP3_TicketHora_To ,
                           string aP4_UsuarioNombre ,
                           string aP5_EstadoTicketTicketNombre ,
                           string aP6_K2BToolsGenericSearchField ,
                           short aP7_OrderedBy ,
                           out string aP8_OutFile )
      {
         this.AV14TicketFecha_From = aP0_TicketFecha_From;
         this.AV15TicketFecha_To = aP1_TicketFecha_To;
         this.AV17TicketHora_From = aP2_TicketHora_From;
         this.AV18TicketHora_To = aP3_TicketHora_To;
         this.AV19UsuarioNombre = aP4_UsuarioNombre;
         this.AV57EstadoTicketTicketNombre = aP5_EstadoTicketTicketNombre;
         this.AV12K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         this.AV20OrderedBy = aP7_OrderedBy;
         this.AV59OutFile = "" ;
         initialize();
         executePrivate();
         aP8_OutFile=this.AV59OutFile;
      }

      public string executeUdp( DateTime aP0_TicketFecha_From ,
                                DateTime aP1_TicketFecha_To ,
                                DateTime aP2_TicketHora_From ,
                                DateTime aP3_TicketHora_To ,
                                string aP4_UsuarioNombre ,
                                string aP5_EstadoTicketTicketNombre ,
                                string aP6_K2BToolsGenericSearchField ,
                                short aP7_OrderedBy )
      {
         execute(aP0_TicketFecha_From, aP1_TicketFecha_To, aP2_TicketHora_From, aP3_TicketHora_To, aP4_UsuarioNombre, aP5_EstadoTicketTicketNombre, aP6_K2BToolsGenericSearchField, aP7_OrderedBy, out aP8_OutFile);
         return AV59OutFile ;
      }

      public void executeSubmit( DateTime aP0_TicketFecha_From ,
                                 DateTime aP1_TicketFecha_To ,
                                 DateTime aP2_TicketHora_From ,
                                 DateTime aP3_TicketHora_To ,
                                 string aP4_UsuarioNombre ,
                                 string aP5_EstadoTicketTicketNombre ,
                                 string aP6_K2BToolsGenericSearchField ,
                                 short aP7_OrderedBy ,
                                 out string aP8_OutFile )
      {
         exportwwticket objexportwwticket;
         objexportwwticket = new exportwwticket();
         objexportwwticket.AV14TicketFecha_From = aP0_TicketFecha_From;
         objexportwwticket.AV15TicketFecha_To = aP1_TicketFecha_To;
         objexportwwticket.AV17TicketHora_From = aP2_TicketHora_From;
         objexportwwticket.AV18TicketHora_To = aP3_TicketHora_To;
         objexportwwticket.AV19UsuarioNombre = aP4_UsuarioNombre;
         objexportwwticket.AV57EstadoTicketTicketNombre = aP5_EstadoTicketTicketNombre;
         objexportwwticket.AV12K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         objexportwwticket.AV20OrderedBy = aP7_OrderedBy;
         objexportwwticket.AV59OutFile = "" ;
         objexportwwticket.context.SetSubmitInitialConfig(context);
         objexportwwticket.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwticket);
         aP8_OutFile=this.AV59OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwticket)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV56Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV59OutFile = GxDirectory.TemporaryFilesPath + AV29File.Separator + "ExportWWTicket-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV21ExcelDocument.Open(AV59OutFile);
         AV21ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV21ExcelDocument.Clear();
         AV22CellRow = 1;
         AV23FirstColumn = 1;
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Size = 15;
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Bold = 1;
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Text = "Ticketes";
         AV22CellRow = (int)(AV22CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14TicketFecha_From) || ! (DateTime.MinValue==AV15TicketFecha_To) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Fecha:";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV14TicketFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV15TicketFecha_To, 2, "/");
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV17TicketHora_From) || ! (DateTime.MinValue==AV18TicketHora_To) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Hora:";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV17TicketHora_From, 0, 5, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV18TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19UsuarioNombre)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Usuario";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV19UsuarioNombre);
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57EstadoTicketTicketNombre)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Ticket";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV57EstadoTicketTicketNombre);
            AV22CellRow = (int)(AV22CellRow+1);
         }
         AV22CellRow = (int)(AV22CellRow+3);
         AV25ColumnIndex = 0;
         if ( AV30GridColumnVisible_TicketId )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "RST No.";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_TicketFecha )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Fecha:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_TicketHora )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Hora:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_UsuarioNombre )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Usuario";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_UsuarioRequerimiento )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Requerimiento";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV58GridColumnVisible_EstadoTicketTicketNombre )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Ticket";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV15TicketFecha_To ,
                                              AV14TicketFecha_From ,
                                              AV18TicketHora_To ,
                                              AV17TicketHora_From ,
                                              AV19UsuarioNombre ,
                                              AV57EstadoTicketTicketNombre ,
                                              AV12K2BToolsGenericSearchField ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A93UsuarioNombre ,
                                              A188EstadoTicketTicketNombre ,
                                              A14TicketId ,
                                              A94UsuarioRequerimiento ,
                                              AV20OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV19UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV19UsuarioNombre), "%", "");
         lV57EstadoTicketTicketNombre = StringUtil.Concat( StringUtil.RTrim( AV57EstadoTicketTicketNombre), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003Q2 */
         pr_default.execute(0, new Object[] {AV15TicketFecha_To, AV14TicketFecha_From, AV18TicketHora_To, AV17TicketHora_From, lV19UsuarioNombre, lV57EstadoTicketTicketNombre, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15UsuarioId = P003Q2_A15UsuarioId[0];
            A187EstadoTicketTicketId = P003Q2_A187EstadoTicketTicketId[0];
            A94UsuarioRequerimiento = P003Q2_A94UsuarioRequerimiento[0];
            A14TicketId = P003Q2_A14TicketId[0];
            A188EstadoTicketTicketNombre = P003Q2_A188EstadoTicketTicketNombre[0];
            A93UsuarioNombre = P003Q2_A93UsuarioNombre[0];
            A48TicketHora = P003Q2_A48TicketHora[0];
            A46TicketFecha = P003Q2_A46TicketFecha[0];
            A94UsuarioRequerimiento = P003Q2_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P003Q2_A93UsuarioNombre[0];
            A188EstadoTicketTicketNombre = P003Q2_A188EstadoTicketTicketNombre[0];
            AV22CellRow = (int)(AV22CellRow+1);
            AV25ColumnIndex = 0;
            if ( AV30GridColumnVisible_TicketId )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A14TicketId;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_TicketFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A46TicketFecha ) ;
               AV21ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_TicketHora )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = context.localUtil.Format( A48TicketHora, "99:99");
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_UsuarioNombre )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_UsuarioRequerimiento )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV58GridColumnVisible_EstadoTicketTicketNombre )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A188EstadoTicketTicketNombre);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV21ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV21ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV21ExcelDocument.ErrCode != 0 )
         {
            AV59OutFile = "";
            AV27ErrorMessage = AV21ExcelDocument.ErrDescription;
            AV21ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "WWTicket",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV30GridColumnVisible_TicketId = true;
         AV31GridColumnVisible_TicketFecha = true;
         AV32GridColumnVisible_TicketHora = true;
         AV33GridColumnVisible_UsuarioNombre = true;
         AV34GridColumnVisible_UsuarioRequerimiento = true;
         AV58GridColumnVisible_EstadoTicketTicketNombre = true;
         new k2bsavegridconfiguration(context ).execute(  "WWTicket",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV63GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV30GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
               {
                  AV31GridColumnVisible_TicketFecha = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
               {
                  AV32GridColumnVisible_TicketHora = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV33GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV34GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "EstadoTicketTicketNombre") == 0 )
               {
                  AV58GridColumnVisible_EstadoTicketTicketNombre = false;
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
         AV11GridColumn.gxTpr_Attributename = "TicketId";
         AV11GridColumn.gxTpr_Columntitle = "RST No.";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketFecha";
         AV11GridColumn.gxTpr_Columntitle = "Fecha:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "TicketHora";
         AV11GridColumn.gxTpr_Columntitle = "Hora:";
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
         AV11GridColumn.gxTpr_Attributename = "EstadoTicketTicketNombre";
         AV11GridColumn.gxTpr_Columntitle = "Ticket";
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
         AV56Context = new SdtK2BContext(context);
         AV29File = new GxFile(context.GetPhysicalPath());
         AV21ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV19UsuarioNombre = "";
         lV57EstadoTicketTicketNombre = "";
         lV12K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A188EstadoTicketTicketNombre = "";
         A94UsuarioRequerimiento = "";
         P003Q2_A15UsuarioId = new long[1] ;
         P003Q2_A187EstadoTicketTicketId = new short[1] ;
         P003Q2_A94UsuarioRequerimiento = new string[] {""} ;
         P003Q2_A14TicketId = new long[1] ;
         P003Q2_A188EstadoTicketTicketNombre = new string[] {""} ;
         P003Q2_A93UsuarioNombre = new string[] {""} ;
         P003Q2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P003Q2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV27ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwticket__default(),
            new Object[][] {
                new Object[] {
               P003Q2_A15UsuarioId, P003Q2_A187EstadoTicketTicketId, P003Q2_A94UsuarioRequerimiento, P003Q2_A14TicketId, P003Q2_A188EstadoTicketTicketNombre, P003Q2_A93UsuarioNombre, P003Q2_A48TicketHora, P003Q2_A46TicketFecha
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV20OrderedBy ;
      private short AV25ColumnIndex ;
      private short A187EstadoTicketTicketId ;
      private int AV22CellRow ;
      private int AV23FirstColumn ;
      private int AV63GXV1 ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private DateTime AV17TicketHora_From ;
      private DateTime AV18TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV14TicketFecha_From ;
      private DateTime AV15TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private bool returnInSub ;
      private bool AV30GridColumnVisible_TicketId ;
      private bool AV31GridColumnVisible_TicketFecha ;
      private bool AV32GridColumnVisible_TicketHora ;
      private bool AV33GridColumnVisible_UsuarioNombre ;
      private bool AV34GridColumnVisible_UsuarioRequerimiento ;
      private bool AV58GridColumnVisible_EstadoTicketTicketNombre ;
      private string AV19UsuarioNombre ;
      private string AV57EstadoTicketTicketNombre ;
      private string AV59OutFile ;
      private string lV19UsuarioNombre ;
      private string lV57EstadoTicketTicketNombre ;
      private string A93UsuarioNombre ;
      private string A188EstadoTicketTicketNombre ;
      private string A94UsuarioRequerimiento ;
      private string AV27ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003Q2_A15UsuarioId ;
      private short[] P003Q2_A187EstadoTicketTicketId ;
      private string[] P003Q2_A94UsuarioRequerimiento ;
      private long[] P003Q2_A14TicketId ;
      private string[] P003Q2_A188EstadoTicketTicketNombre ;
      private string[] P003Q2_A93UsuarioNombre ;
      private DateTime[] P003Q2_A48TicketHora ;
      private DateTime[] P003Q2_A46TicketFecha ;
      private string aP8_OutFile ;
      private ExcelDocumentI AV21ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV29File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV56Context ;
   }

   public class exportwwticket__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Q2( IGxContext context ,
                                             DateTime AV15TicketFecha_To ,
                                             DateTime AV14TicketFecha_From ,
                                             DateTime AV18TicketHora_To ,
                                             DateTime AV17TicketHora_From ,
                                             string AV19UsuarioNombre ,
                                             string AV57EstadoTicketTicketNombre ,
                                             string AV12K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             long A14TicketId ,
                                             string A94UsuarioRequerimiento ,
                                             short AV20OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[UsuarioId], T1.[EstadoTicketTicketId] AS EstadoTicketTicketId, T2.[UsuarioRequerimiento], T1.[TicketId], T3.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T2.[UsuarioNombre], T1.[TicketHora], T1.[TicketFecha] FROM (([Ticket] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId]) INNER JOIN [EstadoTicket] T3 ON T3.[EstadoTicketId] = T1.[EstadoTicketTicketId])";
         if ( ! (DateTime.MinValue==AV15TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV15TicketFecha_To)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV14TicketFecha_From)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV18TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV18TicketHora_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV17TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV17TicketHora_From)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T2.[UsuarioNombre] like @lV19UsuarioNombre)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57EstadoTicketTicketNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoTicketNombre] like @lV57EstadoTicketTicketNombre)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or T2.[UsuarioNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or T2.[UsuarioRequerimiento] like '%' + @lV12K2BToolsGenericSearchField + '%' or T3.[EstadoTicketNombre] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV20OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV20OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV20OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV20OrderedBy == 3 )
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
               case 0 :
                     return conditional_P003Q2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP003Q2;
          prmP003Q2 = new Object[] {
          new ParDef("@AV15TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV14TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV18TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV17TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV19UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV57EstadoTicketTicketNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Q2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                return;
       }
    }

 }

}
