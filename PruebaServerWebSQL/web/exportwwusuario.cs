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
   public class exportwwusuario : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "UsuarioNombre");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV13UsuarioNombre = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV43UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV44UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV42UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
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

      public exportwwusuario( )
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

      public exportwwusuario( IGxContext context )
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

      public void execute( string aP0_UsuarioNombre ,
                           DateTime aP1_UsuarioFecha_From ,
                           DateTime aP2_UsuarioFecha_To ,
                           short aP3_UsuarioId ,
                           string aP4_K2BToolsGenericSearchField ,
                           ref short aP5_OrderedBy )
      {
         this.AV13UsuarioNombre = aP0_UsuarioNombre;
         this.AV43UsuarioFecha_From = aP1_UsuarioFecha_From;
         this.AV44UsuarioFecha_To = aP2_UsuarioFecha_To;
         this.AV42UsuarioId = aP3_UsuarioId;
         this.AV12K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         this.AV20OrderedBy = aP5_OrderedBy;
         initialize();
         executePrivate();
         aP5_OrderedBy=this.AV20OrderedBy;
      }

      public short executeUdp( string aP0_UsuarioNombre ,
                               DateTime aP1_UsuarioFecha_From ,
                               DateTime aP2_UsuarioFecha_To ,
                               short aP3_UsuarioId ,
                               string aP4_K2BToolsGenericSearchField )
      {
         execute(aP0_UsuarioNombre, aP1_UsuarioFecha_From, aP2_UsuarioFecha_To, aP3_UsuarioId, aP4_K2BToolsGenericSearchField, ref aP5_OrderedBy);
         return AV20OrderedBy ;
      }

      public void executeSubmit( string aP0_UsuarioNombre ,
                                 DateTime aP1_UsuarioFecha_From ,
                                 DateTime aP2_UsuarioFecha_To ,
                                 short aP3_UsuarioId ,
                                 string aP4_K2BToolsGenericSearchField ,
                                 ref short aP5_OrderedBy )
      {
         exportwwusuario objexportwwusuario;
         objexportwwusuario = new exportwwusuario();
         objexportwwusuario.AV13UsuarioNombre = aP0_UsuarioNombre;
         objexportwwusuario.AV43UsuarioFecha_From = aP1_UsuarioFecha_From;
         objexportwwusuario.AV44UsuarioFecha_To = aP2_UsuarioFecha_To;
         objexportwwusuario.AV42UsuarioId = aP3_UsuarioId;
         objexportwwusuario.AV12K2BToolsGenericSearchField = aP4_K2BToolsGenericSearchField;
         objexportwwusuario.AV20OrderedBy = aP5_OrderedBy;
         objexportwwusuario.context.SetSubmitInitialConfig(context);
         objexportwwusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwusuario);
         aP5_OrderedBy=this.AV20OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwusuario)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Usuario",  "Usuario",  "List",  "",  "WWUsuario") )
         {
            AV26Filename = "";
            AV27ErrorMessage = "You are not authorized to do activity";
            AV27ErrorMessage += "EntityName:" + "Usuario";
            AV27ErrorMessage += "TransactionName:" + "Usuario";
            AV27ErrorMessage += "ActivityType:" + "";
            AV27ErrorMessage += "PgmName:" + AV47Pgmname;
            AV28HttpResponse.AddString(AV27ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV40Context) ;
         AV24Random = (int)(NumberUtil.Random( )*10000);
         AV26Filename = GxDirectory.TemporaryFilesPath + AV29File.Separator + "ExportWWUsuario-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV24Random), 8, 0)) + ".xlsx";
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
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Text = "Usuarios";
         AV22CellRow = (int)(AV22CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13UsuarioNombre)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Usuario:";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV13UsuarioNombre);
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV43UsuarioFecha_From) || ! (DateTime.MinValue==AV44UsuarioFecha_To) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Fecha Inicio:";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV43UsuarioFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV44UsuarioFecha_To, 2, "/");
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (0==AV42UsuarioId) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Id Usuario:";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Number = AV42UsuarioId;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         AV22CellRow = (int)(AV22CellRow+3);
         AV25ColumnIndex = 0;
         if ( AV30GridColumnVisible_UsuarioId )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Id Usuario:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_UsuarioNombre )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Usuario:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_UsuarioFecha )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Fecha Inicio:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_UsuarioHora )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Hora Inicio:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_UsuarioGerencia )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Gerencia:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV35GridColumnVisible_UsuarioDepartamento )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Departamento:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_UsuarioRequerimiento )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Descripción del Requerimiento:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_UsuarioEmail )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Email:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_UsuarioTelefono )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "Teléfono:";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13UsuarioNombre ,
                                              AV44UsuarioFecha_To ,
                                              AV43UsuarioFecha_From ,
                                              AV42UsuarioId ,
                                              AV12K2BToolsGenericSearchField ,
                                              A93UsuarioNombre ,
                                              A90UsuarioFecha ,
                                              A15UsuarioId ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A94UsuarioRequerimiento ,
                                              A89UsuarioEmail ,
                                              A95UsuarioTelefono ,
                                              AV20OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV13UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV13UsuarioNombre), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003I2 */
         pr_default.execute(0, new Object[] {lV13UsuarioNombre, AV44UsuarioFecha_To, AV43UsuarioFecha_From, AV42UsuarioId, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A95UsuarioTelefono = P003I2_A95UsuarioTelefono[0];
            A89UsuarioEmail = P003I2_A89UsuarioEmail[0];
            A94UsuarioRequerimiento = P003I2_A94UsuarioRequerimiento[0];
            A88UsuarioDepartamento = P003I2_A88UsuarioDepartamento[0];
            A91UsuarioGerencia = P003I2_A91UsuarioGerencia[0];
            A15UsuarioId = P003I2_A15UsuarioId[0];
            A90UsuarioFecha = P003I2_A90UsuarioFecha[0];
            A93UsuarioNombre = P003I2_A93UsuarioNombre[0];
            A92UsuarioHora = P003I2_A92UsuarioHora[0];
            AV22CellRow = (int)(AV22CellRow+1);
            AV25ColumnIndex = 0;
            if ( AV30GridColumnVisible_UsuarioId )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A15UsuarioId;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_UsuarioNombre )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_UsuarioFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A90UsuarioFecha ) ;
               AV21ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_UsuarioHora )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = context.localUtil.Format( A92UsuarioHora, "99:99");
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_UsuarioGerencia )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A91UsuarioGerencia);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV35GridColumnVisible_UsuarioDepartamento )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A88UsuarioDepartamento);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_UsuarioRequerimiento )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_UsuarioEmail )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A89UsuarioEmail);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_UsuarioTelefono )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A95UsuarioTelefono;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
            AV28HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportWWUsuario.xlsx");
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
         new k2bloadgridconfiguration(context ).execute(  "WWUsuario",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV30GridColumnVisible_UsuarioId = true;
         AV31GridColumnVisible_UsuarioNombre = true;
         AV32GridColumnVisible_UsuarioFecha = true;
         AV33GridColumnVisible_UsuarioHora = true;
         AV34GridColumnVisible_UsuarioGerencia = true;
         AV35GridColumnVisible_UsuarioDepartamento = true;
         AV36GridColumnVisible_UsuarioRequerimiento = true;
         AV37GridColumnVisible_UsuarioEmail = true;
         AV38GridColumnVisible_UsuarioTelefono = true;
         new k2bsavegridconfiguration(context ).execute(  "WWUsuario",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV49GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV30GridColumnVisible_UsuarioId = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV31GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  AV32GridColumnVisible_UsuarioFecha = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioHora") == 0 )
               {
                  AV33GridColumnVisible_UsuarioHora = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioGerencia") == 0 )
               {
                  AV34GridColumnVisible_UsuarioGerencia = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
               {
                  AV35GridColumnVisible_UsuarioDepartamento = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV36GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioEmail") == 0 )
               {
                  AV37GridColumnVisible_UsuarioEmail = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "UsuarioTelefono") == 0 )
               {
                  AV38GridColumnVisible_UsuarioTelefono = false;
               }
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioId";
         AV11GridColumn.gxTpr_Columntitle = "Id Usuario:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV11GridColumn.gxTpr_Columntitle = "Usuario:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV11GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioHora";
         AV11GridColumn.gxTpr_Columntitle = "Hora Inicio:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioGerencia";
         AV11GridColumn.gxTpr_Columntitle = "Gerencia:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioDepartamento";
         AV11GridColumn.gxTpr_Columntitle = "Departamento:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV11GridColumn.gxTpr_Columntitle = "Descripción del Requerimiento:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioEmail";
         AV11GridColumn.gxTpr_Columntitle = "Email:";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "UsuarioTelefono";
         AV11GridColumn.gxTpr_Columntitle = "Teléfono:";
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
         AV47Pgmname = "";
         AV28HttpResponse = new GxHttpResponse( context);
         AV40Context = new SdtK2BContext(context);
         AV29File = new GxFile(context.GetPhysicalPath());
         AV21ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV13UsuarioNombre = "";
         lV12K2BToolsGenericSearchField = "";
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         P003I2_A95UsuarioTelefono = new int[1] ;
         P003I2_A89UsuarioEmail = new string[] {""} ;
         P003I2_A94UsuarioRequerimiento = new string[] {""} ;
         P003I2_A88UsuarioDepartamento = new string[] {""} ;
         P003I2_A91UsuarioGerencia = new string[] {""} ;
         P003I2_A15UsuarioId = new short[1] ;
         P003I2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P003I2_A93UsuarioNombre = new string[] {""} ;
         P003I2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwusuario__default(),
            new Object[][] {
                new Object[] {
               P003I2_A95UsuarioTelefono, P003I2_A89UsuarioEmail, P003I2_A94UsuarioRequerimiento, P003I2_A88UsuarioDepartamento, P003I2_A91UsuarioGerencia, P003I2_A15UsuarioId, P003I2_A90UsuarioFecha, P003I2_A93UsuarioNombre, P003I2_A92UsuarioHora
               }
            }
         );
         AV47Pgmname = "ExportWWUsuario";
         /* GeneXus formulas. */
         AV47Pgmname = "ExportWWUsuario";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV42UsuarioId ;
      private short AV20OrderedBy ;
      private short GxWebError ;
      private short AV25ColumnIndex ;
      private short A15UsuarioId ;
      private int AV24Random ;
      private int AV22CellRow ;
      private int AV23FirstColumn ;
      private int A95UsuarioTelefono ;
      private int AV49GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV12K2BToolsGenericSearchField ;
      private string AV47Pgmname ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private DateTime A92UsuarioHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV43UsuarioFecha_From ;
      private DateTime AV44UsuarioFecha_To ;
      private DateTime A90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV30GridColumnVisible_UsuarioId ;
      private bool AV31GridColumnVisible_UsuarioNombre ;
      private bool AV32GridColumnVisible_UsuarioFecha ;
      private bool AV33GridColumnVisible_UsuarioHora ;
      private bool AV34GridColumnVisible_UsuarioGerencia ;
      private bool AV35GridColumnVisible_UsuarioDepartamento ;
      private bool AV36GridColumnVisible_UsuarioRequerimiento ;
      private bool AV37GridColumnVisible_UsuarioEmail ;
      private bool AV38GridColumnVisible_UsuarioTelefono ;
      private string AV13UsuarioNombre ;
      private string AV26Filename ;
      private string AV27ErrorMessage ;
      private string lV13UsuarioNombre ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP5_OrderedBy ;
      private IDataStoreProvider pr_default ;
      private int[] P003I2_A95UsuarioTelefono ;
      private string[] P003I2_A89UsuarioEmail ;
      private string[] P003I2_A94UsuarioRequerimiento ;
      private string[] P003I2_A88UsuarioDepartamento ;
      private string[] P003I2_A91UsuarioGerencia ;
      private short[] P003I2_A15UsuarioId ;
      private DateTime[] P003I2_A90UsuarioFecha ;
      private string[] P003I2_A93UsuarioNombre ;
      private DateTime[] P003I2_A92UsuarioHora ;
      private GxHttpResponse AV28HttpResponse ;
      private ExcelDocumentI AV21ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV29File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV40Context ;
   }

   public class exportwwusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003I2( IGxContext context ,
                                             string AV13UsuarioNombre ,
                                             DateTime AV44UsuarioFecha_To ,
                                             DateTime AV43UsuarioFecha_From ,
                                             short AV42UsuarioId ,
                                             string AV12K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             short A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV20OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [UsuarioTelefono], [UsuarioEmail], [UsuarioRequerimiento], [UsuarioDepartamento], [UsuarioGerencia], [UsuarioId], [UsuarioFecha], [UsuarioNombre], [UsuarioHora] FROM [Usuario]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV13UsuarioNombre)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV44UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV44UsuarioFecha_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV43UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV43UsuarioFecha_From)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV42UsuarioId) )
         {
            AddWhere(sWhereString, "([UsuarioId] = @AV42UsuarioId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([UsuarioId] AS decimal(4,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioNombre] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV12K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV20OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [UsuarioId]";
         }
         else if ( AV20OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [UsuarioId] DESC";
         }
         else if ( AV20OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [UsuarioNombre]";
         }
         else if ( AV20OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [UsuarioNombre] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P003I2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP003I2;
          prmP003I2 = new Object[] {
          new ParDef("@lV13UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV44UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV43UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV42UsuarioId",GXType.Int16,4,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
                return;
       }
    }

 }

}
