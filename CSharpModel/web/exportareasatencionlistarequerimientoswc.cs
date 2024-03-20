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
   public class exportareasatencionlistarequerimientoswc : GXProcedure
   {
      public exportareasatencionlistarequerimientoswc( )
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

      public exportareasatencionlistarequerimientoswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_AreasAtencionId ,
                           string aP1_K2BToolsGenericSearchField ,
                           short aP2_OrderedBy ,
                           out string aP3_OutFile )
      {
         this.AV16AreasAtencionId = aP0_AreasAtencionId;
         this.AV21K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         this.AV15OrderedBy = aP2_OrderedBy;
         this.AV13OutFile = "" ;
         initialize();
         executePrivate();
         aP3_OutFile=this.AV13OutFile;
      }

      public string executeUdp( short aP0_AreasAtencionId ,
                                string aP1_K2BToolsGenericSearchField ,
                                short aP2_OrderedBy )
      {
         execute(aP0_AreasAtencionId, aP1_K2BToolsGenericSearchField, aP2_OrderedBy, out aP3_OutFile);
         return AV13OutFile ;
      }

      public void executeSubmit( short aP0_AreasAtencionId ,
                                 string aP1_K2BToolsGenericSearchField ,
                                 short aP2_OrderedBy ,
                                 out string aP3_OutFile )
      {
         exportareasatencionlistarequerimientoswc objexportareasatencionlistarequerimientoswc;
         objexportareasatencionlistarequerimientoswc = new exportareasatencionlistarequerimientoswc();
         objexportareasatencionlistarequerimientoswc.AV16AreasAtencionId = aP0_AreasAtencionId;
         objexportareasatencionlistarequerimientoswc.AV21K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         objexportareasatencionlistarequerimientoswc.AV15OrderedBy = aP2_OrderedBy;
         objexportareasatencionlistarequerimientoswc.AV13OutFile = "" ;
         objexportareasatencionlistarequerimientoswc.context.SetSubmitInitialConfig(context);
         objexportareasatencionlistarequerimientoswc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportareasatencionlistarequerimientoswc);
         aP3_OutFile=this.AV13OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportareasatencionlistarequerimientoswc)stateInfo).executePrivate();
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
         AV13OutFile = GxDirectory.TemporaryFilesPath + AV14File.Separator + "ExportAreasAtencionListaRequerimientosWC-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV8ExcelDocument.Open(AV13OutFile);
         AV8ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Clear();
         AV9CellRow = 1;
         AV10FirstColumn = 1;
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Size = 15;
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Text = "Lista requerimientoses";
         AV9CellRow = (int)(AV9CellRow+4);
         /* Using cursor P007K2 */
         pr_default.execute(0, new Object[] {AV16AreasAtencionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A366AreasAtencionId = P007K2_A366AreasAtencionId[0];
            A367AreasAtencionDescripcion = P007K2_A367AreasAtencionDescripcion[0];
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A367AreasAtencionDescripcion);
            AV9CellRow = (int)(AV9CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21K2BToolsGenericSearchField)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = AV21K2BToolsGenericSearchField;
            AV9CellRow = (int)(AV9CellRow+1);
         }
         AV9CellRow = (int)(AV9CellRow+3);
         AV11ColumnIndex = 0;
         if ( AV22GridColumnVisible_ListaRequerimientosId )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV23GridColumnVisible_ListaRequerimientosDescripcion )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Descripción:";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_ListaRequerimientosUsuarioSistema )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Registro:";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV21K2BToolsGenericSearchField ,
                                              A369ListaRequerimientosId ,
                                              A370ListaRequerimientosDescripcion ,
                                              A371ListaRequerimientosUsuarioSistema ,
                                              AV15OrderedBy ,
                                              AV16AreasAtencionId ,
                                              A366AreasAtencionId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV21K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV21K2BToolsGenericSearchField), 200, "%");
         lV21K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV21K2BToolsGenericSearchField), 200, "%");
         lV21K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV21K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P007K3 */
         pr_default.execute(1, new Object[] {AV16AreasAtencionId, lV21K2BToolsGenericSearchField, lV21K2BToolsGenericSearchField, lV21K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A371ListaRequerimientosUsuarioSistema = P007K3_A371ListaRequerimientosUsuarioSistema[0];
            A370ListaRequerimientosDescripcion = P007K3_A370ListaRequerimientosDescripcion[0];
            A369ListaRequerimientosId = P007K3_A369ListaRequerimientosId[0];
            A366AreasAtencionId = P007K3_A366AreasAtencionId[0];
            AV9CellRow = (int)(AV9CellRow+1);
            AV11ColumnIndex = 0;
            if ( AV22GridColumnVisible_ListaRequerimientosId )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Number = A369ListaRequerimientosId;
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV23GridColumnVisible_ListaRequerimientosDescripcion )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A370ListaRequerimientosDescripcion);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV24GridColumnVisible_ListaRequerimientosUsuarioSistema )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A371ListaRequerimientosUsuarioSistema);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV8ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV8ExcelDocument.ErrCode != 0 )
         {
            AV13OutFile = "";
            AV12ErrorMessage = AV8ExcelDocument.ErrDescription;
            AV8ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "AreasAtencionListaRequerimientosWC",  "Grid", ref  AV17GridConfiguration) ;
         AV19GridColumns = AV17GridConfiguration.gxTpr_Gridcolumns;
         AV22GridColumnVisible_ListaRequerimientosId = true;
         AV23GridColumnVisible_ListaRequerimientosDescripcion = true;
         AV24GridColumnVisible_ListaRequerimientosUsuarioSistema = true;
         new k2bsavegridconfiguration(context ).execute(  "AreasAtencionListaRequerimientosWC",  "Grid",  AV17GridConfiguration,  false) ;
         AV19GridColumns = AV17GridConfiguration.gxTpr_Gridcolumns;
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV19GridColumns.Count )
         {
            AV20GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV19GridColumns.Item(AV30GXV1));
            if ( ! AV20GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV20GridColumn.gxTpr_Attributename, "ListaRequerimientosId") == 0 )
               {
                  AV22GridColumnVisible_ListaRequerimientosId = false;
               }
               else if ( StringUtil.StrCmp(AV20GridColumn.gxTpr_Attributename, "ListaRequerimientosDescripcion") == 0 )
               {
                  AV23GridColumnVisible_ListaRequerimientosDescripcion = false;
               }
               else if ( StringUtil.StrCmp(AV20GridColumn.gxTpr_Attributename, "ListaRequerimientosUsuarioSistema") == 0 )
               {
                  AV24GridColumnVisible_ListaRequerimientosUsuarioSistema = false;
               }
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV19GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV20GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV20GridColumn.gxTpr_Attributename = "ListaRequerimientosId";
         AV20GridColumn.gxTpr_Columntitle = "";
         AV20GridColumn.gxTpr_Showattribute = true;
         AV19GridColumns.Add(AV20GridColumn, 0);
         AV20GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV20GridColumn.gxTpr_Attributename = "ListaRequerimientosDescripcion";
         AV20GridColumn.gxTpr_Columntitle = "Descripción:";
         AV20GridColumn.gxTpr_Showattribute = true;
         AV19GridColumns.Add(AV20GridColumn, 0);
         AV20GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV20GridColumn.gxTpr_Attributename = "ListaRequerimientosUsuarioSistema";
         AV20GridColumn.gxTpr_Columntitle = "Registro:";
         AV20GridColumn.gxTpr_Showattribute = true;
         AV19GridColumns.Add(AV20GridColumn, 0);
         AV17GridConfiguration.gxTpr_Gridcolumns = AV19GridColumns;
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
         AV13OutFile = "";
         AV25Context = new SdtK2BContext(context);
         AV14File = new GxFile(context.GetPhysicalPath());
         AV8ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P007K2_A366AreasAtencionId = new short[1] ;
         P007K2_A367AreasAtencionDescripcion = new string[] {""} ;
         A367AreasAtencionDescripcion = "";
         lV21K2BToolsGenericSearchField = "";
         A370ListaRequerimientosDescripcion = "";
         A371ListaRequerimientosUsuarioSistema = "";
         P007K3_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         P007K3_A370ListaRequerimientosDescripcion = new string[] {""} ;
         P007K3_A369ListaRequerimientosId = new short[1] ;
         P007K3_A366AreasAtencionId = new short[1] ;
         AV12ErrorMessage = "";
         AV17GridConfiguration = new SdtK2BGridConfiguration(context);
         AV19GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV20GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportareasatencionlistarequerimientoswc__default(),
            new Object[][] {
                new Object[] {
               P007K2_A366AreasAtencionId, P007K2_A367AreasAtencionDescripcion
               }
               , new Object[] {
               P007K3_A371ListaRequerimientosUsuarioSistema, P007K3_A370ListaRequerimientosDescripcion, P007K3_A369ListaRequerimientosId, P007K3_A366AreasAtencionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16AreasAtencionId ;
      private short AV15OrderedBy ;
      private short A366AreasAtencionId ;
      private short AV11ColumnIndex ;
      private short A369ListaRequerimientosId ;
      private int AV9CellRow ;
      private int AV10FirstColumn ;
      private int AV30GXV1 ;
      private string AV21K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV21K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV22GridColumnVisible_ListaRequerimientosId ;
      private bool AV23GridColumnVisible_ListaRequerimientosDescripcion ;
      private bool AV24GridColumnVisible_ListaRequerimientosUsuarioSistema ;
      private string AV13OutFile ;
      private string A367AreasAtencionDescripcion ;
      private string A370ListaRequerimientosDescripcion ;
      private string A371ListaRequerimientosUsuarioSistema ;
      private string AV12ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P007K2_A366AreasAtencionId ;
      private string[] P007K2_A367AreasAtencionDescripcion ;
      private string[] P007K3_A371ListaRequerimientosUsuarioSistema ;
      private string[] P007K3_A370ListaRequerimientosDescripcion ;
      private short[] P007K3_A369ListaRequerimientosId ;
      private short[] P007K3_A366AreasAtencionId ;
      private string aP3_OutFile ;
      private ExcelDocumentI AV8ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV19GridColumns ;
      private GxFile AV14File ;
      private SdtK2BGridConfiguration AV17GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV20GridColumn ;
      private SdtK2BContext AV25Context ;
   }

   public class exportareasatencionlistarequerimientoswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007K3( IGxContext context ,
                                             string AV21K2BToolsGenericSearchField ,
                                             short A369ListaRequerimientosId ,
                                             string A370ListaRequerimientosDescripcion ,
                                             string A371ListaRequerimientosUsuarioSistema ,
                                             short AV15OrderedBy ,
                                             short AV16AreasAtencionId ,
                                             short A366AreasAtencionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ListaRequerimientosUsuarioSistema], [ListaRequerimientosDescripcion], [ListaRequerimientosId], [AreasAtencionId] FROM [ListaRequerimientos]";
         AddWhere(sWhereString, "([AreasAtencionId] = @AV16AreasAtencionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([ListaRequerimientosId] AS decimal(4,0))) like '%' + @lV21K2BToolsGenericSearchField + '%' or [ListaRequerimientosDescripcion] like '%' + @lV21K2BToolsGenericSearchField + '%' or [ListaRequerimientosUsuarioSistema] like '%' + @lV21K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [ListaRequerimientosId]";
         }
         else if ( AV15OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [ListaRequerimientosId] DESC";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [ListaRequerimientosDescripcion]";
         }
         else if ( AV15OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [ListaRequerimientosDescripcion] DESC";
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
               case 1 :
                     return conditional_P007K3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
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
          Object[] prmP007K2;
          prmP007K2 = new Object[] {
          new ParDef("@AV16AreasAtencionId",GXType.Int16,4,0)
          };
          Object[] prmP007K3;
          prmP007K3 = new Object[] {
          new ParDef("@AV16AreasAtencionId",GXType.Int16,4,0) ,
          new ParDef("@lV21K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV21K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV21K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007K2", "SELECT TOP 1 [AreasAtencionId], [AreasAtencionDescripcion] FROM [AreasAtencion] WHERE [AreasAtencionId] = @AV16AreasAtencionId ORDER BY [AreasAtencionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
