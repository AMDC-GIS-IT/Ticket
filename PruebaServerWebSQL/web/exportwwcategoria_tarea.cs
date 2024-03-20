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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportwwcategoria_tarea : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("K2BOrion");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "id_unidad_gis");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV13id_unidad_gis = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV41flnombre = GetPar( "flnombre");
                  AV12K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV20OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public exportwwcategoria_tarea( )
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

      public exportwwcategoria_tarea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_id_unidad_gis ,
                           string aP1_flnombre ,
                           string aP2_K2BToolsGenericSearchField ,
                           ref short aP3_OrderedBy )
      {
         this.AV13id_unidad_gis = aP0_id_unidad_gis;
         this.AV41flnombre = aP1_flnombre;
         this.AV12K2BToolsGenericSearchField = aP2_K2BToolsGenericSearchField;
         this.AV20OrderedBy = aP3_OrderedBy;
         initialize();
         executePrivate();
         aP3_OrderedBy=this.AV20OrderedBy;
      }

      public short executeUdp( int aP0_id_unidad_gis ,
                               string aP1_flnombre ,
                               string aP2_K2BToolsGenericSearchField )
      {
         execute(aP0_id_unidad_gis, aP1_flnombre, aP2_K2BToolsGenericSearchField, ref aP3_OrderedBy);
         return AV20OrderedBy ;
      }

      public void executeSubmit( int aP0_id_unidad_gis ,
                                 string aP1_flnombre ,
                                 string aP2_K2BToolsGenericSearchField ,
                                 ref short aP3_OrderedBy )
      {
         exportwwcategoria_tarea objexportwwcategoria_tarea;
         objexportwwcategoria_tarea = new exportwwcategoria_tarea();
         objexportwwcategoria_tarea.AV13id_unidad_gis = aP0_id_unidad_gis;
         objexportwwcategoria_tarea.AV41flnombre = aP1_flnombre;
         objexportwwcategoria_tarea.AV12K2BToolsGenericSearchField = aP2_K2BToolsGenericSearchField;
         objexportwwcategoria_tarea.AV20OrderedBy = aP3_OrderedBy;
         objexportwwcategoria_tarea.context.SetSubmitInitialConfig(context);
         objexportwwcategoria_tarea.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwcategoria_tarea);
         aP3_OrderedBy=this.AV20OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwcategoria_tarea)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "categoria_tarea",  "categoria_tarea",  "List",  "",  "WWcategoria_tarea") )
         {
            AV26Filename = "";
            AV27ErrorMessage = "You are not authorized to do activity";
            AV27ErrorMessage += "EntityName:" + "categoria_tarea";
            AV27ErrorMessage += "TransactionName:" + "categoria_tarea";
            AV27ErrorMessage += "ActivityType:" + "";
            AV27ErrorMessage += "PgmName:" + AV44Pgmname;
            AV28HttpResponse.AddString(AV27ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV40Context) ;
         AV24Random = (int)(NumberUtil.Random( )*10000);
         AV26Filename = GxDirectory.TemporaryFilesPath + AV29File.Separator + "ExportWWcategoria_tarea-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV24Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV21ExcelDocument.Open(AV26Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV21ExcelDocument.Clear();
         AV21ExcelDocument.AutoFit = 1;
         AV22CellRow = 1;
         AV23FirstColumn = 1;
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Size = 15;
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Bold = 1;
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Text = "categoria_tareas";
         AV22CellRow = (int)(AV22CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (0==AV13id_unidad_gis) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "id_unidad_gis";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Number = AV13id_unidad_gis;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41flnombre)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "nombre_categoria";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV41flnombre);
            AV22CellRow = (int)(AV22CellRow+1);
         }
         AV22CellRow = (int)(AV22CellRow+3);
         AV25ColumnIndex = 0;
         if ( AV30GridColumnVisible_categoria_tareaid_tipo_categoria )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "id_tipo_categoria";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_id_unidad_gis )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "id_unidad_gis";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_nombre_categoria )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "nombre_categoria";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_categoria_tareaestado )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "estado";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV13id_unidad_gis ,
                                              AV41flnombre ,
                                              AV12K2BToolsGenericSearchField ,
                                              A105id_unidad_gis ,
                                              A106nombre_categoria ,
                                              A104categoria_tareaid_tipo_categoria ,
                                              A107categoria_tareaestado ,
                                              AV20OrderedBy } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV41flnombre = StringUtil.Concat( StringUtil.RTrim( AV41flnombre), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P005K2 */
         pr_datastore1.execute(0, new Object[] {AV13id_unidad_gis, lV41flnombre, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A107categoria_tareaestado = P005K2_A107categoria_tareaestado[0];
            n107categoria_tareaestado = P005K2_n107categoria_tareaestado[0];
            A104categoria_tareaid_tipo_categoria = P005K2_A104categoria_tareaid_tipo_categoria[0];
            A106nombre_categoria = P005K2_A106nombre_categoria[0];
            n106nombre_categoria = P005K2_n106nombre_categoria[0];
            A105id_unidad_gis = P005K2_A105id_unidad_gis[0];
            AV22CellRow = (int)(AV22CellRow+1);
            AV25ColumnIndex = 0;
            if ( AV30GridColumnVisible_categoria_tareaid_tipo_categoria )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A104categoria_tareaid_tipo_categoria;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_id_unidad_gis )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A105id_unidad_gis;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_nombre_categoria )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A106nombre_categoria);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_categoria_tareaestado )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A107categoria_tareaestado;
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
         if ( ! context.isAjaxRequest( ) )
         {
            AV28HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV28HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportWWcategoria_tarea.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV28HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV28HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV28HttpResponse.AddFile(AV26Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV26Filename) ;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV21ExcelDocument.ErrCode != 0 )
         {
            AV26Filename = "";
            AV27ErrorMessage = AV21ExcelDocument.ErrDescription;
            AV28HttpResponse.AddString(AV27ErrorMessage);
            context.nUserReturn = 1;
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
         new k2bloadgridconfiguration(context ).execute(  "WWcategoria_tarea",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV30GridColumnVisible_categoria_tareaid_tipo_categoria = true;
         AV31GridColumnVisible_id_unidad_gis = true;
         AV32GridColumnVisible_nombre_categoria = true;
         AV33GridColumnVisible_categoria_tareaestado = true;
         new k2bsavegridconfiguration(context ).execute(  "WWcategoria_tarea",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV46GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "categoria_tareaid_tipo_categoria") == 0 )
               {
                  AV30GridColumnVisible_categoria_tareaid_tipo_categoria = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_unidad_gis") == 0 )
               {
                  AV31GridColumnVisible_id_unidad_gis = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_categoria") == 0 )
               {
                  AV32GridColumnVisible_nombre_categoria = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "categoria_tareaestado") == 0 )
               {
                  AV33GridColumnVisible_categoria_tareaestado = false;
               }
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "categoria_tareaid_tipo_categoria";
         AV11GridColumn.gxTpr_Columntitle = "id_tipo_categoria";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_unidad_gis";
         AV11GridColumn.gxTpr_Columntitle = "id_unidad_gis";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_categoria";
         AV11GridColumn.gxTpr_Columntitle = "nombre_categoria";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "categoria_tareaestado";
         AV11GridColumn.gxTpr_Columntitle = "estado";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV8GridConfiguration.gxTpr_Gridcolumns = AV10GridColumns;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV26Filename = "";
         AV27ErrorMessage = "";
         AV44Pgmname = "";
         AV28HttpResponse = new GxHttpResponse( context);
         AV40Context = new SdtK2BContext(context);
         AV29File = new GxFile(context.GetPhysicalPath());
         AV21ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV41flnombre = "";
         lV12K2BToolsGenericSearchField = "";
         A106nombre_categoria = "";
         P005K2_A107categoria_tareaestado = new int[1] ;
         P005K2_n107categoria_tareaestado = new bool[] {false} ;
         P005K2_A104categoria_tareaid_tipo_categoria = new int[1] ;
         P005K2_A106nombre_categoria = new string[] {""} ;
         P005K2_n106nombre_categoria = new bool[] {false} ;
         P005K2_A105id_unidad_gis = new int[1] ;
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.exportwwcategoria_tarea__datastore1(),
            new Object[][] {
                new Object[] {
               P005K2_A107categoria_tareaestado, P005K2_n107categoria_tareaestado, P005K2_A104categoria_tareaid_tipo_categoria, P005K2_A106nombre_categoria, P005K2_n106nombre_categoria, P005K2_A105id_unidad_gis
               }
            }
         );
         AV44Pgmname = "ExportWWcategoria_tarea";
         /* GeneXus formulas. */
         AV44Pgmname = "ExportWWcategoria_tarea";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV20OrderedBy ;
      private short GxWebError ;
      private short AV25ColumnIndex ;
      private int AV13id_unidad_gis ;
      private int AV24Random ;
      private int AV22CellRow ;
      private int AV23FirstColumn ;
      private int A105id_unidad_gis ;
      private int A104categoria_tareaid_tipo_categoria ;
      private int A107categoria_tareaestado ;
      private int AV46GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV12K2BToolsGenericSearchField ;
      private string AV44Pgmname ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV30GridColumnVisible_categoria_tareaid_tipo_categoria ;
      private bool AV31GridColumnVisible_id_unidad_gis ;
      private bool AV32GridColumnVisible_nombre_categoria ;
      private bool AV33GridColumnVisible_categoria_tareaestado ;
      private bool n107categoria_tareaestado ;
      private bool n106nombre_categoria ;
      private string AV41flnombre ;
      private string AV26Filename ;
      private string AV27ErrorMessage ;
      private string lV41flnombre ;
      private string A106nombre_categoria ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP3_OrderedBy ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] P005K2_A107categoria_tareaestado ;
      private bool[] P005K2_n107categoria_tareaestado ;
      private int[] P005K2_A104categoria_tareaid_tipo_categoria ;
      private string[] P005K2_A106nombre_categoria ;
      private bool[] P005K2_n106nombre_categoria ;
      private int[] P005K2_A105id_unidad_gis ;
      private GxHttpResponse AV28HttpResponse ;
      private ExcelDocumentI AV21ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV29File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV40Context ;
   }

   public class exportwwcategoria_tarea__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005K2( IGxContext context ,
                                             int AV13id_unidad_gis ,
                                             string AV41flnombre ,
                                             string AV12K2BToolsGenericSearchField ,
                                             int A105id_unidad_gis ,
                                             string A106nombre_categoria ,
                                             int A104categoria_tareaid_tipo_categoria ,
                                             int A107categoria_tareaestado ,
                                             short AV20OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [estado], [id_tipo_categoria], [nombre_categoria], [id_unidad_gis] FROM dbo.[categoria_tarea]";
         if ( ! (0==AV13id_unidad_gis) )
         {
            AddWhere(sWhereString, "([id_unidad_gis] = @AV13id_unidad_gis)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41flnombre)) )
         {
            AddWhere(sWhereString, "([nombre_categoria] like @lV41flnombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_tipo_categoria] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([id_unidad_gis] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [nombre_categoria] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV20OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [id_tipo_categoria]";
         }
         else if ( AV20OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [id_tipo_categoria] DESC";
         }
         else if ( AV20OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [id_unidad_gis]";
         }
         else if ( AV20OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [id_unidad_gis] DESC";
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
                     return conditional_P005K2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP005K2;
          prmP005K2 = new Object[] {
          new ParDef("@AV13id_unidad_gis",GXType.Int32,9,0) ,
          new ParDef("@lV41flnombre",GXType.NVarChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
