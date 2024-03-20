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
   public class exportwwdepto : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "K2BToolsGenericSearchField");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV12K2BToolsGenericSearchField = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public exportwwdepto( )
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

      public exportwwdepto( IGxContext context )
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

      public void execute( string aP0_K2BToolsGenericSearchField ,
                           ref short aP1_OrderedBy )
      {
         this.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         this.AV13OrderedBy = aP1_OrderedBy;
         initialize();
         executePrivate();
         aP1_OrderedBy=this.AV13OrderedBy;
      }

      public short executeUdp( string aP0_K2BToolsGenericSearchField )
      {
         execute(aP0_K2BToolsGenericSearchField, ref aP1_OrderedBy);
         return AV13OrderedBy ;
      }

      public void executeSubmit( string aP0_K2BToolsGenericSearchField ,
                                 ref short aP1_OrderedBy )
      {
         exportwwdepto objexportwwdepto;
         objexportwwdepto = new exportwwdepto();
         objexportwwdepto.AV12K2BToolsGenericSearchField = aP0_K2BToolsGenericSearchField;
         objexportwwdepto.AV13OrderedBy = aP1_OrderedBy;
         objexportwwdepto.context.SetSubmitInitialConfig(context);
         objexportwwdepto.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwdepto);
         aP1_OrderedBy=this.AV13OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwdepto)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Depto",  "Depto",  "List",  "",  "WWDepto") )
         {
            AV19Filename = "";
            AV20ErrorMessage = "You are not authorized to do activity";
            AV20ErrorMessage += "EntityName:" + "Depto";
            AV20ErrorMessage += "TransactionName:" + "Depto";
            AV20ErrorMessage += "ActivityType:" + "";
            AV20ErrorMessage += "PgmName:" + AV29Pgmname;
            AV21HttpResponse.AddString(AV20ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV26Context) ;
         AV17Random = (int)(NumberUtil.Random( )*10000);
         AV19Filename = GxDirectory.TemporaryFilesPath + AV22File.Separator + "ExportWWDepto-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Open(AV19Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Clear();
         AV14ExcelDocument.AutoFit = 1;
         AV15CellRow = 1;
         AV16FirstColumn = 1;
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Size = 15;
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
         AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = "Deptos";
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
         if ( AV23GridColumnVisible_CentrodecostoId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Centrodecosto Id";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_DepartamentoId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Departamento Id";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV25GridColumnVisible_DepartamentoNombre )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Departamento Nombre";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         pr_datastore2.dynParam(0, new Object[]{ new Object[]{
                                              AV12K2BToolsGenericSearchField ,
                                              A259CentrodecostoId ,
                                              A260DepartamentoId ,
                                              A261DepartamentoNombre ,
                                              AV13OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P005W2 */
         pr_datastore2.execute(0, new Object[] {lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_datastore2.getStatus(0) != 101) )
         {
            A261DepartamentoNombre = P005W2_A261DepartamentoNombre[0];
            A260DepartamentoId = P005W2_A260DepartamentoId[0];
            A259CentrodecostoId = P005W2_A259CentrodecostoId[0];
            AV15CellRow = (int)(AV15CellRow+1);
            AV18ColumnIndex = 0;
            if ( AV23GridColumnVisible_CentrodecostoId )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A259CentrodecostoId);
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV24GridColumnVisible_DepartamentoId )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Number = A260DepartamentoId;
               AV18ColumnIndex = (short)(AV18ColumnIndex+1);
            }
            if ( AV25GridColumnVisible_DepartamentoNombre )
            {
               AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A261DepartamentoNombre);
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
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportWWDepto.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV21HttpResponse.AddFile(AV19Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV19Filename) ;
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
         if ( AV14ExcelDocument.ErrCode != 0 )
         {
            AV19Filename = "";
            AV20ErrorMessage = AV14ExcelDocument.ErrDescription;
            AV21HttpResponse.AddString(AV20ErrorMessage);
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
         new k2bloadgridconfiguration(context ).execute(  "WWDepto",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV23GridColumnVisible_CentrodecostoId = true;
         AV24GridColumnVisible_DepartamentoId = true;
         AV25GridColumnVisible_DepartamentoNombre = true;
         new k2bsavegridconfiguration(context ).execute(  "WWDepto",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV31GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "CentrodecostoId") == 0 )
               {
                  AV23GridColumnVisible_CentrodecostoId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "DepartamentoId") == 0 )
               {
                  AV24GridColumnVisible_DepartamentoId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "DepartamentoNombre") == 0 )
               {
                  AV25GridColumnVisible_DepartamentoNombre = false;
               }
            }
            AV31GXV1 = (int)(AV31GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "CentrodecostoId";
         AV11GridColumn.gxTpr_Columntitle = "Centrodecosto Id";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "DepartamentoId";
         AV11GridColumn.gxTpr_Columntitle = "Departamento Id";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "DepartamentoNombre";
         AV11GridColumn.gxTpr_Columntitle = "Departamento Nombre";
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
         AV19Filename = "";
         AV20ErrorMessage = "";
         AV29Pgmname = "";
         AV21HttpResponse = new GxHttpResponse( context);
         AV26Context = new SdtK2BContext(context);
         AV22File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV12K2BToolsGenericSearchField = "";
         A259CentrodecostoId = "";
         A261DepartamentoNombre = "";
         P005W2_A261DepartamentoNombre = new string[] {""} ;
         P005W2_A260DepartamentoId = new short[1] ;
         P005W2_A259CentrodecostoId = new string[] {""} ;
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.exportwwdepto__datastore2(),
            new Object[][] {
                new Object[] {
               P005W2_A261DepartamentoNombre, P005W2_A260DepartamentoId, P005W2_A259CentrodecostoId
               }
            }
         );
         AV29Pgmname = "ExportWWDepto";
         /* GeneXus formulas. */
         AV29Pgmname = "ExportWWDepto";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV13OrderedBy ;
      private short GxWebError ;
      private short AV18ColumnIndex ;
      private short A260DepartamentoId ;
      private int AV17Random ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int AV31GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV12K2BToolsGenericSearchField ;
      private string AV29Pgmname ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV23GridColumnVisible_CentrodecostoId ;
      private bool AV24GridColumnVisible_DepartamentoId ;
      private bool AV25GridColumnVisible_DepartamentoNombre ;
      private string AV19Filename ;
      private string AV20ErrorMessage ;
      private string A259CentrodecostoId ;
      private string A261DepartamentoNombre ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP1_OrderedBy ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] P005W2_A261DepartamentoNombre ;
      private short[] P005W2_A260DepartamentoId ;
      private string[] P005W2_A259CentrodecostoId ;
      private GxHttpResponse AV21HttpResponse ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV22File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV26Context ;
   }

   public class exportwwdepto__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005W2( IGxContext context ,
                                             string AV12K2BToolsGenericSearchField ,
                                             string A259CentrodecostoId ,
                                             short A260DepartamentoId ,
                                             string A261DepartamentoNombre ,
                                             short AV13OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [DepartamentoNombre], [DepartamentoId], [CentrodecostoId] FROM dbo.[Depto]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "([CentrodecostoId] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST([DepartamentoId] AS decimal(4,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [DepartamentoNombre] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [CentrodecostoId], [DepartamentoId]";
         }
         else if ( AV13OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [DepartamentoNombre]";
         }
         else if ( AV13OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [DepartamentoNombre] DESC";
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
                     return conditional_P005W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
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
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

}
