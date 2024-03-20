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
   public class exportwwdirecciones : GXProcedure
   {
      public exportwwdirecciones( )
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

      public exportwwdirecciones( IGxContext context )
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
         this.AV26OutFile = "" ;
         initialize();
         executePrivate();
         aP2_OutFile=this.AV26OutFile;
      }

      public string executeUdp( string aP0_K2BToolsGenericSearchField ,
                                short aP1_OrderedBy )
      {
         execute(aP0_K2BToolsGenericSearchField, aP1_OrderedBy, out aP2_OutFile);
         return AV26OutFile ;
      }

      public void executeSubmit( string aP0_K2BToolsGenericSearchField ,
                                 short aP1_OrderedBy ,
                                 out string aP2_OutFile )
      {
         exportwwdirecciones objexportwwdirecciones;
         objexportwwdirecciones = new exportwwdirecciones();
         objexportwwdirecciones.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         objexportwwdirecciones.AV13OrderedBy = aP1_OrderedBy;
         objexportwwdirecciones.AV26OutFile = "" ;
         objexportwwdirecciones.context.SetSubmitInitialConfig(context);
         objexportwwdirecciones.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwdirecciones);
         aP2_OutFile=this.AV26OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwdirecciones)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV25Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26OutFile = GxDirectory.TemporaryFilesPath + AV22File.Separator + "ExportWWDirecciones-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV14ExcelDocument.Open(AV26OutFile);
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
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = "Direccioneses";
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
         if ( AV23GridColumnVisible_DireccionId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Direccion Id";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_DireccionDescripcion )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Direccion Descripcion";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         pr_datastore2.dynParam(0, new Object[]{ new Object[]{
                                              AV12K2BToolsGenericSearchField ,
                                              A258DireccionId ,
                                              A262DireccionDescripcion ,
                                              AV13OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P00602 */
         pr_datastore2.execute(0, new Object[] {lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_datastore2.getStatus(0) != 101) )
         {
            A262DireccionDescripcion = P00602_A262DireccionDescripcion[0];
            A258DireccionId = P00602_A258DireccionId[0];
            AV15CellRow = (int)(AV15CellRow+1);
            AV18ColumnIndex = 0;
            if ( AV23GridColumnVisible_DireccionId )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Number = A258DireccionId;
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV24GridColumnVisible_DireccionDescripcion )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A262DireccionDescripcion);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            pr_datastore2.readNext(0);
         }
         pr_datastore2.close(0);
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
            AV26OutFile = "";
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
         new k2bloadgridconfiguration(context ).execute(  "WWDirecciones",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV23GridColumnVisible_DireccionId = true;
         AV24GridColumnVisible_DireccionDescripcion = true;
         new k2bsavegridconfiguration(context ).execute(  "WWDirecciones",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV30GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "DireccionId") == 0 )
               {
                  AV23GridColumnVisible_DireccionId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "DireccionDescripcion") == 0 )
               {
                  AV24GridColumnVisible_DireccionDescripcion = false;
               }
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "DireccionId";
         AV11GridColumn.gxTpr_Columntitle = "Direccion Id";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "DireccionDescripcion";
         AV11GridColumn.gxTpr_Columntitle = "Direccion Descripcion";
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
         AV26OutFile = "";
         AV25Context = new SdtK2BContext(context);
         AV22File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV12K2BToolsGenericSearchField = "";
         A262DireccionDescripcion = "";
         P00602_A262DireccionDescripcion = new string[] {""} ;
         P00602_A258DireccionId = new short[1] ;
         AV20ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.exportwwdirecciones__datastore2(),
            new Object[][] {
                new Object[] {
               P00602_A262DireccionDescripcion, P00602_A258DireccionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13OrderedBy ;
      private short AV18ColumnIndex ;
      private short A258DireccionId ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int AV30GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV23GridColumnVisible_DireccionId ;
      private bool AV24GridColumnVisible_DireccionDescripcion ;
      private string AV26OutFile ;
      private string A262DireccionDescripcion ;
      private string AV20ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] P00602_A262DireccionDescripcion ;
      private short[] P00602_A258DireccionId ;
      private string aP2_OutFile ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV22File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV25Context ;
   }

   public class exportwwdirecciones__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00602( IGxContext context ,
                                             string AV12K2BToolsGenericSearchField ,
                                             short A258DireccionId ,
                                             string A262DireccionDescripcion ,
                                             short AV13OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [DireccionDescripcion], [DireccionId] FROM dbo.[Direcciones]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([DireccionId] AS decimal(4,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [DireccionDescripcion] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [DireccionId]";
         }
         else if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [DireccionId] DESC";
         }
         else if ( AV13OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [DireccionDescripcion]";
         }
         else if ( AV13OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [DireccionDescripcion] DESC";
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
                     return conditional_P00602(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] );
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
          Object[] prmP00602;
          prmP00602 = new Object[] {
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00602", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00602,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

}
