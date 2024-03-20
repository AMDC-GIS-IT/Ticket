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
   public class exportwwareasatencion : GXProcedure
   {
      public exportwwareasatencion( )
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

      public exportwwareasatencion( IGxContext context )
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
         this.AV20K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         this.AV15OrderedBy = aP1_OrderedBy;
         this.AV13OutFile = "" ;
         initialize();
         executePrivate();
         aP2_OutFile=this.AV13OutFile;
      }

      public string executeUdp( string aP0_K2BToolsGenericSearchField ,
                                short aP1_OrderedBy )
      {
         execute(aP0_K2BToolsGenericSearchField, aP1_OrderedBy, out aP2_OutFile);
         return AV13OutFile ;
      }

      public void executeSubmit( string aP0_K2BToolsGenericSearchField ,
                                 short aP1_OrderedBy ,
                                 out string aP2_OutFile )
      {
         exportwwareasatencion objexportwwareasatencion;
         objexportwwareasatencion = new exportwwareasatencion();
         objexportwwareasatencion.AV20K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         objexportwwareasatencion.AV15OrderedBy = aP1_OrderedBy;
         objexportwwareasatencion.AV13OutFile = "" ;
         objexportwwareasatencion.context.SetSubmitInitialConfig(context);
         objexportwwareasatencion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwareasatencion);
         aP2_OutFile=this.AV13OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwareasatencion)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV24Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13OutFile = GxDirectory.TemporaryFilesPath + AV14File.Separator + "ExportWWAreasAtencion-" + Guid.NewGuid( ).ToString() + ".xlsx";
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
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Text = "Áreas de atenciones";
         AV9CellRow = (int)(AV9CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20K2BToolsGenericSearchField)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = AV20K2BToolsGenericSearchField;
            AV9CellRow = (int)(AV9CellRow+1);
         }
         AV9CellRow = (int)(AV9CellRow+3);
         AV11ColumnIndex = 0;
         if ( AV21GridColumnVisible_AreasAtencionId )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV22GridColumnVisible_AreasAtencionDescripcion )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV23GridColumnVisible_AreasAtencionUsuarioSistema )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Registro: ";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV20K2BToolsGenericSearchField ,
                                              A366AreasAtencionId ,
                                              A367AreasAtencionDescripcion ,
                                              A368AreasAtencionUsuarioSistema ,
                                              AV15OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P007J2 */
         pr_default.execute(0, new Object[] {lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A368AreasAtencionUsuarioSistema = P007J2_A368AreasAtencionUsuarioSistema[0];
            A367AreasAtencionDescripcion = P007J2_A367AreasAtencionDescripcion[0];
            A366AreasAtencionId = P007J2_A366AreasAtencionId[0];
            AV9CellRow = (int)(AV9CellRow+1);
            AV11ColumnIndex = 0;
            if ( AV21GridColumnVisible_AreasAtencionId )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Number = A366AreasAtencionId;
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV22GridColumnVisible_AreasAtencionDescripcion )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A367AreasAtencionDescripcion);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV23GridColumnVisible_AreasAtencionUsuarioSistema )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A368AreasAtencionUsuarioSistema);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         new k2bloadgridconfiguration(context ).execute(  "WWAreasAtencion",  "Grid", ref  AV16GridConfiguration) ;
         AV18GridColumns = AV16GridConfiguration.gxTpr_Gridcolumns;
         AV21GridColumnVisible_AreasAtencionId = true;
         AV22GridColumnVisible_AreasAtencionDescripcion = true;
         AV23GridColumnVisible_AreasAtencionUsuarioSistema = true;
         new k2bsavegridconfiguration(context ).execute(  "WWAreasAtencion",  "Grid",  AV16GridConfiguration,  false) ;
         AV18GridColumns = AV16GridConfiguration.gxTpr_Gridcolumns;
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV18GridColumns.Count )
         {
            AV19GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV18GridColumns.Item(AV28GXV1));
            if ( ! AV19GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "AreasAtencionId") == 0 )
               {
                  AV21GridColumnVisible_AreasAtencionId = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "AreasAtencionDescripcion") == 0 )
               {
                  AV22GridColumnVisible_AreasAtencionDescripcion = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "AreasAtencionUsuarioSistema") == 0 )
               {
                  AV23GridColumnVisible_AreasAtencionUsuarioSistema = false;
               }
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV18GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "AreasAtencionId";
         AV19GridColumn.gxTpr_Columntitle = "";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "AreasAtencionDescripcion";
         AV19GridColumn.gxTpr_Columntitle = "";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "AreasAtencionUsuarioSistema";
         AV19GridColumn.gxTpr_Columntitle = "Registro: ";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV16GridConfiguration.gxTpr_Gridcolumns = AV18GridColumns;
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
         AV24Context = new SdtK2BContext(context);
         AV14File = new GxFile(context.GetPhysicalPath());
         AV8ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV20K2BToolsGenericSearchField = "";
         A367AreasAtencionDescripcion = "";
         A368AreasAtencionUsuarioSistema = "";
         P007J2_A368AreasAtencionUsuarioSistema = new string[] {""} ;
         P007J2_A367AreasAtencionDescripcion = new string[] {""} ;
         P007J2_A366AreasAtencionId = new short[1] ;
         AV12ErrorMessage = "";
         AV16GridConfiguration = new SdtK2BGridConfiguration(context);
         AV18GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwareasatencion__default(),
            new Object[][] {
                new Object[] {
               P007J2_A368AreasAtencionUsuarioSistema, P007J2_A367AreasAtencionDescripcion, P007J2_A366AreasAtencionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15OrderedBy ;
      private short AV11ColumnIndex ;
      private short A366AreasAtencionId ;
      private int AV9CellRow ;
      private int AV10FirstColumn ;
      private int AV28GXV1 ;
      private string AV20K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV20K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV21GridColumnVisible_AreasAtencionId ;
      private bool AV22GridColumnVisible_AreasAtencionDescripcion ;
      private bool AV23GridColumnVisible_AreasAtencionUsuarioSistema ;
      private string AV13OutFile ;
      private string A367AreasAtencionDescripcion ;
      private string A368AreasAtencionUsuarioSistema ;
      private string AV12ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007J2_A368AreasAtencionUsuarioSistema ;
      private string[] P007J2_A367AreasAtencionDescripcion ;
      private short[] P007J2_A366AreasAtencionId ;
      private string aP2_OutFile ;
      private ExcelDocumentI AV8ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV18GridColumns ;
      private GxFile AV14File ;
      private SdtK2BGridConfiguration AV16GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV19GridColumn ;
      private SdtK2BContext AV24Context ;
   }

   public class exportwwareasatencion__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007J2( IGxContext context ,
                                             string AV20K2BToolsGenericSearchField ,
                                             short A366AreasAtencionId ,
                                             string A367AreasAtencionDescripcion ,
                                             string A368AreasAtencionUsuarioSistema ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [AreasAtencionUsuarioSistema], [AreasAtencionDescripcion], [AreasAtencionId] FROM [AreasAtencion]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([AreasAtencionId] AS decimal(4,0))) like '%' + @lV20K2BToolsGenericSearchField + '%' or [AreasAtencionDescripcion] like '%' + @lV20K2BToolsGenericSearchField + '%' or [AreasAtencionUsuarioSistema] like '%' + @lV20K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [AreasAtencionId]";
         }
         else if ( AV15OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [AreasAtencionId] DESC";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [AreasAtencionDescripcion]";
         }
         else if ( AV15OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [AreasAtencionDescripcion] DESC";
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
                     return conditional_P007J2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
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
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
