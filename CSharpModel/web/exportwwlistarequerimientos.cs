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
   public class exportwwlistarequerimientos : GXProcedure
   {
      public exportwwlistarequerimientos( )
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

      public exportwwlistarequerimientos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ListaRequerimientosDescripcion ,
                           string aP1_AreasAtencionDescripcion ,
                           string aP2_K2BToolsGenericSearchField ,
                           short aP3_OrderedBy ,
                           out string aP4_OutFile )
      {
         this.AV21ListaRequerimientosDescripcion = aP0_ListaRequerimientosDescripcion;
         this.AV22AreasAtencionDescripcion = aP1_AreasAtencionDescripcion;
         this.AV20K2BToolsGenericSearchField = aP2_K2BToolsGenericSearchField;
         this.AV15OrderedBy = aP3_OrderedBy;
         this.AV13OutFile = "" ;
         initialize();
         executePrivate();
         aP4_OutFile=this.AV13OutFile;
      }

      public string executeUdp( string aP0_ListaRequerimientosDescripcion ,
                                string aP1_AreasAtencionDescripcion ,
                                string aP2_K2BToolsGenericSearchField ,
                                short aP3_OrderedBy )
      {
         execute(aP0_ListaRequerimientosDescripcion, aP1_AreasAtencionDescripcion, aP2_K2BToolsGenericSearchField, aP3_OrderedBy, out aP4_OutFile);
         return AV13OutFile ;
      }

      public void executeSubmit( string aP0_ListaRequerimientosDescripcion ,
                                 string aP1_AreasAtencionDescripcion ,
                                 string aP2_K2BToolsGenericSearchField ,
                                 short aP3_OrderedBy ,
                                 out string aP4_OutFile )
      {
         exportwwlistarequerimientos objexportwwlistarequerimientos;
         objexportwwlistarequerimientos = new exportwwlistarequerimientos();
         objexportwwlistarequerimientos.AV21ListaRequerimientosDescripcion = aP0_ListaRequerimientosDescripcion;
         objexportwwlistarequerimientos.AV22AreasAtencionDescripcion = aP1_AreasAtencionDescripcion;
         objexportwwlistarequerimientos.AV20K2BToolsGenericSearchField = aP2_K2BToolsGenericSearchField;
         objexportwwlistarequerimientos.AV15OrderedBy = aP3_OrderedBy;
         objexportwwlistarequerimientos.AV13OutFile = "" ;
         objexportwwlistarequerimientos.context.SetSubmitInitialConfig(context);
         objexportwwlistarequerimientos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwlistarequerimientos);
         aP4_OutFile=this.AV13OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwlistarequerimientos)stateInfo).executePrivate();
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
         AV13OutFile = GxDirectory.TemporaryFilesPath + AV14File.Separator + "ExportWWListaRequerimientos-" + Guid.NewGuid( ).ToString() + ".xlsx";
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20K2BToolsGenericSearchField)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = AV20K2BToolsGenericSearchField;
            AV9CellRow = (int)(AV9CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ListaRequerimientosDescripcion)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Descripción:";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV21ListaRequerimientosDescripcion);
            AV9CellRow = (int)(AV9CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22AreasAtencionDescripcion)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Descripción: ";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV22AreasAtencionDescripcion);
            AV9CellRow = (int)(AV9CellRow+1);
         }
         AV9CellRow = (int)(AV9CellRow+3);
         AV11ColumnIndex = 0;
         if ( AV23GridColumnVisible_ListaRequerimientosId )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_ListaRequerimientosDescripcion )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Descripción:";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV25GridColumnVisible_AreasAtencionDescripcion )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Descripción: ";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV26GridColumnVisible_ListaRequerimientosUsuarioSistema )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Registro:";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV21ListaRequerimientosDescripcion ,
                                              AV22AreasAtencionDescripcion ,
                                              AV20K2BToolsGenericSearchField ,
                                              A370ListaRequerimientosDescripcion ,
                                              A367AreasAtencionDescripcion ,
                                              A369ListaRequerimientosId ,
                                              A371ListaRequerimientosUsuarioSistema ,
                                              AV15OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV21ListaRequerimientosDescripcion = StringUtil.Concat( StringUtil.RTrim( AV21ListaRequerimientosDescripcion), "%", "");
         lV22AreasAtencionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV22AreasAtencionDescripcion), "%", "");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P007N2 */
         pr_default.execute(0, new Object[] {lV21ListaRequerimientosDescripcion, lV22AreasAtencionDescripcion, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A366AreasAtencionId = P007N2_A366AreasAtencionId[0];
            A371ListaRequerimientosUsuarioSistema = P007N2_A371ListaRequerimientosUsuarioSistema[0];
            A369ListaRequerimientosId = P007N2_A369ListaRequerimientosId[0];
            A367AreasAtencionDescripcion = P007N2_A367AreasAtencionDescripcion[0];
            A370ListaRequerimientosDescripcion = P007N2_A370ListaRequerimientosDescripcion[0];
            A367AreasAtencionDescripcion = P007N2_A367AreasAtencionDescripcion[0];
            AV9CellRow = (int)(AV9CellRow+1);
            AV11ColumnIndex = 0;
            if ( AV23GridColumnVisible_ListaRequerimientosId )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Number = A369ListaRequerimientosId;
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV24GridColumnVisible_ListaRequerimientosDescripcion )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A370ListaRequerimientosDescripcion);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV25GridColumnVisible_AreasAtencionDescripcion )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A367AreasAtencionDescripcion);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV26GridColumnVisible_ListaRequerimientosUsuarioSistema )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A371ListaRequerimientosUsuarioSistema);
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
         new k2bloadgridconfiguration(context ).execute(  "WWListaRequerimientos",  "Grid", ref  AV16GridConfiguration) ;
         AV18GridColumns = AV16GridConfiguration.gxTpr_Gridcolumns;
         AV23GridColumnVisible_ListaRequerimientosId = true;
         AV24GridColumnVisible_ListaRequerimientosDescripcion = true;
         AV25GridColumnVisible_AreasAtencionDescripcion = true;
         AV26GridColumnVisible_ListaRequerimientosUsuarioSistema = true;
         new k2bsavegridconfiguration(context ).execute(  "WWListaRequerimientos",  "Grid",  AV16GridConfiguration,  false) ;
         AV18GridColumns = AV16GridConfiguration.gxTpr_Gridcolumns;
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV18GridColumns.Count )
         {
            AV19GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV18GridColumns.Item(AV31GXV1));
            if ( ! AV19GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "ListaRequerimientosId") == 0 )
               {
                  AV23GridColumnVisible_ListaRequerimientosId = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "ListaRequerimientosDescripcion") == 0 )
               {
                  AV24GridColumnVisible_ListaRequerimientosDescripcion = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "AreasAtencionDescripcion") == 0 )
               {
                  AV25GridColumnVisible_AreasAtencionDescripcion = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "ListaRequerimientosUsuarioSistema") == 0 )
               {
                  AV26GridColumnVisible_ListaRequerimientosUsuarioSistema = false;
               }
            }
            AV31GXV1 = (int)(AV31GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV18GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "ListaRequerimientosId";
         AV19GridColumn.gxTpr_Columntitle = "";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "ListaRequerimientosDescripcion";
         AV19GridColumn.gxTpr_Columntitle = "Descripción:";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "AreasAtencionDescripcion";
         AV19GridColumn.gxTpr_Columntitle = "Descripción: ";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "ListaRequerimientosUsuarioSistema";
         AV19GridColumn.gxTpr_Columntitle = "Registro:";
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
         AV27Context = new SdtK2BContext(context);
         AV14File = new GxFile(context.GetPhysicalPath());
         AV8ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV21ListaRequerimientosDescripcion = "";
         lV22AreasAtencionDescripcion = "";
         lV20K2BToolsGenericSearchField = "";
         A370ListaRequerimientosDescripcion = "";
         A367AreasAtencionDescripcion = "";
         A371ListaRequerimientosUsuarioSistema = "";
         P007N2_A366AreasAtencionId = new short[1] ;
         P007N2_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         P007N2_A369ListaRequerimientosId = new short[1] ;
         P007N2_A367AreasAtencionDescripcion = new string[] {""} ;
         P007N2_A370ListaRequerimientosDescripcion = new string[] {""} ;
         AV12ErrorMessage = "";
         AV16GridConfiguration = new SdtK2BGridConfiguration(context);
         AV18GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwlistarequerimientos__default(),
            new Object[][] {
                new Object[] {
               P007N2_A366AreasAtencionId, P007N2_A371ListaRequerimientosUsuarioSistema, P007N2_A369ListaRequerimientosId, P007N2_A367AreasAtencionDescripcion, P007N2_A370ListaRequerimientosDescripcion
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15OrderedBy ;
      private short AV11ColumnIndex ;
      private short A369ListaRequerimientosId ;
      private short A366AreasAtencionId ;
      private int AV9CellRow ;
      private int AV10FirstColumn ;
      private int AV31GXV1 ;
      private string AV20K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV20K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV23GridColumnVisible_ListaRequerimientosId ;
      private bool AV24GridColumnVisible_ListaRequerimientosDescripcion ;
      private bool AV25GridColumnVisible_AreasAtencionDescripcion ;
      private bool AV26GridColumnVisible_ListaRequerimientosUsuarioSistema ;
      private string AV21ListaRequerimientosDescripcion ;
      private string AV22AreasAtencionDescripcion ;
      private string AV13OutFile ;
      private string lV21ListaRequerimientosDescripcion ;
      private string lV22AreasAtencionDescripcion ;
      private string A370ListaRequerimientosDescripcion ;
      private string A367AreasAtencionDescripcion ;
      private string A371ListaRequerimientosUsuarioSistema ;
      private string AV12ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P007N2_A366AreasAtencionId ;
      private string[] P007N2_A371ListaRequerimientosUsuarioSistema ;
      private short[] P007N2_A369ListaRequerimientosId ;
      private string[] P007N2_A367AreasAtencionDescripcion ;
      private string[] P007N2_A370ListaRequerimientosDescripcion ;
      private string aP4_OutFile ;
      private ExcelDocumentI AV8ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV18GridColumns ;
      private GxFile AV14File ;
      private SdtK2BGridConfiguration AV16GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV19GridColumn ;
      private SdtK2BContext AV27Context ;
   }

   public class exportwwlistarequerimientos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007N2( IGxContext context ,
                                             string AV21ListaRequerimientosDescripcion ,
                                             string AV22AreasAtencionDescripcion ,
                                             string AV20K2BToolsGenericSearchField ,
                                             string A370ListaRequerimientosDescripcion ,
                                             string A367AreasAtencionDescripcion ,
                                             short A369ListaRequerimientosId ,
                                             string A371ListaRequerimientosUsuarioSistema ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[AreasAtencionId], T1.[ListaRequerimientosUsuarioSistema], T1.[ListaRequerimientosId], T2.[AreasAtencionDescripcion], T1.[ListaRequerimientosDescripcion] FROM ([ListaRequerimientos] T1 INNER JOIN [AreasAtencion] T2 ON T2.[AreasAtencionId] = T1.[AreasAtencionId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ListaRequerimientosDescripcion)) )
         {
            AddWhere(sWhereString, "(T1.[ListaRequerimientosDescripcion] like @lV21ListaRequerimientosDescripcion)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22AreasAtencionDescripcion)) )
         {
            AddWhere(sWhereString, "(T2.[AreasAtencionDescripcion] like @lV22AreasAtencionDescripcion)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST(T1.[ListaRequerimientosId] AS decimal(4,0))) like '%' + @lV20K2BToolsGenericSearchField + '%' or T1.[ListaRequerimientosDescripcion] like '%' + @lV20K2BToolsGenericSearchField + '%' or T2.[AreasAtencionDescripcion] like '%' + @lV20K2BToolsGenericSearchField + '%' or T1.[ListaRequerimientosUsuarioSistema] like '%' + @lV20K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[ListaRequerimientosId]";
         }
         else if ( AV15OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[ListaRequerimientosId] DESC";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[ListaRequerimientosDescripcion]";
         }
         else if ( AV15OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[ListaRequerimientosDescripcion] DESC";
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
                     return conditional_P007N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP007N2;
          prmP007N2 = new Object[] {
          new ParDef("@lV21ListaRequerimientosDescripcion",GXType.NVarChar,100,0) ,
          new ParDef("@lV22AreasAtencionDescripcion",GXType.NVarChar,30,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
