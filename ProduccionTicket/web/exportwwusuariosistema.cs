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
   public class exportwwusuariosistema : GXProcedure
   {
      public exportwwusuariosistema( )
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

      public exportwwusuariosistema( IGxContext context )
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
         exportwwusuariosistema objexportwwusuariosistema;
         objexportwwusuariosistema = new exportwwusuariosistema();
         objexportwwusuariosistema.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         objexportwwusuariosistema.AV13OrderedBy = aP1_OrderedBy;
         objexportwwusuariosistema.AV29OutFile = "" ;
         objexportwwusuariosistema.context.SetSubmitInitialConfig(context);
         objexportwwusuariosistema.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwusuariosistema);
         aP2_OutFile=this.AV29OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwusuariosistema)stateInfo).executePrivate();
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
         AV29OutFile = GxDirectory.TemporaryFilesPath + AV22File.Separator + "ExportWWUsuarioSistema-" + Guid.NewGuid( ).ToString() + ".xlsx";
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
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = "Usuario sistemas";
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
         if ( AV23GridColumnVisible_UsuarioSistemaId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Usuario Sistema:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV26GridColumnVisible_UsuarioSistemaIdentidad )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Identidad";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_UsuarioSistemaNombre )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Nombre";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV27GridColumnVisible_UsuarioSistemaGerencia )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Gerencia";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV28GridColumnVisible_UsuarioSistemaDepartamento )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Departamento";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12K2BToolsGenericSearchField ,
                                              A99UsuarioSistemaId ,
                                              A101UsuarioSistemaIdentidad ,
                                              A100UsuarioSistemaNombre ,
                                              A263UsuarioSistemaGerencia ,
                                              A257UsuarioSistemaDepartamento ,
                                              AV13OrderedBy } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P005F2 */
         pr_default.execute(0, new Object[] {lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A257UsuarioSistemaDepartamento = P005F2_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = P005F2_n257UsuarioSistemaDepartamento[0];
            A263UsuarioSistemaGerencia = P005F2_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = P005F2_n263UsuarioSistemaGerencia[0];
            A100UsuarioSistemaNombre = P005F2_A100UsuarioSistemaNombre[0];
            A101UsuarioSistemaIdentidad = P005F2_A101UsuarioSistemaIdentidad[0];
            A99UsuarioSistemaId = P005F2_A99UsuarioSistemaId[0];
            AV15CellRow = (int)(AV15CellRow+1);
            AV18ColumnIndex = 0;
            if ( AV23GridColumnVisible_UsuarioSistemaId )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A99UsuarioSistemaId);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV26GridColumnVisible_UsuarioSistemaIdentidad )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A101UsuarioSistemaIdentidad);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV24GridColumnVisible_UsuarioSistemaNombre )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A100UsuarioSistemaNombre);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV27GridColumnVisible_UsuarioSistemaGerencia )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A263UsuarioSistemaGerencia);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV28GridColumnVisible_UsuarioSistemaDepartamento )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A257UsuarioSistemaDepartamento);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         new k2bloadgridconfiguration(context ).execute(  "WWUsuarioSistema",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV23GridColumnVisible_UsuarioSistemaId = true;
         AV26GridColumnVisible_UsuarioSistemaIdentidad = true;
         AV24GridColumnVisible_UsuarioSistemaNombre = true;
         AV27GridColumnVisible_UsuarioSistemaGerencia = true;
         AV28GridColumnVisible_UsuarioSistemaDepartamento = true;
         new k2bsavegridconfiguration(context ).execute(  "WWUsuarioSistema",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV33GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
               {
                  AV23GridColumnVisible_UsuarioSistemaId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
               {
                  AV26GridColumnVisible_UsuarioSistemaIdentidad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
               {
                  AV24GridColumnVisible_UsuarioSistemaNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
               {
                  AV27GridColumnVisible_UsuarioSistemaGerencia = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
               {
                  AV28GridColumnVisible_UsuarioSistemaDepartamento = false;
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
         AV11GridColumn.gxTpr_Attributename = "UsuarioSistemaId";
         AV11GridColumn.gxTpr_Columntitle = "Usuario Sistema:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioSistemaIdentidad";
         AV11GridColumn.gxTpr_Columntitle = "Identidad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioSistemaNombre";
         AV11GridColumn.gxTpr_Columntitle = "Nombre";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioSistemaGerencia";
         AV11GridColumn.gxTpr_Columntitle = "Gerencia";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioSistemaDepartamento";
         AV11GridColumn.gxTpr_Columntitle = "Departamento";
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
         AV25Context = new SdtK2BContext(context);
         AV22File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV12K2BToolsGenericSearchField = "";
         A99UsuarioSistemaId = "";
         A101UsuarioSistemaIdentidad = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         P005F2_A257UsuarioSistemaDepartamento = new string[] {""} ;
         P005F2_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         P005F2_A263UsuarioSistemaGerencia = new string[] {""} ;
         P005F2_n263UsuarioSistemaGerencia = new bool[] {false} ;
         P005F2_A100UsuarioSistemaNombre = new string[] {""} ;
         P005F2_A101UsuarioSistemaIdentidad = new string[] {""} ;
         P005F2_A99UsuarioSistemaId = new string[] {""} ;
         AV20ErrorMessage = "";
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwusuariosistema__default(),
            new Object[][] {
                new Object[] {
               P005F2_A257UsuarioSistemaDepartamento, P005F2_n257UsuarioSistemaDepartamento, P005F2_A263UsuarioSistemaGerencia, P005F2_n263UsuarioSistemaGerencia, P005F2_A100UsuarioSistemaNombre, P005F2_A101UsuarioSistemaIdentidad, P005F2_A99UsuarioSistemaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13OrderedBy ;
      private short AV18ColumnIndex ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int AV33GXV1 ;
      private string AV12K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV23GridColumnVisible_UsuarioSistemaId ;
      private bool AV26GridColumnVisible_UsuarioSistemaIdentidad ;
      private bool AV24GridColumnVisible_UsuarioSistemaNombre ;
      private bool AV27GridColumnVisible_UsuarioSistemaGerencia ;
      private bool AV28GridColumnVisible_UsuarioSistemaDepartamento ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool n263UsuarioSistemaGerencia ;
      private string AV29OutFile ;
      private string A99UsuarioSistemaId ;
      private string A101UsuarioSistemaIdentidad ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string AV20ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005F2_A257UsuarioSistemaDepartamento ;
      private bool[] P005F2_n257UsuarioSistemaDepartamento ;
      private string[] P005F2_A263UsuarioSistemaGerencia ;
      private bool[] P005F2_n263UsuarioSistemaGerencia ;
      private string[] P005F2_A100UsuarioSistemaNombre ;
      private string[] P005F2_A101UsuarioSistemaIdentidad ;
      private string[] P005F2_A99UsuarioSistemaId ;
      private string aP2_OutFile ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV22File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV25Context ;
   }

   public class exportwwusuariosistema__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005F2( IGxContext context ,
                                             string AV12K2BToolsGenericSearchField ,
                                             string A99UsuarioSistemaId ,
                                             string A101UsuarioSistemaIdentidad ,
                                             string A100UsuarioSistemaNombre ,
                                             string A263UsuarioSistemaGerencia ,
                                             string A257UsuarioSistemaDepartamento ,
                                             short AV13OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaIdentidad], [UsuarioSistemaId] FROM [UsuarioSistema]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaId] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioSistemaIdentidad] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioSistemaNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioSistemaGerencia] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioSistemaDepartamento] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [UsuarioSistemaId]";
         }
         else if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
         }
         else if ( AV13OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [UsuarioSistemaNombre]";
         }
         else if ( AV13OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [UsuarioSistemaNombre] DESC";
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
                     return conditional_P005F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] );
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
          Object[] prmP005F2;
          prmP005F2 = new Object[] {
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
