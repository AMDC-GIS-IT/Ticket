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
   public class exportdireccionesusuariosistemawc : GXProcedure
   {
      public exportdireccionesusuariosistemawc( )
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

      public exportdireccionesusuariosistemawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_DireccionId ,
                           string aP1_UsuarioSistemaIdentidad ,
                           string aP2_DepartamentoNombre ,
                           string aP3_K2BToolsGenericSearchField ,
                           short aP4_OrderedBy ,
                           out string aP5_OutFile )
      {
         this.AV8DireccionId = aP0_DireccionId;
         this.AV10UsuarioSistemaIdentidad = aP1_UsuarioSistemaIdentidad;
         this.AV11DepartamentoNombre = aP2_DepartamentoNombre;
         this.AV9K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         this.AV12OrderedBy = aP4_OrderedBy;
         this.AV33OutFile = "" ;
         initialize();
         executePrivate();
         aP5_OutFile=this.AV33OutFile;
      }

      public string executeUdp( short aP0_DireccionId ,
                                string aP1_UsuarioSistemaIdentidad ,
                                string aP2_DepartamentoNombre ,
                                string aP3_K2BToolsGenericSearchField ,
                                short aP4_OrderedBy )
      {
         execute(aP0_DireccionId, aP1_UsuarioSistemaIdentidad, aP2_DepartamentoNombre, aP3_K2BToolsGenericSearchField, aP4_OrderedBy, out aP5_OutFile);
         return AV33OutFile ;
      }

      public void executeSubmit( short aP0_DireccionId ,
                                 string aP1_UsuarioSistemaIdentidad ,
                                 string aP2_DepartamentoNombre ,
                                 string aP3_K2BToolsGenericSearchField ,
                                 short aP4_OrderedBy ,
                                 out string aP5_OutFile )
      {
         exportdireccionesusuariosistemawc objexportdireccionesusuariosistemawc;
         objexportdireccionesusuariosistemawc = new exportdireccionesusuariosistemawc();
         objexportdireccionesusuariosistemawc.AV8DireccionId = aP0_DireccionId;
         objexportdireccionesusuariosistemawc.AV10UsuarioSistemaIdentidad = aP1_UsuarioSistemaIdentidad;
         objexportdireccionesusuariosistemawc.AV11DepartamentoNombre = aP2_DepartamentoNombre;
         objexportdireccionesusuariosistemawc.AV9K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         objexportdireccionesusuariosistemawc.AV12OrderedBy = aP4_OrderedBy;
         objexportdireccionesusuariosistemawc.AV33OutFile = "" ;
         objexportdireccionesusuariosistemawc.context.SetSubmitInitialConfig(context);
         objexportdireccionesusuariosistemawc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportdireccionesusuariosistemawc);
         aP5_OutFile=this.AV33OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportdireccionesusuariosistemawc)stateInfo).executePrivate();
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
         new k2bgetcontext(context ).execute( out  AV32Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV33OutFile = GxDirectory.TemporaryFilesPath + AV21File.Separator + "ExportDireccionesUsuarioSistemaWC-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV13ExcelDocument.Open(AV33OutFile);
         AV13ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Clear();
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Size = 15;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Usuario sistemas";
         AV14CellRow = (int)(AV14CellRow+4);
         /* Using cursor P00612 */
         pr_datastore2.execute(0, new Object[] {AV8DireccionId});
         while ( (pr_datastore2.getStatus(0) != 101) )
         {
            A258DireccionId = P00612_A258DireccionId[0];
            A262DireccionDescripcion = P00612_A262DireccionDescripcion[0];
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Direccion Descripcion";
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A262DireccionDescripcion);
            AV14CellRow = (int)(AV14CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_datastore2.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV14CellRow = (int)(AV14CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuarioSistemaIdentidad)) )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Identidad";
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV10UsuarioSistemaIdentidad);
            AV14CellRow = (int)(AV14CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11DepartamentoNombre)) )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Departamento Nombre";
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV11DepartamentoNombre);
            AV14CellRow = (int)(AV14CellRow+1);
         }
         AV14CellRow = (int)(AV14CellRow+3);
         AV17ColumnIndex = 0;
         if ( AV26GridColumnVisible_UsuarioSistemaId )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = "Usuario Sistema:";
            AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         }
         if ( AV27GridColumnVisible_UsuarioSistemaIdentidad )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = "Identidad";
            AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         }
         if ( AV28GridColumnVisible_UsuarioSistemaNombre )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = "Nombre";
            AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         }
         if ( AV29GridColumnVisible_UsuarioSistemaGerencia )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = "Gerencia";
            AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         }
         if ( AV30GridColumnVisible_UsuarioSistemaDepartamento )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = "Departamento";
            AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_DepartamentoNombre )
         {
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = "Departamento Nombre";
            AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10UsuarioSistemaIdentidad ,
                                              A101UsuarioSistemaIdentidad ,
                                              AV12OrderedBy ,
                                              AV9K2BToolsGenericSearchField ,
                                              A99UsuarioSistemaId ,
                                              A100UsuarioSistemaNombre ,
                                              A263UsuarioSistemaGerencia ,
                                              A257UsuarioSistemaDepartamento ,
                                              A261DepartamentoNombre ,
                                              AV11DepartamentoNombre ,
                                              AV8DireccionId ,
                                              A258DireccionId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV10UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV10UsuarioSistemaIdentidad), "%", "");
         /* Using cursor P00613 */
         pr_default.execute(0, new Object[] {AV8DireccionId, lV10UsuarioSistemaIdentidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A259CentrodecostoId = P00613_A259CentrodecostoId[0];
            A260DepartamentoId = P00613_A260DepartamentoId[0];
            A257UsuarioSistemaDepartamento = P00613_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = P00613_n257UsuarioSistemaDepartamento[0];
            A263UsuarioSistemaGerencia = P00613_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = P00613_n263UsuarioSistemaGerencia[0];
            A100UsuarioSistemaNombre = P00613_A100UsuarioSistemaNombre[0];
            A99UsuarioSistemaId = P00613_A99UsuarioSistemaId[0];
            A101UsuarioSistemaIdentidad = P00613_A101UsuarioSistemaIdentidad[0];
            A258DireccionId = P00613_A258DireccionId[0];
            /* Using cursor P00614 */
            pr_datastore2.execute(1, new Object[] {A259CentrodecostoId, A260DepartamentoId});
            A261DepartamentoNombre = P00614_A261DepartamentoNombre[0];
            pr_datastore2.close(1);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11DepartamentoNombre)) || ( StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( AV11DepartamentoNombre , 300 , "%"),  ' ' ) ) )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV9K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV9K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV9K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV9K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV9K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( "%" + AV9K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV17ColumnIndex = 0;
                  if ( AV26GridColumnVisible_UsuarioSistemaId )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.RTrim( A99UsuarioSistemaId);
                     AV17ColumnIndex = (short)(AV17ColumnIndex+1);
                  }
                  if ( AV27GridColumnVisible_UsuarioSistemaIdentidad )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.RTrim( A101UsuarioSistemaIdentidad);
                     AV17ColumnIndex = (short)(AV17ColumnIndex+1);
                  }
                  if ( AV28GridColumnVisible_UsuarioSistemaNombre )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.RTrim( A100UsuarioSistemaNombre);
                     AV17ColumnIndex = (short)(AV17ColumnIndex+1);
                  }
                  if ( AV29GridColumnVisible_UsuarioSistemaGerencia )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.RTrim( A263UsuarioSistemaGerencia);
                     AV17ColumnIndex = (short)(AV17ColumnIndex+1);
                  }
                  if ( AV30GridColumnVisible_UsuarioSistemaDepartamento )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.RTrim( A257UsuarioSistemaDepartamento);
                     AV17ColumnIndex = (short)(AV17ColumnIndex+1);
                  }
                  if ( AV31GridColumnVisible_DepartamentoNombre )
                  {
                     AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.RTrim( A261DepartamentoNombre);
                     AV17ColumnIndex = (short)(AV17ColumnIndex+1);
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_datastore2.close(1);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV33OutFile = "";
            AV19ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV13ExcelDocument.Close();
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
         new k2bloadgridconfiguration(context ).execute(  "DireccionesUsuarioSistemaWC",  "Grid", ref  AV22GridConfiguration) ;
         AV24GridColumns = AV22GridConfiguration.gxTpr_Gridcolumns;
         AV26GridColumnVisible_UsuarioSistemaId = true;
         AV27GridColumnVisible_UsuarioSistemaIdentidad = true;
         AV28GridColumnVisible_UsuarioSistemaNombre = true;
         AV29GridColumnVisible_UsuarioSistemaGerencia = true;
         AV30GridColumnVisible_UsuarioSistemaDepartamento = true;
         AV31GridColumnVisible_DepartamentoNombre = true;
         new k2bsavegridconfiguration(context ).execute(  "DireccionesUsuarioSistemaWC",  "Grid",  AV22GridConfiguration,  false) ;
         AV24GridColumns = AV22GridConfiguration.gxTpr_Gridcolumns;
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV24GridColumns.Count )
         {
            AV25GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV24GridColumns.Item(AV38GXV1));
            if ( ! AV25GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV25GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
               {
                  AV26GridColumnVisible_UsuarioSistemaId = false;
               }
               else if ( StringUtil.StrCmp(AV25GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
               {
                  AV27GridColumnVisible_UsuarioSistemaIdentidad = false;
               }
               else if ( StringUtil.StrCmp(AV25GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
               {
                  AV28GridColumnVisible_UsuarioSistemaNombre = false;
               }
               else if ( StringUtil.StrCmp(AV25GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
               {
                  AV29GridColumnVisible_UsuarioSistemaGerencia = false;
               }
               else if ( StringUtil.StrCmp(AV25GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
               {
                  AV30GridColumnVisible_UsuarioSistemaDepartamento = false;
               }
               else if ( StringUtil.StrCmp(AV25GridColumn.gxTpr_Attributename, "DepartamentoNombre") == 0 )
               {
                  AV31GridColumnVisible_DepartamentoNombre = false;
               }
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV24GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV25GridColumn.gxTpr_Attributename = "UsuarioSistemaId";
         AV25GridColumn.gxTpr_Columntitle = "Usuario Sistema:";
         AV25GridColumn.gxTpr_Showattribute = true;
         AV24GridColumns.Add(AV25GridColumn, 0);
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV25GridColumn.gxTpr_Attributename = "UsuarioSistemaIdentidad";
         AV25GridColumn.gxTpr_Columntitle = "Identidad";
         AV25GridColumn.gxTpr_Showattribute = true;
         AV24GridColumns.Add(AV25GridColumn, 0);
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV25GridColumn.gxTpr_Attributename = "UsuarioSistemaNombre";
         AV25GridColumn.gxTpr_Columntitle = "Nombre";
         AV25GridColumn.gxTpr_Showattribute = true;
         AV24GridColumns.Add(AV25GridColumn, 0);
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV25GridColumn.gxTpr_Attributename = "UsuarioSistemaGerencia";
         AV25GridColumn.gxTpr_Columntitle = "Gerencia";
         AV25GridColumn.gxTpr_Showattribute = true;
         AV24GridColumns.Add(AV25GridColumn, 0);
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV25GridColumn.gxTpr_Attributename = "UsuarioSistemaDepartamento";
         AV25GridColumn.gxTpr_Columntitle = "Departamento";
         AV25GridColumn.gxTpr_Showattribute = true;
         AV24GridColumns.Add(AV25GridColumn, 0);
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV25GridColumn.gxTpr_Attributename = "DepartamentoNombre";
         AV25GridColumn.gxTpr_Columntitle = "Departamento Nombre";
         AV25GridColumn.gxTpr_Showattribute = true;
         AV24GridColumns.Add(AV25GridColumn, 0);
         AV22GridConfiguration.gxTpr_Gridcolumns = AV24GridColumns;
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
         AV33OutFile = "";
         AV32Context = new SdtK2BContext(context);
         AV21File = new GxFile(context.GetPhysicalPath());
         AV13ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00612_A258DireccionId = new short[1] ;
         P00612_A262DireccionDescripcion = new string[] {""} ;
         A262DireccionDescripcion = "";
         lV10UsuarioSistemaIdentidad = "";
         A101UsuarioSistemaIdentidad = "";
         A99UsuarioSistemaId = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         A261DepartamentoNombre = "";
         P00613_A259CentrodecostoId = new string[] {""} ;
         P00613_A260DepartamentoId = new short[1] ;
         P00613_A257UsuarioSistemaDepartamento = new string[] {""} ;
         P00613_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         P00613_A263UsuarioSistemaGerencia = new string[] {""} ;
         P00613_n263UsuarioSistemaGerencia = new bool[] {false} ;
         P00613_A100UsuarioSistemaNombre = new string[] {""} ;
         P00613_A99UsuarioSistemaId = new string[] {""} ;
         P00613_A101UsuarioSistemaIdentidad = new string[] {""} ;
         P00613_A258DireccionId = new short[1] ;
         A259CentrodecostoId = "";
         P00614_A261DepartamentoNombre = new string[] {""} ;
         AV19ErrorMessage = "";
         AV22GridConfiguration = new SdtK2BGridConfiguration(context);
         AV24GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV25GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.exportdireccionesusuariosistemawc__datastore2(),
            new Object[][] {
                new Object[] {
               P00612_A258DireccionId, P00612_A262DireccionDescripcion
               }
               , new Object[] {
               P00614_A261DepartamentoNombre
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportdireccionesusuariosistemawc__default(),
            new Object[][] {
                new Object[] {
               P00613_A259CentrodecostoId, P00613_A260DepartamentoId, P00613_A257UsuarioSistemaDepartamento, P00613_n257UsuarioSistemaDepartamento, P00613_A263UsuarioSistemaGerencia, P00613_n263UsuarioSistemaGerencia, P00613_A100UsuarioSistemaNombre, P00613_A99UsuarioSistemaId, P00613_A101UsuarioSistemaIdentidad, P00613_A258DireccionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8DireccionId ;
      private short AV12OrderedBy ;
      private short A258DireccionId ;
      private short AV17ColumnIndex ;
      private short A260DepartamentoId ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV38GXV1 ;
      private string AV9K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV26GridColumnVisible_UsuarioSistemaId ;
      private bool AV27GridColumnVisible_UsuarioSistemaIdentidad ;
      private bool AV28GridColumnVisible_UsuarioSistemaNombre ;
      private bool AV29GridColumnVisible_UsuarioSistemaGerencia ;
      private bool AV30GridColumnVisible_UsuarioSistemaDepartamento ;
      private bool AV31GridColumnVisible_DepartamentoNombre ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool n263UsuarioSistemaGerencia ;
      private string AV10UsuarioSistemaIdentidad ;
      private string AV11DepartamentoNombre ;
      private string AV33OutFile ;
      private string A262DireccionDescripcion ;
      private string lV10UsuarioSistemaIdentidad ;
      private string A101UsuarioSistemaIdentidad ;
      private string A99UsuarioSistemaId ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A261DepartamentoNombre ;
      private string A259CentrodecostoId ;
      private string AV19ErrorMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore2 ;
      private short[] P00612_A258DireccionId ;
      private string[] P00612_A262DireccionDescripcion ;
      private IDataStoreProvider pr_default ;
      private string[] P00613_A259CentrodecostoId ;
      private short[] P00613_A260DepartamentoId ;
      private string[] P00613_A257UsuarioSistemaDepartamento ;
      private bool[] P00613_n257UsuarioSistemaDepartamento ;
      private string[] P00613_A263UsuarioSistemaGerencia ;
      private bool[] P00613_n263UsuarioSistemaGerencia ;
      private string[] P00613_A100UsuarioSistemaNombre ;
      private string[] P00613_A99UsuarioSistemaId ;
      private string[] P00613_A101UsuarioSistemaIdentidad ;
      private short[] P00613_A258DireccionId ;
      private string[] P00614_A261DepartamentoNombre ;
      private string aP5_OutFile ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV24GridColumns ;
      private GxFile AV21File ;
      private SdtK2BGridConfiguration AV22GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV25GridColumn ;
      private SdtK2BContext AV32Context ;
   }

   public class exportdireccionesusuariosistemawc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00612;
          prmP00612 = new Object[] {
          new ParDef("@AV8DireccionId",GXType.Int16,4,0)
          };
          Object[] prmP00614;
          prmP00614 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00612", "SELECT TOP 1 [DireccionId], [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @AV8DireccionId ORDER BY [DireccionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00612,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00614", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00614,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class exportdireccionesusuariosistemawc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00613( IGxContext context ,
                                           string AV10UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV12OrderedBy ,
                                           string AV9K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A261DepartamentoNombre ,
                                           string AV11DepartamentoNombre ,
                                           short AV8DireccionId ,
                                           short A258DireccionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[2];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT [CentrodecostoId], [DepartamentoId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaId], [UsuarioSistemaIdentidad], [DireccionId] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([DireccionId] = @AV8DireccionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV10UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int1[1] = 1;
       }
       scmdbuf += sWhereString;
       if ( AV12OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId]";
       }
       else if ( AV12OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
       }
       else if ( AV12OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV12OrderedBy == 3 )
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
                   return conditional_P00613(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
        Object[] prmP00613;
        prmP00613 = new Object[] {
        new ParDef("@AV8DireccionId",GXType.Int16,4,0) ,
        new ParDef("@lV10UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00613", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00613,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((short[]) buf[9])[0] = rslt.getShort(8);
              return;
     }
  }

}

}
