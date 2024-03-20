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
   public class exportwwresponsable : GXProcedure
   {
      public exportwwresponsable( )
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

      public exportwwresponsable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_K2BToolsGenericSearchField ,
                           short aP1_OrderedBy ,
                           out string aP2_OutFile )
      {
         this.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         this.AV13OrderedBy = aP1_OrderedBy;
         this.AV33OutFile = "" ;
         initialize();
         executePrivate();
         aP2_OutFile=this.AV33OutFile;
      }

      public string executeUdp( string aP0_K2BToolsGenericSearchField ,
                                short aP1_OrderedBy )
      {
         execute(aP0_K2BToolsGenericSearchField, aP1_OrderedBy, out aP2_OutFile);
         return AV33OutFile ;
      }

      public void executeSubmit( string aP0_K2BToolsGenericSearchField ,
                                 short aP1_OrderedBy ,
                                 out string aP2_OutFile )
      {
         exportwwresponsable objexportwwresponsable;
         objexportwwresponsable = new exportwwresponsable();
         objexportwwresponsable.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         objexportwwresponsable.AV13OrderedBy = aP1_OrderedBy;
         objexportwwresponsable.AV33OutFile = "" ;
         objexportwwresponsable.context.SetSubmitInitialConfig(context);
         objexportwwresponsable.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwresponsable);
         aP2_OutFile=this.AV33OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwresponsable)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV30Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV33OutFile = GxDirectory.TemporaryFilesPath + AV22File.Separator + "ExportWWResponsable-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV14ExcelDocument.Open(AV33OutFile);
         AV14ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Clear();
         AV15CellRow = 1;
         AV16FirstColumn = 1;
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Size = 15;
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = "Responsables";
         AV15CellRow = (int)(AV15CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV15CellRow = (int)(AV15CellRow+1);
         }
         AV15CellRow = (int)(AV15CellRow+3);
         AV18ColumnIndex = 0;
         if ( AV23GridColumnVisible_ResponsableId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Id Técnico:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_ResponsableIdentidad )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Identidad Técnico:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV25GridColumnVisible_ResponsableNombre )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Técnico:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV26GridColumnVisible_ResponsableUsuario )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Usuario Sistema";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV27GridColumnVisible_ResponsableCargo )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Cargo:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV28GridColumnVisible_ResponsableEmail )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Email:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV29GridColumnVisible_ResponsableActivo )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Estado:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_id_unidad )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "id_unidad";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_nombre_unidad )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "nombre_unidad";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13OrderedBy ,
                                              AV12K2BToolsGenericSearchField ,
                                              A6ResponsableId ,
                                              A29ResponsableIdentidad ,
                                              A30ResponsableNombre ,
                                              A96ResponsableUsuario ,
                                              A27ResponsableCargo ,
                                              A28ResponsableEmail ,
                                              A103id_unidad ,
                                              A114nombre_unidad } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P003M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A103id_unidad = P003M2_A103id_unidad[0];
            A28ResponsableEmail = P003M2_A28ResponsableEmail[0];
            A27ResponsableCargo = P003M2_A27ResponsableCargo[0];
            A96ResponsableUsuario = P003M2_A96ResponsableUsuario[0];
            A30ResponsableNombre = P003M2_A30ResponsableNombre[0];
            A29ResponsableIdentidad = P003M2_A29ResponsableIdentidad[0];
            A6ResponsableId = P003M2_A6ResponsableId[0];
            A26ResponsableActivo = P003M2_A26ResponsableActivo[0];
            /* Using cursor P003M3 */
            pr_datastore1.execute(0, new Object[] {A103id_unidad});
            A114nombre_unidad = P003M3_A114nombre_unidad[0];
            n114nombre_unidad = P003M3_n114nombre_unidad[0];
            pr_datastore1.close(0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) || ( StringUtil.Like( StringUtil.Str( (decimal)(A6ResponsableId), 4, 0) , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A29ResponsableIdentidad , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A30ResponsableNombre , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A96ResponsableUsuario , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A27ResponsableCargo , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A28ResponsableEmail , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Str( (decimal)(A103id_unidad), 9, 0) , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A114nombre_unidad , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) ) )
            {
               AV15CellRow = (int)(AV15CellRow+1);
               AV18ColumnIndex = 0;
               if ( AV23GridColumnVisible_ResponsableId )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Number = A6ResponsableId;
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV24GridColumnVisible_ResponsableIdentidad )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A29ResponsableIdentidad);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV25GridColumnVisible_ResponsableNombre )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A30ResponsableNombre);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV26GridColumnVisible_ResponsableUsuario )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A96ResponsableUsuario);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV27GridColumnVisible_ResponsableCargo )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A27ResponsableCargo);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV28GridColumnVisible_ResponsableEmail )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A28ResponsableEmail);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV29GridColumnVisible_ResponsableActivo )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = (A26ResponsableActivo ? "Si" : "No");
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV31GridColumnVisible_id_unidad )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Number = A103id_unidad;
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV32GridColumnVisible_nombre_unidad )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A114nombre_unidad);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_datastore1.close(0);
         AV14ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV14ExcelDocument.ErrCode != 0 )
         {
            AV33OutFile = "";
            AV20ErrorMessage = AV14ExcelDocument.ErrDescription;
            AV14ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "WWResponsable",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV23GridColumnVisible_ResponsableId = true;
         AV24GridColumnVisible_ResponsableIdentidad = true;
         AV25GridColumnVisible_ResponsableNombre = true;
         AV26GridColumnVisible_ResponsableUsuario = true;
         AV27GridColumnVisible_ResponsableCargo = true;
         AV28GridColumnVisible_ResponsableEmail = true;
         AV29GridColumnVisible_ResponsableActivo = true;
         AV31GridColumnVisible_id_unidad = true;
         AV32GridColumnVisible_nombre_unidad = true;
         new k2bsavegridconfiguration(context ).execute(  "WWResponsable",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV37GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableId") == 0 )
               {
                  AV23GridColumnVisible_ResponsableId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableIdentidad") == 0 )
               {
                  AV24GridColumnVisible_ResponsableIdentidad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableNombre") == 0 )
               {
                  AV25GridColumnVisible_ResponsableNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableUsuario") == 0 )
               {
                  AV26GridColumnVisible_ResponsableUsuario = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableCargo") == 0 )
               {
                  AV27GridColumnVisible_ResponsableCargo = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableEmail") == 0 )
               {
                  AV28GridColumnVisible_ResponsableEmail = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "ResponsableActivo") == 0 )
               {
                  AV29GridColumnVisible_ResponsableActivo = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_unidad") == 0 )
               {
                  AV31GridColumnVisible_id_unidad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_unidad") == 0 )
               {
                  AV32GridColumnVisible_nombre_unidad = false;
               }
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableId";
         AV11GridColumn.gxTpr_Columntitle = "Id Técnico:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableIdentidad";
         AV11GridColumn.gxTpr_Columntitle = "Identidad Técnico:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableNombre";
         AV11GridColumn.gxTpr_Columntitle = "Técnico:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableUsuario";
         AV11GridColumn.gxTpr_Columntitle = "Usuario Sistema";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableCargo";
         AV11GridColumn.gxTpr_Columntitle = "Cargo:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableEmail";
         AV11GridColumn.gxTpr_Columntitle = "Email:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "ResponsableActivo";
         AV11GridColumn.gxTpr_Columntitle = "Estado:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_unidad";
         AV11GridColumn.gxTpr_Columntitle = "id_unidad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_unidad";
         AV11GridColumn.gxTpr_Columntitle = "nombre_unidad";
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
         AV33OutFile = "";
         AV30Context = new SdtK2BContext(context);
         AV22File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A29ResponsableIdentidad = "";
         A30ResponsableNombre = "";
         A96ResponsableUsuario = "";
         A27ResponsableCargo = "";
         A28ResponsableEmail = "";
         A114nombre_unidad = "";
         P003M2_A103id_unidad = new int[1] ;
         P003M2_A28ResponsableEmail = new string[] {""} ;
         P003M2_A27ResponsableCargo = new string[] {""} ;
         P003M2_A96ResponsableUsuario = new string[] {""} ;
         P003M2_A30ResponsableNombre = new string[] {""} ;
         P003M2_A29ResponsableIdentidad = new string[] {""} ;
         P003M2_A6ResponsableId = new short[1] ;
         P003M2_A26ResponsableActivo = new bool[] {false} ;
         P003M3_A114nombre_unidad = new string[] {""} ;
         P003M3_n114nombre_unidad = new bool[] {false} ;
         AV20ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwresponsable__default(),
            new Object[][] {
                new Object[] {
               P003M2_A103id_unidad, P003M2_A28ResponsableEmail, P003M2_A27ResponsableCargo, P003M2_A96ResponsableUsuario, P003M2_A30ResponsableNombre, P003M2_A29ResponsableIdentidad, P003M2_A6ResponsableId, P003M2_A26ResponsableActivo
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.exportwwresponsable__datastore1(),
            new Object[][] {
                new Object[] {
               P003M3_A114nombre_unidad, P003M3_n114nombre_unidad
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13OrderedBy ;
      private short AV18ColumnIndex ;
      private short A6ResponsableId ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int A103id_unidad ;
      private int AV37GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV23GridColumnVisible_ResponsableId ;
      private bool AV24GridColumnVisible_ResponsableIdentidad ;
      private bool AV25GridColumnVisible_ResponsableNombre ;
      private bool AV26GridColumnVisible_ResponsableUsuario ;
      private bool AV27GridColumnVisible_ResponsableCargo ;
      private bool AV28GridColumnVisible_ResponsableEmail ;
      private bool AV29GridColumnVisible_ResponsableActivo ;
      private bool AV31GridColumnVisible_id_unidad ;
      private bool AV32GridColumnVisible_nombre_unidad ;
      private bool A26ResponsableActivo ;
      private bool n114nombre_unidad ;
      private string AV33OutFile ;
      private string A29ResponsableIdentidad ;
      private string A30ResponsableNombre ;
      private string A96ResponsableUsuario ;
      private string A27ResponsableCargo ;
      private string A28ResponsableEmail ;
      private string A114nombre_unidad ;
      private string AV20ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003M2_A103id_unidad ;
      private string[] P003M2_A28ResponsableEmail ;
      private string[] P003M2_A27ResponsableCargo ;
      private string[] P003M2_A96ResponsableUsuario ;
      private string[] P003M2_A30ResponsableNombre ;
      private string[] P003M2_A29ResponsableIdentidad ;
      private short[] P003M2_A6ResponsableId ;
      private bool[] P003M2_A26ResponsableActivo ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P003M3_A114nombre_unidad ;
      private bool[] P003M3_n114nombre_unidad ;
      private string aP2_OutFile ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV22File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV30Context ;
   }

   public class exportwwresponsable__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003M2( IGxContext context ,
                                             short AV13OrderedBy ,
                                             string AV12K2BToolsGenericSearchField ,
                                             short A6ResponsableId ,
                                             string A29ResponsableIdentidad ,
                                             string A30ResponsableNombre ,
                                             string A96ResponsableUsuario ,
                                             string A27ResponsableCargo ,
                                             string A28ResponsableEmail ,
                                             int A103id_unidad ,
                                             string A114nombre_unidad )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT [id_unidad], [ResponsableEmail], [ResponsableCargo], [ResponsableUsuario], [ResponsableNombre], [ResponsableIdentidad], [ResponsableId], [ResponsableActivo] FROM [Responsable]";
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [ResponsableId]";
         }
         else if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [ResponsableId] DESC";
         }
         else if ( AV13OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [ResponsableIdentidad]";
         }
         else if ( AV13OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [ResponsableIdentidad] DESC";
         }
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P003M2(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmP003M2;
          prmP003M2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                return;
       }
    }

 }

 public class exportwwresponsable__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP003M3;
        prmP003M3 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("P003M3", "SELECT [nombre_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M3,1, GxCacheFrequency.OFF ,true,false )
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
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

}
