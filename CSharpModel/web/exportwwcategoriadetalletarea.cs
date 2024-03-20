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
   public class exportwwcategoriadetalletarea : GXProcedure
   {
      public exportwwcategoriadetalletarea( )
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

      public exportwwcategoriadetalletarea( IGxContext context )
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
         this.AV29OutFile = "" ;
         initialize();
         executePrivate();
         aP2_OutFile=this.AV29OutFile;
      }

      public string executeUdp( string aP0_K2BToolsGenericSearchField ,
                                short aP1_OrderedBy )
      {
         execute(aP0_K2BToolsGenericSearchField, aP1_OrderedBy, out aP2_OutFile);
         return AV29OutFile ;
      }

      public void executeSubmit( string aP0_K2BToolsGenericSearchField ,
                                 short aP1_OrderedBy ,
                                 out string aP2_OutFile )
      {
         exportwwcategoriadetalletarea objexportwwcategoriadetalletarea;
         objexportwwcategoriadetalletarea = new exportwwcategoriadetalletarea();
         objexportwwcategoriadetalletarea.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         objexportwwcategoriadetalletarea.AV13OrderedBy = aP1_OrderedBy;
         objexportwwcategoriadetalletarea.AV29OutFile = "" ;
         objexportwwcategoriadetalletarea.context.SetSubmitInitialConfig(context);
         objexportwwcategoriadetalletarea.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwcategoriadetalletarea);
         aP2_OutFile=this.AV29OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwcategoriadetalletarea)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV28Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV29OutFile = GxDirectory.TemporaryFilesPath + AV22File.Separator + "ExportWWCategoriaDetalleTarea-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV14ExcelDocument.Open(AV29OutFile);
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
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = "Categoria detalle tareas";
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
         if ( AV23GridColumnVisible_CategoriaDetalleTareaId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Id.";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_CategoriaDetalleTareaNombre )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Tarea";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV25GridColumnVisible_id_actividad_categoria )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Id. ";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV26GridColumnVisible_nombre_actividad )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Actividad Categoría";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV27GridColumnVisible_CategoriaDetalleUsuarioRegistro )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Usuario Registro";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13OrderedBy ,
                                              AV12K2BToolsGenericSearchField ,
                                              A294CategoriaDetalleTareaId ,
                                              A295CategoriaDetalleTareaNombre ,
                                              A102id_actividad_categoria ,
                                              A123nombre_actividad ,
                                              A296CategoriaDetalleUsuarioRegistro } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00762 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A296CategoriaDetalleUsuarioRegistro = P00762_A296CategoriaDetalleUsuarioRegistro[0];
            A102id_actividad_categoria = P00762_A102id_actividad_categoria[0];
            A295CategoriaDetalleTareaNombre = P00762_A295CategoriaDetalleTareaNombre[0];
            A294CategoriaDetalleTareaId = P00762_A294CategoriaDetalleTareaId[0];
            /* Using cursor P00763 */
            pr_datastore1.execute(0, new Object[] {A102id_actividad_categoria});
            A123nombre_actividad = P00763_A123nombre_actividad[0];
            n123nombre_actividad = P00763_n123nombre_actividad[0];
            pr_datastore1.close(0);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) || ( StringUtil.Like( StringUtil.Str( (decimal)(A294CategoriaDetalleTareaId), 4, 0) , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A295CategoriaDetalleTareaNombre , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Str( (decimal)(A102id_actividad_categoria), 9, 0) , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 254 , "%"),  ' ' ) || StringUtil.Like( A123nombre_actividad , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A296CategoriaDetalleUsuarioRegistro , StringUtil.PadR( "%" + AV12K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) ) )
            {
               AV15CellRow = (int)(AV15CellRow+1);
               AV18ColumnIndex = 0;
               if ( AV23GridColumnVisible_CategoriaDetalleTareaId )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Number = A294CategoriaDetalleTareaId;
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV24GridColumnVisible_CategoriaDetalleTareaNombre )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A295CategoriaDetalleTareaNombre);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV25GridColumnVisible_id_actividad_categoria )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Number = A102id_actividad_categoria;
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV26GridColumnVisible_nombre_actividad )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A123nombre_actividad);
                  AV18ColumnIndex = (short)(AV18ColumnIndex+1);
               }
               if ( AV27GridColumnVisible_CategoriaDetalleUsuarioRegistro )
               {
                  AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A296CategoriaDetalleUsuarioRegistro);
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
            AV29OutFile = "";
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
         new k2bloadgridconfiguration(context ).execute(  "WWCategoriaDetalleTarea",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV23GridColumnVisible_CategoriaDetalleTareaId = true;
         AV24GridColumnVisible_CategoriaDetalleTareaNombre = true;
         AV25GridColumnVisible_id_actividad_categoria = true;
         AV26GridColumnVisible_nombre_actividad = true;
         AV27GridColumnVisible_CategoriaDetalleUsuarioRegistro = true;
         new k2bsavegridconfiguration(context ).execute(  "WWCategoriaDetalleTarea",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV33GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "CategoriaDetalleTareaId") == 0 )
               {
                  AV23GridColumnVisible_CategoriaDetalleTareaId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "CategoriaDetalleTareaNombre") == 0 )
               {
                  AV24GridColumnVisible_CategoriaDetalleTareaNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_actividad_categoria") == 0 )
               {
                  AV25GridColumnVisible_id_actividad_categoria = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_actividad") == 0 )
               {
                  AV26GridColumnVisible_nombre_actividad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "CategoriaDetalleUsuarioRegistro") == 0 )
               {
                  AV27GridColumnVisible_CategoriaDetalleUsuarioRegistro = false;
               }
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "CategoriaDetalleTareaId";
         AV11GridColumn.gxTpr_Columntitle = "Id.";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "CategoriaDetalleTareaNombre";
         AV11GridColumn.gxTpr_Columntitle = "Tarea";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_actividad_categoria";
         AV11GridColumn.gxTpr_Columntitle = "Id. ";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_actividad";
         AV11GridColumn.gxTpr_Columntitle = "Actividad Categoría";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "CategoriaDetalleUsuarioRegistro";
         AV11GridColumn.gxTpr_Columntitle = "Usuario Registro";
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
         AV29OutFile = "";
         AV28Context = new SdtK2BContext(context);
         AV22File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         lV12K2BToolsGenericSearchField = "";
         scmdbuf = "";
         A295CategoriaDetalleTareaNombre = "";
         A123nombre_actividad = "";
         A296CategoriaDetalleUsuarioRegistro = "";
         P00762_A296CategoriaDetalleUsuarioRegistro = new string[] {""} ;
         P00762_A102id_actividad_categoria = new int[1] ;
         P00762_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         P00762_A294CategoriaDetalleTareaId = new short[1] ;
         P00763_A123nombre_actividad = new string[] {""} ;
         P00763_n123nombre_actividad = new bool[] {false} ;
         AV20ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.exportwwcategoriadetalletarea__datastore1(),
            new Object[][] {
                new Object[] {
               P00763_A123nombre_actividad, P00763_n123nombre_actividad
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwcategoriadetalletarea__default(),
            new Object[][] {
                new Object[] {
               P00762_A296CategoriaDetalleUsuarioRegistro, P00762_A102id_actividad_categoria, P00762_A295CategoriaDetalleTareaNombre, P00762_A294CategoriaDetalleTareaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13OrderedBy ;
      private short AV18ColumnIndex ;
      private short A294CategoriaDetalleTareaId ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int A102id_actividad_categoria ;
      private int AV33GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string lV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV23GridColumnVisible_CategoriaDetalleTareaId ;
      private bool AV24GridColumnVisible_CategoriaDetalleTareaNombre ;
      private bool AV25GridColumnVisible_id_actividad_categoria ;
      private bool AV26GridColumnVisible_nombre_actividad ;
      private bool AV27GridColumnVisible_CategoriaDetalleUsuarioRegistro ;
      private bool n123nombre_actividad ;
      private string AV29OutFile ;
      private string A295CategoriaDetalleTareaNombre ;
      private string A123nombre_actividad ;
      private string A296CategoriaDetalleUsuarioRegistro ;
      private string AV20ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00762_A296CategoriaDetalleUsuarioRegistro ;
      private int[] P00762_A102id_actividad_categoria ;
      private string[] P00762_A295CategoriaDetalleTareaNombre ;
      private short[] P00762_A294CategoriaDetalleTareaId ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P00763_A123nombre_actividad ;
      private bool[] P00763_n123nombre_actividad ;
      private string aP2_OutFile ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV22File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV28Context ;
   }

   public class exportwwcategoriadetalletarea__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00763;
          prmP00763 = new Object[] {
          new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00763", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00763,1, GxCacheFrequency.OFF ,true,false )
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

 public class exportwwcategoriadetalletarea__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00762( IGxContext context ,
                                           short AV13OrderedBy ,
                                           string AV12K2BToolsGenericSearchField ,
                                           short A294CategoriaDetalleTareaId ,
                                           string A295CategoriaDetalleTareaNombre ,
                                           int A102id_actividad_categoria ,
                                           string A123nombre_actividad ,
                                           string A296CategoriaDetalleUsuarioRegistro )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object1 = new Object[2];
       scmdbuf = "SELECT [CategoriaDetalleUsuarioRegistro], [id_actividad_categoria], [CategoriaDetalleTareaNombre], [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea]";
       scmdbuf += sWhereString;
       if ( AV13OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaId]";
       }
       else if ( AV13OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaId] DESC";
       }
       else if ( AV13OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaNombre]";
       }
       else if ( AV13OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [CategoriaDetalleTareaNombre] DESC";
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
                   return conditional_P00762(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
        Object[] prmP00762;
        prmP00762 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00762", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00762,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
     }
  }

}

}
