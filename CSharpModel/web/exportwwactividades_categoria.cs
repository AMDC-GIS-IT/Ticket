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
   public class exportwwactividades_categoria : GXProcedure
   {
      public exportwwactividades_categoria( )
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

      public exportwwactividades_categoria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_actividades_categoriaid_tipo_categoria ,
                           string aP1_fltnombre ,
                           string aP2_K2BToolsGenericSearchField ,
                           short aP3_OrderedBy ,
                           out string aP4_OutFile )
      {
         this.AV13actividades_categoriaid_tipo_categoria = aP0_actividades_categoriaid_tipo_categoria;
         this.AV54fltnombre = aP1_fltnombre;
         this.AV12K2BToolsGenericSearchField = aP2_K2BToolsGenericSearchField;
         this.AV20OrderedBy = aP3_OrderedBy;
         this.AV55OutFile = "" ;
         initialize();
         executePrivate();
         aP4_OutFile=this.AV55OutFile;
      }

      public string executeUdp( int aP0_actividades_categoriaid_tipo_categoria ,
                                string aP1_fltnombre ,
                                string aP2_K2BToolsGenericSearchField ,
                                short aP3_OrderedBy )
      {
         execute(aP0_actividades_categoriaid_tipo_categoria, aP1_fltnombre, aP2_K2BToolsGenericSearchField, aP3_OrderedBy, out aP4_OutFile);
         return AV55OutFile ;
      }

      public void executeSubmit( int aP0_actividades_categoriaid_tipo_categoria ,
                                 string aP1_fltnombre ,
                                 string aP2_K2BToolsGenericSearchField ,
                                 short aP3_OrderedBy ,
                                 out string aP4_OutFile )
      {
         exportwwactividades_categoria objexportwwactividades_categoria;
         objexportwwactividades_categoria = new exportwwactividades_categoria();
         objexportwwactividades_categoria.AV13actividades_categoriaid_tipo_categoria = aP0_actividades_categoriaid_tipo_categoria;
         objexportwwactividades_categoria.AV54fltnombre = aP1_fltnombre;
         objexportwwactividades_categoria.AV12K2BToolsGenericSearchField = aP2_K2BToolsGenericSearchField;
         objexportwwactividades_categoria.AV20OrderedBy = aP3_OrderedBy;
         objexportwwactividades_categoria.AV55OutFile = "" ;
         objexportwwactividades_categoria.context.SetSubmitInitialConfig(context);
         objexportwwactividades_categoria.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwactividades_categoria);
         aP4_OutFile=this.AV55OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwactividades_categoria)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV53Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV55OutFile = GxDirectory.TemporaryFilesPath + AV29File.Separator + "ExportWWactividades_categoria-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV21ExcelDocument.Open(AV55OutFile);
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
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Text = "actividades_categorias";
         AV22CellRow = (int)(AV22CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (0==AV13actividades_categoriaid_tipo_categoria) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "id_tipo_categoria";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Number = AV13actividades_categoriaid_tipo_categoria;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54fltnombre)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Actividad Categoría";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV54fltnombre);
            AV22CellRow = (int)(AV22CellRow+1);
         }
         AV22CellRow = (int)(AV22CellRow+3);
         AV25ColumnIndex = 0;
         if ( AV30GridColumnVisible_id_actividad_categoria )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Id. ";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_actividades_categoriaid_tipo_categoria )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "id_tipo_categoria";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_nombre_actividad )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Actividad Categoría";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_unidad_medida )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "unidad_medida";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_actividades_categoriaestado )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "estado";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV13actividades_categoriaid_tipo_categoria ,
                                              AV54fltnombre ,
                                              AV12K2BToolsGenericSearchField ,
                                              A122actividades_categoriaid_tipo_categoria ,
                                              A123nombre_actividad ,
                                              A102id_actividad_categoria ,
                                              A124unidad_medida ,
                                              A125actividades_categoriaestado ,
                                              AV20OrderedBy } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV54fltnombre = StringUtil.Concat( StringUtil.RTrim( AV54fltnombre), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P005I2 */
         pr_datastore1.execute(0, new Object[] {AV13actividades_categoriaid_tipo_categoria, lV54fltnombre, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A125actividades_categoriaestado = P005I2_A125actividades_categoriaestado[0];
            n125actividades_categoriaestado = P005I2_n125actividades_categoriaestado[0];
            A124unidad_medida = P005I2_A124unidad_medida[0];
            n124unidad_medida = P005I2_n124unidad_medida[0];
            A102id_actividad_categoria = P005I2_A102id_actividad_categoria[0];
            A123nombre_actividad = P005I2_A123nombre_actividad[0];
            n123nombre_actividad = P005I2_n123nombre_actividad[0];
            A122actividades_categoriaid_tipo_categoria = P005I2_A122actividades_categoriaid_tipo_categoria[0];
            n122actividades_categoriaid_tipo_categoria = P005I2_n122actividades_categoriaid_tipo_categoria[0];
            AV22CellRow = (int)(AV22CellRow+1);
            AV25ColumnIndex = 0;
            if ( AV30GridColumnVisible_id_actividad_categoria )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A102id_actividad_categoria;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_actividades_categoriaid_tipo_categoria )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A122actividades_categoriaid_tipo_categoria;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_nombre_actividad )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A123nombre_actividad);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_unidad_medida )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A124unidad_medida);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_actividades_categoriaestado )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A125actividades_categoriaestado;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
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
            AV55OutFile = "";
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
         new k2bloadgridconfiguration(context ).execute(  "WWactividades_categoria",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV30GridColumnVisible_id_actividad_categoria = true;
         AV31GridColumnVisible_actividades_categoriaid_tipo_categoria = true;
         AV32GridColumnVisible_nombre_actividad = true;
         AV33GridColumnVisible_unidad_medida = true;
         AV34GridColumnVisible_actividades_categoriaestado = true;
         new k2bsavegridconfiguration(context ).execute(  "WWactividades_categoria",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV59GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_actividad_categoria") == 0 )
               {
                  AV30GridColumnVisible_id_actividad_categoria = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "actividades_categoriaid_tipo_categoria") == 0 )
               {
                  AV31GridColumnVisible_actividades_categoriaid_tipo_categoria = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_actividad") == 0 )
               {
                  AV32GridColumnVisible_nombre_actividad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidad_medida") == 0 )
               {
                  AV33GridColumnVisible_unidad_medida = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "actividades_categoriaestado") == 0 )
               {
                  AV34GridColumnVisible_actividades_categoriaestado = false;
               }
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_actividad_categoria";
         AV11GridColumn.gxTpr_Columntitle = "Id. ";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "actividades_categoriaid_tipo_categoria";
         AV11GridColumn.gxTpr_Columntitle = "id_tipo_categoria";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_actividad";
         AV11GridColumn.gxTpr_Columntitle = "Actividad Categoría";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidad_medida";
         AV11GridColumn.gxTpr_Columntitle = "unidad_medida";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "actividades_categoriaestado";
         AV11GridColumn.gxTpr_Columntitle = "estado";
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
         AV55OutFile = "";
         AV53Context = new SdtK2BContext(context);
         AV29File = new GxFile(context.GetPhysicalPath());
         AV21ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV54fltnombre = "";
         lV12K2BToolsGenericSearchField = "";
         A123nombre_actividad = "";
         A124unidad_medida = "";
         P005I2_A125actividades_categoriaestado = new int[1] ;
         P005I2_n125actividades_categoriaestado = new bool[] {false} ;
         P005I2_A124unidad_medida = new string[] {""} ;
         P005I2_n124unidad_medida = new bool[] {false} ;
         P005I2_A102id_actividad_categoria = new int[1] ;
         P005I2_A123nombre_actividad = new string[] {""} ;
         P005I2_n123nombre_actividad = new bool[] {false} ;
         P005I2_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         P005I2_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         AV27ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.exportwwactividades_categoria__datastore1(),
            new Object[][] {
                new Object[] {
               P005I2_A125actividades_categoriaestado, P005I2_n125actividades_categoriaestado, P005I2_A124unidad_medida, P005I2_n124unidad_medida, P005I2_A102id_actividad_categoria, P005I2_A123nombre_actividad, P005I2_n123nombre_actividad, P005I2_A122actividades_categoriaid_tipo_categoria, P005I2_n122actividades_categoriaid_tipo_categoria
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV20OrderedBy ;
      private short AV25ColumnIndex ;
      private int AV13actividades_categoriaid_tipo_categoria ;
      private int AV22CellRow ;
      private int AV23FirstColumn ;
      private int A122actividades_categoriaid_tipo_categoria ;
      private int A102id_actividad_categoria ;
      private int A125actividades_categoriaestado ;
      private int AV59GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV30GridColumnVisible_id_actividad_categoria ;
      private bool AV31GridColumnVisible_actividades_categoriaid_tipo_categoria ;
      private bool AV32GridColumnVisible_nombre_actividad ;
      private bool AV33GridColumnVisible_unidad_medida ;
      private bool AV34GridColumnVisible_actividades_categoriaestado ;
      private bool n125actividades_categoriaestado ;
      private bool n124unidad_medida ;
      private bool n123nombre_actividad ;
      private bool n122actividades_categoriaid_tipo_categoria ;
      private string AV54fltnombre ;
      private string AV55OutFile ;
      private string lV54fltnombre ;
      private string A123nombre_actividad ;
      private string A124unidad_medida ;
      private string AV27ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] P005I2_A125actividades_categoriaestado ;
      private bool[] P005I2_n125actividades_categoriaestado ;
      private string[] P005I2_A124unidad_medida ;
      private bool[] P005I2_n124unidad_medida ;
      private int[] P005I2_A102id_actividad_categoria ;
      private string[] P005I2_A123nombre_actividad ;
      private bool[] P005I2_n123nombre_actividad ;
      private int[] P005I2_A122actividades_categoriaid_tipo_categoria ;
      private bool[] P005I2_n122actividades_categoriaid_tipo_categoria ;
      private string aP4_OutFile ;
      private ExcelDocumentI AV21ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV29File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV53Context ;
   }

   public class exportwwactividades_categoria__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005I2( IGxContext context ,
                                             int AV13actividades_categoriaid_tipo_categoria ,
                                             string AV54fltnombre ,
                                             string AV12K2BToolsGenericSearchField ,
                                             int A122actividades_categoriaid_tipo_categoria ,
                                             string A123nombre_actividad ,
                                             int A102id_actividad_categoria ,
                                             string A124unidad_medida ,
                                             int A125actividades_categoriaestado ,
                                             short AV20OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [estado], [unidad_medida], [id_actividad_categoria], [nombre_actividad], [id_tipo_categoria] FROM dbo.[actividades_categoria]";
         if ( ! (0==AV13actividades_categoriaid_tipo_categoria) )
         {
            AddWhere(sWhereString, "([id_tipo_categoria] = @AV13actividades_categoriaid_tipo_categoria)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54fltnombre)) )
         {
            AddWhere(sWhereString, "([nombre_actividad] like @lV54fltnombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_actividad_categoria] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_tipo_categoria] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [nombre_actividad] like '%' + @lV12K2BToolsGenericSearchField + '%' or [unidad_medida] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV20OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [id_actividad_categoria]";
         }
         else if ( AV20OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [id_actividad_categoria] DESC";
         }
         else if ( AV20OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [id_tipo_categoria]";
         }
         else if ( AV20OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [id_tipo_categoria] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005I2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmP005I2;
          prmP005I2 = new Object[] {
          new ParDef("@AV13actividades_categoriaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@lV54fltnombre",GXType.NVarChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
