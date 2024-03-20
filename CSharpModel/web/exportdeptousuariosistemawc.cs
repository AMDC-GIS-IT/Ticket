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
   public class exportdeptousuariosistemawc : GXProcedure
   {
      public exportdeptousuariosistemawc( )
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

      public exportdeptousuariosistemawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_CentrodecostoId ,
                           short aP1_DepartamentoId ,
                           string aP2_UsuarioSistemaIdentidad ,
                           string aP3_DireccionDescripcion ,
                           string aP4_K2BToolsGenericSearchField ,
                           short aP5_OrderedBy ,
                           out string aP6_OutFile )
      {
         this.AV8CentrodecostoId = aP0_CentrodecostoId;
         this.AV9DepartamentoId = aP1_DepartamentoId;
         this.AV11UsuarioSistemaIdentidad = aP2_UsuarioSistemaIdentidad;
         this.AV12DireccionDescripcion = aP3_DireccionDescripcion;
         this.AV10K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         this.AV13OrderedBy = aP5_OrderedBy;
         this.AV34OutFile = "" ;
         initialize();
         executePrivate();
         aP6_OutFile=this.AV34OutFile;
      }

      public string executeUdp( string aP0_CentrodecostoId ,
                                short aP1_DepartamentoId ,
                                string aP2_UsuarioSistemaIdentidad ,
                                string aP3_DireccionDescripcion ,
                                string aP4_K2BToolsGenericSearchField ,
                                short aP5_OrderedBy )
      {
         execute(aP0_CentrodecostoId, aP1_DepartamentoId, aP2_UsuarioSistemaIdentidad, aP3_DireccionDescripcion, aP4_K2BToolsGenericSearchField, aP5_OrderedBy, out aP6_OutFile);
         return AV34OutFile ;
      }

      public void executeSubmit( string aP0_CentrodecostoId ,
                                 short aP1_DepartamentoId ,
                                 string aP2_UsuarioSistemaIdentidad ,
                                 string aP3_DireccionDescripcion ,
                                 string aP4_K2BToolsGenericSearchField ,
                                 short aP5_OrderedBy ,
                                 out string aP6_OutFile )
      {
         exportdeptousuariosistemawc objexportdeptousuariosistemawc;
         objexportdeptousuariosistemawc = new exportdeptousuariosistemawc();
         objexportdeptousuariosistemawc.AV8CentrodecostoId = aP0_CentrodecostoId;
         objexportdeptousuariosistemawc.AV9DepartamentoId = aP1_DepartamentoId;
         objexportdeptousuariosistemawc.AV11UsuarioSistemaIdentidad = aP2_UsuarioSistemaIdentidad;
         objexportdeptousuariosistemawc.AV12DireccionDescripcion = aP3_DireccionDescripcion;
         objexportdeptousuariosistemawc.AV10K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         objexportdeptousuariosistemawc.AV13OrderedBy = aP5_OrderedBy;
         objexportdeptousuariosistemawc.AV34OutFile = "" ;
         objexportdeptousuariosistemawc.context.SetSubmitInitialConfig(context);
         objexportdeptousuariosistemawc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportdeptousuariosistemawc);
         aP6_OutFile=this.AV34OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportdeptousuariosistemawc)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV33Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV34OutFile = GxDirectory.TemporaryFilesPath + AV22File.Separator + "ExportDeptoUsuarioSistemaWC-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV14ExcelDocument.Open(AV34OutFile);
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
         /* Using cursor P005X2 */
         pr_datastore2.execute(0, new Object[] {AV8CentrodecostoId, AV9DepartamentoId});
         while ( (pr_datastore2.getStatus(0) != 101) )
         {
            A260DepartamentoId = P005X2_A260DepartamentoId[0];
            A259CentrodecostoId = P005X2_A259CentrodecostoId[0];
            A261DepartamentoNombre = P005X2_A261DepartamentoNombre[0];
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Departamento Nombre";
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A261DepartamentoNombre);
            AV15CellRow = (int)(AV15CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_datastore2.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = AV10K2BToolsGenericSearchField;
            AV15CellRow = (int)(AV15CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11UsuarioSistemaIdentidad)) )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Identidad";
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV11UsuarioSistemaIdentidad);
            AV15CellRow = (int)(AV15CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12DireccionDescripcion)) )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Direccion Descripcion";
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV12DireccionDescripcion);
            AV15CellRow = (int)(AV15CellRow+1);
         }
         AV15CellRow = (int)(AV15CellRow+3);
         AV18ColumnIndex = 0;
         if ( AV27GridColumnVisible_UsuarioSistemaId )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Usuario Sistema:";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV28GridColumnVisible_UsuarioSistemaIdentidad )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Identidad";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV29GridColumnVisible_UsuarioSistemaNombre )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Nombre";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV30GridColumnVisible_UsuarioSistemaGerencia )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Gerencia";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_UsuarioSistemaDepartamento )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Departamento";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_DireccionDescripcion )
         {
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = "Direccion Descripcion";
            AV18ColumnIndex = (short)(AV18ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11UsuarioSistemaIdentidad ,
                                              A101UsuarioSistemaIdentidad ,
                                              AV13OrderedBy ,
                                              AV10K2BToolsGenericSearchField ,
                                              A99UsuarioSistemaId ,
                                              A100UsuarioSistemaNombre ,
                                              A263UsuarioSistemaGerencia ,
                                              A257UsuarioSistemaDepartamento ,
                                              A262DireccionDescripcion ,
                                              AV12DireccionDescripcion ,
                                              AV8CentrodecostoId ,
                                              AV9DepartamentoId ,
                                              A259CentrodecostoId ,
                                              A260DepartamentoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV11UsuarioSistemaIdentidad), "%", "");
         /* Using cursor P005X3 */
         pr_default.execute(0, new Object[] {AV8CentrodecostoId, AV9DepartamentoId, lV11UsuarioSistemaIdentidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A258DireccionId = P005X3_A258DireccionId[0];
            A257UsuarioSistemaDepartamento = P005X3_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = P005X3_n257UsuarioSistemaDepartamento[0];
            A263UsuarioSistemaGerencia = P005X3_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = P005X3_n263UsuarioSistemaGerencia[0];
            A100UsuarioSistemaNombre = P005X3_A100UsuarioSistemaNombre[0];
            A99UsuarioSistemaId = P005X3_A99UsuarioSistemaId[0];
            A101UsuarioSistemaIdentidad = P005X3_A101UsuarioSistemaIdentidad[0];
            A260DepartamentoId = P005X3_A260DepartamentoId[0];
            A259CentrodecostoId = P005X3_A259CentrodecostoId[0];
            /* Using cursor P005X4 */
            pr_datastore2.execute(1, new Object[] {A258DireccionId});
            A262DireccionDescripcion = P005X4_A262DireccionDescripcion[0];
            pr_datastore2.close(1);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12DireccionDescripcion)) || ( StringUtil.Like( A262DireccionDescripcion , StringUtil.PadR( AV12DireccionDescripcion , 300 , "%"),  ' ' ) ) )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A262DireccionDescripcion , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV18ColumnIndex = 0;
                  if ( AV27GridColumnVisible_UsuarioSistemaId )
                  {
                     AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A99UsuarioSistemaId);
                     AV18ColumnIndex = (short)(AV18ColumnIndex+1);
                  }
                  if ( AV28GridColumnVisible_UsuarioSistemaIdentidad )
                  {
                     AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A101UsuarioSistemaIdentidad);
                     AV18ColumnIndex = (short)(AV18ColumnIndex+1);
                  }
                  if ( AV29GridColumnVisible_UsuarioSistemaNombre )
                  {
                     AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A100UsuarioSistemaNombre);
                     AV18ColumnIndex = (short)(AV18ColumnIndex+1);
                  }
                  if ( AV30GridColumnVisible_UsuarioSistemaGerencia )
                  {
                     AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A263UsuarioSistemaGerencia);
                     AV18ColumnIndex = (short)(AV18ColumnIndex+1);
                  }
                  if ( AV31GridColumnVisible_UsuarioSistemaDepartamento )
                  {
                     AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A257UsuarioSistemaDepartamento);
                     AV18ColumnIndex = (short)(AV18ColumnIndex+1);
                  }
                  if ( AV32GridColumnVisible_DireccionDescripcion )
                  {
                     AV14ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+AV18ColumnIndex, 1, 1).Text = StringUtil.RTrim( A262DireccionDescripcion);
                     AV18ColumnIndex = (short)(AV18ColumnIndex+1);
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_datastore2.close(1);
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
            AV34OutFile = "";
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
         new k2bloadgridconfiguration(context ).execute(  "DeptoUsuarioSistemaWC",  "Grid", ref  AV23GridConfiguration) ;
         AV25GridColumns = AV23GridConfiguration.gxTpr_Gridcolumns;
         AV27GridColumnVisible_UsuarioSistemaId = true;
         AV28GridColumnVisible_UsuarioSistemaIdentidad = true;
         AV29GridColumnVisible_UsuarioSistemaNombre = true;
         AV30GridColumnVisible_UsuarioSistemaGerencia = true;
         AV31GridColumnVisible_UsuarioSistemaDepartamento = true;
         AV32GridColumnVisible_DireccionDescripcion = true;
         new k2bsavegridconfiguration(context ).execute(  "DeptoUsuarioSistemaWC",  "Grid",  AV23GridConfiguration,  false) ;
         AV25GridColumns = AV23GridConfiguration.gxTpr_Gridcolumns;
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV25GridColumns.Count )
         {
            AV26GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV25GridColumns.Item(AV39GXV1));
            if ( ! AV26GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV26GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
               {
                  AV27GridColumnVisible_UsuarioSistemaId = false;
               }
               else if ( StringUtil.StrCmp(AV26GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
               {
                  AV28GridColumnVisible_UsuarioSistemaIdentidad = false;
               }
               else if ( StringUtil.StrCmp(AV26GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
               {
                  AV29GridColumnVisible_UsuarioSistemaNombre = false;
               }
               else if ( StringUtil.StrCmp(AV26GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
               {
                  AV30GridColumnVisible_UsuarioSistemaGerencia = false;
               }
               else if ( StringUtil.StrCmp(AV26GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
               {
                  AV31GridColumnVisible_UsuarioSistemaDepartamento = false;
               }
               else if ( StringUtil.StrCmp(AV26GridColumn.gxTpr_Attributename, "DireccionDescripcion") == 0 )
               {
                  AV32GridColumnVisible_DireccionDescripcion = false;
               }
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV25GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV26GridColumn.gxTpr_Attributename = "UsuarioSistemaId";
         AV26GridColumn.gxTpr_Columntitle = "Usuario Sistema:";
         AV26GridColumn.gxTpr_Showattribute = true;
         AV25GridColumns.Add(AV26GridColumn, 0);
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV26GridColumn.gxTpr_Attributename = "UsuarioSistemaIdentidad";
         AV26GridColumn.gxTpr_Columntitle = "Identidad";
         AV26GridColumn.gxTpr_Showattribute = true;
         AV25GridColumns.Add(AV26GridColumn, 0);
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV26GridColumn.gxTpr_Attributename = "UsuarioSistemaNombre";
         AV26GridColumn.gxTpr_Columntitle = "Nombre";
         AV26GridColumn.gxTpr_Showattribute = true;
         AV25GridColumns.Add(AV26GridColumn, 0);
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV26GridColumn.gxTpr_Attributename = "UsuarioSistemaGerencia";
         AV26GridColumn.gxTpr_Columntitle = "Gerencia";
         AV26GridColumn.gxTpr_Showattribute = true;
         AV25GridColumns.Add(AV26GridColumn, 0);
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV26GridColumn.gxTpr_Attributename = "UsuarioSistemaDepartamento";
         AV26GridColumn.gxTpr_Columntitle = "Departamento";
         AV26GridColumn.gxTpr_Showattribute = true;
         AV25GridColumns.Add(AV26GridColumn, 0);
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV26GridColumn.gxTpr_Attributename = "DireccionDescripcion";
         AV26GridColumn.gxTpr_Columntitle = "Direccion Descripcion";
         AV26GridColumn.gxTpr_Showattribute = true;
         AV25GridColumns.Add(AV26GridColumn, 0);
         AV23GridConfiguration.gxTpr_Gridcolumns = AV25GridColumns;
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
         AV34OutFile = "";
         AV33Context = new SdtK2BContext(context);
         AV22File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P005X2_A260DepartamentoId = new short[1] ;
         P005X2_A259CentrodecostoId = new string[] {""} ;
         P005X2_A261DepartamentoNombre = new string[] {""} ;
         A259CentrodecostoId = "";
         A261DepartamentoNombre = "";
         lV11UsuarioSistemaIdentidad = "";
         A101UsuarioSistemaIdentidad = "";
         A99UsuarioSistemaId = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         A262DireccionDescripcion = "";
         P005X3_A258DireccionId = new short[1] ;
         P005X3_A257UsuarioSistemaDepartamento = new string[] {""} ;
         P005X3_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         P005X3_A263UsuarioSistemaGerencia = new string[] {""} ;
         P005X3_n263UsuarioSistemaGerencia = new bool[] {false} ;
         P005X3_A100UsuarioSistemaNombre = new string[] {""} ;
         P005X3_A99UsuarioSistemaId = new string[] {""} ;
         P005X3_A101UsuarioSistemaIdentidad = new string[] {""} ;
         P005X3_A260DepartamentoId = new short[1] ;
         P005X3_A259CentrodecostoId = new string[] {""} ;
         P005X4_A262DireccionDescripcion = new string[] {""} ;
         AV20ErrorMessage = "";
         AV23GridConfiguration = new SdtK2BGridConfiguration(context);
         AV25GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV26GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.exportdeptousuariosistemawc__datastore2(),
            new Object[][] {
                new Object[] {
               P005X2_A260DepartamentoId, P005X2_A259CentrodecostoId, P005X2_A261DepartamentoNombre
               }
               , new Object[] {
               P005X4_A262DireccionDescripcion
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportdeptousuariosistemawc__default(),
            new Object[][] {
                new Object[] {
               P005X3_A258DireccionId, P005X3_A257UsuarioSistemaDepartamento, P005X3_n257UsuarioSistemaDepartamento, P005X3_A263UsuarioSistemaGerencia, P005X3_n263UsuarioSistemaGerencia, P005X3_A100UsuarioSistemaNombre, P005X3_A99UsuarioSistemaId, P005X3_A101UsuarioSistemaIdentidad, P005X3_A260DepartamentoId, P005X3_A259CentrodecostoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9DepartamentoId ;
      private short AV13OrderedBy ;
      private short A260DepartamentoId ;
      private short AV18ColumnIndex ;
      private short A258DireccionId ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int AV39GXV1 ;
      private string AV10K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV27GridColumnVisible_UsuarioSistemaId ;
      private bool AV28GridColumnVisible_UsuarioSistemaIdentidad ;
      private bool AV29GridColumnVisible_UsuarioSistemaNombre ;
      private bool AV30GridColumnVisible_UsuarioSistemaGerencia ;
      private bool AV31GridColumnVisible_UsuarioSistemaDepartamento ;
      private bool AV32GridColumnVisible_DireccionDescripcion ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool n263UsuarioSistemaGerencia ;
      private string AV8CentrodecostoId ;
      private string AV11UsuarioSistemaIdentidad ;
      private string AV12DireccionDescripcion ;
      private string AV34OutFile ;
      private string A259CentrodecostoId ;
      private string A261DepartamentoNombre ;
      private string lV11UsuarioSistemaIdentidad ;
      private string A101UsuarioSistemaIdentidad ;
      private string A99UsuarioSistemaId ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A262DireccionDescripcion ;
      private string AV20ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore2 ;
      private short[] P005X2_A260DepartamentoId ;
      private string[] P005X2_A259CentrodecostoId ;
      private string[] P005X2_A261DepartamentoNombre ;
      private IDataStoreProvider pr_default ;
      private short[] P005X3_A258DireccionId ;
      private string[] P005X3_A257UsuarioSistemaDepartamento ;
      private bool[] P005X3_n257UsuarioSistemaDepartamento ;
      private string[] P005X3_A263UsuarioSistemaGerencia ;
      private bool[] P005X3_n263UsuarioSistemaGerencia ;
      private string[] P005X3_A100UsuarioSistemaNombre ;
      private string[] P005X3_A99UsuarioSistemaId ;
      private string[] P005X3_A101UsuarioSistemaIdentidad ;
      private short[] P005X3_A260DepartamentoId ;
      private string[] P005X3_A259CentrodecostoId ;
      private string[] P005X4_A262DireccionDescripcion ;
      private string aP6_OutFile ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV25GridColumns ;
      private GxFile AV22File ;
      private SdtK2BGridConfiguration AV23GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV26GridColumn ;
      private SdtK2BContext AV33Context ;
   }

   public class exportdeptousuariosistemawc__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("@AV8CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@AV9DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmP005X4;
          prmP005X4 = new Object[] {
          new ParDef("@DireccionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "SELECT TOP 1 [DepartamentoId], [CentrodecostoId], [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @AV8CentrodecostoId and [DepartamentoId] = @AV9DepartamentoId ORDER BY [CentrodecostoId], [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005X4", "SELECT [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @DireccionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X4,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class exportdeptousuariosistemawc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P005X3( IGxContext context ,
                                           string AV11UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV13OrderedBy ,
                                           string AV10K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A262DireccionDescripcion ,
                                           string AV12DireccionDescripcion ,
                                           string AV8CentrodecostoId ,
                                           short AV9DepartamentoId ,
                                           string A259CentrodecostoId ,
                                           short A260DepartamentoId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[3];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT [DireccionId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaId], [UsuarioSistemaIdentidad], [DepartamentoId], [CentrodecostoId] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([CentrodecostoId] = @AV8CentrodecostoId and [DepartamentoId] = @AV9DepartamentoId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV11UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int1[2] = 1;
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
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV13OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad] DESC";
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
                   return conditional_P005X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] );
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
        Object[] prmP005X3;
        prmP005X3 = new Object[] {
        new ParDef("@AV8CentrodecostoId",GXType.NVarChar,5,0) ,
        new ParDef("@AV9DepartamentoId",GXType.Int16,4,0) ,
        new ParDef("@lV11UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        def= new CursorDef[] {
            new CursorDef("P005X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X3,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              return;
     }
  }

}

}
