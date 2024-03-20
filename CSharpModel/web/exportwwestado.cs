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
   public class exportwwestado : GXProcedure
   {
      public exportwwestado( )
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

      public exportwwestado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EstadoNombre ,
                           string aP1_K2BToolsGenericSearchField ,
                           short aP2_OrderedBy ,
                           out string aP3_OutFile )
      {
         this.AV13EstadoNombre = aP0_EstadoNombre;
         this.AV12K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         this.AV14OrderedBy = aP2_OrderedBy;
         this.AV28OutFile = "" ;
         initialize();
         executePrivate();
         aP3_OutFile=this.AV28OutFile;
      }

      public string executeUdp( string aP0_EstadoNombre ,
                                string aP1_K2BToolsGenericSearchField ,
                                short aP2_OrderedBy )
      {
         execute(aP0_EstadoNombre, aP1_K2BToolsGenericSearchField, aP2_OrderedBy, out aP3_OutFile);
         return AV28OutFile ;
      }

      public void executeSubmit( string aP0_EstadoNombre ,
                                 string aP1_K2BToolsGenericSearchField ,
                                 short aP2_OrderedBy ,
                                 out string aP3_OutFile )
      {
         exportwwestado objexportwwestado;
         objexportwwestado = new exportwwestado();
         objexportwwestado.AV13EstadoNombre = aP0_EstadoNombre;
         objexportwwestado.AV12K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         objexportwwestado.AV14OrderedBy = aP2_OrderedBy;
         objexportwwestado.AV28OutFile = "" ;
         objexportwwestado.context.SetSubmitInitialConfig(context);
         objexportwwestado.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwestado);
         aP3_OutFile=this.AV28OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwestado)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV27Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV28OutFile = GxDirectory.TemporaryFilesPath + AV23File.Separator + "ExportWWEstado-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV15ExcelDocument.Open(AV28OutFile);
         AV15ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV15ExcelDocument.Clear();
         AV16CellRow = 1;
         AV17FirstColumn = 1;
         AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn, 1, 1).Size = 15;
         AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn, 1, 1).Bold = 1;
         AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn, 1, 1).Text = "Estados";
         AV16CellRow = (int)(AV16CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+0, 1, 1).Bold = 1;
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV16CellRow = (int)(AV16CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13EstadoNombre)) )
         {
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+0, 1, 1).Bold = 1;
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+0, 1, 1).Text = "Estado";
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV13EstadoNombre);
            AV16CellRow = (int)(AV16CellRow+1);
         }
         AV16CellRow = (int)(AV16CellRow+3);
         AV19ColumnIndex = 0;
         if ( AV24GridColumnVisible_EstadoId )
         {
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Bold = 1;
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Text = "Id";
            AV19ColumnIndex = (short)(AV19ColumnIndex+1);
         }
         if ( AV25GridColumnVisible_EstadoNombre )
         {
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Bold = 1;
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Text = "Estado";
            AV19ColumnIndex = (short)(AV19ColumnIndex+1);
         }
         if ( AV26GridColumnVisible_EstadoActivo )
         {
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Bold = 1;
            AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Text = "Status";
            AV19ColumnIndex = (short)(AV19ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13EstadoNombre ,
                                              AV12K2BToolsGenericSearchField ,
                                              A20EstadoNombre ,
                                              A3EstadoId ,
                                              AV14OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13EstadoNombre = StringUtil.Concat( StringUtil.RTrim( AV13EstadoNombre), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P002W2 */
         pr_default.execute(0, new Object[] {lV13EstadoNombre, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A3EstadoId = P002W2_A3EstadoId[0];
            A20EstadoNombre = P002W2_A20EstadoNombre[0];
            A19EstadoActivo = P002W2_A19EstadoActivo[0];
            AV16CellRow = (int)(AV16CellRow+1);
            AV19ColumnIndex = 0;
            if ( AV24GridColumnVisible_EstadoId )
            {
               AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Number = A3EstadoId;
               AV19ColumnIndex = (short)(AV19ColumnIndex+1);
            }
            if ( AV25GridColumnVisible_EstadoNombre )
            {
               AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Text = StringUtil.RTrim( A20EstadoNombre);
               AV19ColumnIndex = (short)(AV19ColumnIndex+1);
            }
            if ( AV26GridColumnVisible_EstadoActivo )
            {
               AV15ExcelDocument.get_Cells(AV16CellRow, AV17FirstColumn+AV19ColumnIndex, 1, 1).Text = (A19EstadoActivo ? "Si" : "No");
               AV19ColumnIndex = (short)(AV19ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV15ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV15ExcelDocument.ErrCode != 0 )
         {
            AV28OutFile = "";
            AV21ErrorMessage = AV15ExcelDocument.ErrDescription;
            AV15ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "WWEstado",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV24GridColumnVisible_EstadoId = true;
         AV25GridColumnVisible_EstadoNombre = true;
         AV26GridColumnVisible_EstadoActivo = true;
         new k2bsavegridconfiguration(context ).execute(  "WWEstado",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV32GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "EstadoId") == 0 )
               {
                  AV24GridColumnVisible_EstadoId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "EstadoNombre") == 0 )
               {
                  AV25GridColumnVisible_EstadoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "EstadoActivo") == 0 )
               {
                  AV26GridColumnVisible_EstadoActivo = false;
               }
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "EstadoId";
         AV11GridColumn.gxTpr_Columntitle = "Id";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "EstadoNombre";
         AV11GridColumn.gxTpr_Columntitle = "Estado";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "EstadoActivo";
         AV11GridColumn.gxTpr_Columntitle = "Status";
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
         AV28OutFile = "";
         AV27Context = new SdtK2BContext(context);
         AV23File = new GxFile(context.GetPhysicalPath());
         AV15ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV13EstadoNombre = "";
         lV12K2BToolsGenericSearchField = "";
         A20EstadoNombre = "";
         P002W2_A3EstadoId = new short[1] ;
         P002W2_A20EstadoNombre = new string[] {""} ;
         P002W2_A19EstadoActivo = new bool[] {false} ;
         AV21ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwestado__default(),
            new Object[][] {
                new Object[] {
               P002W2_A3EstadoId, P002W2_A20EstadoNombre, P002W2_A19EstadoActivo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14OrderedBy ;
      private short AV19ColumnIndex ;
      private short A3EstadoId ;
      private int AV16CellRow ;
      private int AV17FirstColumn ;
      private int AV32GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV24GridColumnVisible_EstadoId ;
      private bool AV25GridColumnVisible_EstadoNombre ;
      private bool AV26GridColumnVisible_EstadoActivo ;
      private bool A19EstadoActivo ;
      private string AV13EstadoNombre ;
      private string AV28OutFile ;
      private string lV13EstadoNombre ;
      private string A20EstadoNombre ;
      private string AV21ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002W2_A3EstadoId ;
      private string[] P002W2_A20EstadoNombre ;
      private bool[] P002W2_A19EstadoActivo ;
      private string aP3_OutFile ;
      private ExcelDocumentI AV15ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV23File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV27Context ;
   }

   public class exportwwestado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002W2( IGxContext context ,
                                             string AV13EstadoNombre ,
                                             string AV12K2BToolsGenericSearchField ,
                                             string A20EstadoNombre ,
                                             short A3EstadoId ,
                                             short AV14OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [EstadoId], [EstadoNombre], [EstadoActivo] FROM [Estado]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13EstadoNombre)) )
         {
            AddWhere(sWhereString, "([EstadoNombre] like @lV13EstadoNombre)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([EstadoId] AS decimal(4,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [EstadoNombre] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [EstadoId]";
         }
         else if ( AV14OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [EstadoId] DESC";
         }
         else if ( AV14OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [EstadoNombre]";
         }
         else if ( AV14OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [EstadoNombre] DESC";
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
                     return conditional_P002W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] );
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
          Object[] prmP002W2;
          prmP002W2 = new Object[] {
          new ParDef("@lV13EstadoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
