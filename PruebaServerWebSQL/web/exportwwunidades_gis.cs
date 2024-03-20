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
   public class exportwwunidades_gis : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "nombre_unidad");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV13nombre_unidad = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15unidades_gisfecha_creacion_From = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_creacion_From"));
                  AV16unidades_gisfecha_creacion_To = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_creacion_To"));
                  AV18unidades_gisfecha_modificacion_From = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_modificacion_From"));
                  AV19unidades_gisfecha_modificacion_To = context.localUtil.ParseDateParm( GetPar( "unidades_gisfecha_modificacion_To"));
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

      public exportwwunidades_gis( )
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

      public exportwwunidades_gis( IGxContext context )
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

      public void execute( string aP0_nombre_unidad ,
                           DateTime aP1_unidades_gisfecha_creacion_From ,
                           DateTime aP2_unidades_gisfecha_creacion_To ,
                           DateTime aP3_unidades_gisfecha_modificacion_From ,
                           DateTime aP4_unidades_gisfecha_modificacion_To ,
                           string aP5_K2BToolsGenericSearchField ,
                           ref short aP6_OrderedBy )
      {
         this.AV13nombre_unidad = aP0_nombre_unidad;
         this.AV15unidades_gisfecha_creacion_From = aP1_unidades_gisfecha_creacion_From;
         this.AV16unidades_gisfecha_creacion_To = aP2_unidades_gisfecha_creacion_To;
         this.AV18unidades_gisfecha_modificacion_From = aP3_unidades_gisfecha_modificacion_From;
         this.AV19unidades_gisfecha_modificacion_To = aP4_unidades_gisfecha_modificacion_To;
         this.AV12K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         this.AV20OrderedBy = aP6_OrderedBy;
         initialize();
         executePrivate();
         aP6_OrderedBy=this.AV20OrderedBy;
      }

      public short executeUdp( string aP0_nombre_unidad ,
                               DateTime aP1_unidades_gisfecha_creacion_From ,
                               DateTime aP2_unidades_gisfecha_creacion_To ,
                               DateTime aP3_unidades_gisfecha_modificacion_From ,
                               DateTime aP4_unidades_gisfecha_modificacion_To ,
                               string aP5_K2BToolsGenericSearchField )
      {
         execute(aP0_nombre_unidad, aP1_unidades_gisfecha_creacion_From, aP2_unidades_gisfecha_creacion_To, aP3_unidades_gisfecha_modificacion_From, aP4_unidades_gisfecha_modificacion_To, aP5_K2BToolsGenericSearchField, ref aP6_OrderedBy);
         return AV20OrderedBy ;
      }

      public void executeSubmit( string aP0_nombre_unidad ,
                                 DateTime aP1_unidades_gisfecha_creacion_From ,
                                 DateTime aP2_unidades_gisfecha_creacion_To ,
                                 DateTime aP3_unidades_gisfecha_modificacion_From ,
                                 DateTime aP4_unidades_gisfecha_modificacion_To ,
                                 string aP5_K2BToolsGenericSearchField ,
                                 ref short aP6_OrderedBy )
      {
         exportwwunidades_gis objexportwwunidades_gis;
         objexportwwunidades_gis = new exportwwunidades_gis();
         objexportwwunidades_gis.AV13nombre_unidad = aP0_nombre_unidad;
         objexportwwunidades_gis.AV15unidades_gisfecha_creacion_From = aP1_unidades_gisfecha_creacion_From;
         objexportwwunidades_gis.AV16unidades_gisfecha_creacion_To = aP2_unidades_gisfecha_creacion_To;
         objexportwwunidades_gis.AV18unidades_gisfecha_modificacion_From = aP3_unidades_gisfecha_modificacion_From;
         objexportwwunidades_gis.AV19unidades_gisfecha_modificacion_To = aP4_unidades_gisfecha_modificacion_To;
         objexportwwunidades_gis.AV12K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         objexportwwunidades_gis.AV20OrderedBy = aP6_OrderedBy;
         objexportwwunidades_gis.context.SetSubmitInitialConfig(context);
         objexportwwunidades_gis.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwunidades_gis);
         aP6_OrderedBy=this.AV20OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwunidades_gis)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "unidades_gis",  "unidades_gis",  "List",  "",  "WWunidades_gis") )
         {
            AV26Filename = "";
            AV27ErrorMessage = "You are not authorized to do activity";
            AV27ErrorMessage += "EntityName:" + "unidades_gis";
            AV27ErrorMessage += "TransactionName:" + "unidades_gis";
            AV27ErrorMessage += "ActivityType:" + "";
            AV27ErrorMessage += "PgmName:" + AV42Pgmname;
            AV28HttpResponse.AddString(AV27ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV39Context) ;
         AV24Random = (int)(NumberUtil.Random( )*10000);
         AV26Filename = GxDirectory.TemporaryFilesPath + AV29File.Separator + "ExportWWunidades_gis-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV24Random), 8, 0)) + ".xlsx";
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
         AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn, 1, 1).Text = "unidades_gises";
         AV22CellRow = (int)(AV22CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = AV12K2BToolsGenericSearchField;
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13nombre_unidad)) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "nombre_unidad";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV13nombre_unidad);
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV15unidades_gisfecha_creacion_From) || ! (DateTime.MinValue==AV16unidades_gisfecha_creacion_To) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "fecha_creacion";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV15unidades_gisfecha_creacion_From, 2, "/")+" - "+context.localUtil.DToC( AV16unidades_gisfecha_creacion_To, 2, "/");
            AV22CellRow = (int)(AV22CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV18unidades_gisfecha_modificacion_From) || ! (DateTime.MinValue==AV19unidades_gisfecha_modificacion_To) )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+0, 1, 1).Text = "fecha_modificacion";
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV18unidades_gisfecha_modificacion_From, 2, "/")+" - "+context.localUtil.DToC( AV19unidades_gisfecha_modificacion_To, 2, "/");
            AV22CellRow = (int)(AV22CellRow+1);
         }
         AV22CellRow = (int)(AV22CellRow+3);
         AV25ColumnIndex = 0;
         if ( AV30GridColumnVisible_id_unidad )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "id_unidad";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_nombre_unidad )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "nombre_unidad";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_unidades_gisestado )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "estado";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_unidades_gisfecha_creacion )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "fecha_creacion";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_unidades_gishora_creacion )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "hora_creacion";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV35GridColumnVisible_unidades_giscreado_por )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "creado_por";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_unidades_gisfecha_modificacion )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "fecha_modificacion";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_unidades_gishora_modificacion )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "hora_modificacion";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_unidades_gismodificado_por )
         {
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Bold = 1;
            AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = "modificado_por";
            AV25ColumnIndex = (short)(AV25ColumnIndex+1);
         }
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV13nombre_unidad ,
                                              AV16unidades_gisfecha_creacion_To ,
                                              AV15unidades_gisfecha_creacion_From ,
                                              AV19unidades_gisfecha_modificacion_To ,
                                              AV18unidades_gisfecha_modificacion_From ,
                                              AV12K2BToolsGenericSearchField ,
                                              A114nombre_unidad ,
                                              A116unidades_gisfecha_creacion ,
                                              A119unidades_gisfecha_modificacion ,
                                              A103id_unidad ,
                                              A115unidades_gisestado ,
                                              A117unidades_gishora_creacion ,
                                              A118unidades_giscreado_por ,
                                              A120unidades_gishora_modificacion ,
                                              A121unidades_gismodificado_por ,
                                              AV20OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV13nombre_unidad = StringUtil.Concat( StringUtil.RTrim( AV13nombre_unidad), "%", "");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         lV12K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV12K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P005M2 */
         pr_datastore1.execute(0, new Object[] {lV13nombre_unidad, AV16unidades_gisfecha_creacion_To, AV15unidades_gisfecha_creacion_From, AV19unidades_gisfecha_modificacion_To, AV18unidades_gisfecha_modificacion_From, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField, lV12K2BToolsGenericSearchField});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A121unidades_gismodificado_por = P005M2_A121unidades_gismodificado_por[0];
            n121unidades_gismodificado_por = P005M2_n121unidades_gismodificado_por[0];
            A120unidades_gishora_modificacion = P005M2_A120unidades_gishora_modificacion[0];
            n120unidades_gishora_modificacion = P005M2_n120unidades_gishora_modificacion[0];
            A118unidades_giscreado_por = P005M2_A118unidades_giscreado_por[0];
            n118unidades_giscreado_por = P005M2_n118unidades_giscreado_por[0];
            A117unidades_gishora_creacion = P005M2_A117unidades_gishora_creacion[0];
            n117unidades_gishora_creacion = P005M2_n117unidades_gishora_creacion[0];
            A115unidades_gisestado = P005M2_A115unidades_gisestado[0];
            n115unidades_gisestado = P005M2_n115unidades_gisestado[0];
            A103id_unidad = P005M2_A103id_unidad[0];
            A119unidades_gisfecha_modificacion = P005M2_A119unidades_gisfecha_modificacion[0];
            n119unidades_gisfecha_modificacion = P005M2_n119unidades_gisfecha_modificacion[0];
            A116unidades_gisfecha_creacion = P005M2_A116unidades_gisfecha_creacion[0];
            n116unidades_gisfecha_creacion = P005M2_n116unidades_gisfecha_creacion[0];
            A114nombre_unidad = P005M2_A114nombre_unidad[0];
            n114nombre_unidad = P005M2_n114nombre_unidad[0];
            AV22CellRow = (int)(AV22CellRow+1);
            AV25ColumnIndex = 0;
            if ( AV30GridColumnVisible_id_unidad )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A103id_unidad;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_nombre_unidad )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A114nombre_unidad);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_unidades_gisestado )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A115unidades_gisestado;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_unidades_gisfecha_creacion )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A116unidades_gisfecha_creacion ) ;
               AV21ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_unidades_gishora_creacion )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A117unidades_gishora_creacion;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV35GridColumnVisible_unidades_giscreado_por )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A118unidades_giscreado_por);
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_unidades_gisfecha_modificacion )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A119unidades_gisfecha_modificacion ) ;
               AV21ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_unidades_gishora_modificacion )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Number = A120unidades_gishora_modificacion;
               AV25ColumnIndex = (short)(AV25ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_unidades_gismodificado_por )
            {
               AV21ExcelDocument.get_Cells(AV22CellRow, AV23FirstColumn+AV25ColumnIndex, 1, 1).Text = StringUtil.RTrim( A121unidades_gismodificado_por);
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
            AV28HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportWWunidades_gis.xlsx");
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
         new k2bloadgridconfiguration(context ).execute(  "WWunidades_gis",  "Grid", ref  AV8GridConfiguration) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV30GridColumnVisible_id_unidad = true;
         AV31GridColumnVisible_nombre_unidad = true;
         AV32GridColumnVisible_unidades_gisestado = true;
         AV33GridColumnVisible_unidades_gisfecha_creacion = true;
         AV34GridColumnVisible_unidades_gishora_creacion = true;
         AV35GridColumnVisible_unidades_giscreado_por = true;
         AV36GridColumnVisible_unidades_gisfecha_modificacion = true;
         AV37GridColumnVisible_unidades_gishora_modificacion = true;
         AV38GridColumnVisible_unidades_gismodificado_por = true;
         new k2bsavegridconfiguration(context ).execute(  "WWunidades_gis",  "Grid",  AV8GridConfiguration,  false) ;
         AV10GridColumns = AV8GridConfiguration.gxTpr_Gridcolumns;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV10GridColumns.Count )
         {
            AV11GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridColumns.Item(AV44GXV1));
            if ( ! AV11GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "id_unidad") == 0 )
               {
                  AV30GridColumnVisible_id_unidad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "nombre_unidad") == 0 )
               {
                  AV31GridColumnVisible_nombre_unidad = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_gisestado") == 0 )
               {
                  AV32GridColumnVisible_unidades_gisestado = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_gisfecha_creacion") == 0 )
               {
                  AV33GridColumnVisible_unidades_gisfecha_creacion = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_gishora_creacion") == 0 )
               {
                  AV34GridColumnVisible_unidades_gishora_creacion = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_giscreado_por") == 0 )
               {
                  AV35GridColumnVisible_unidades_giscreado_por = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_gisfecha_modificacion") == 0 )
               {
                  AV36GridColumnVisible_unidades_gisfecha_modificacion = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_gishora_modificacion") == 0 )
               {
                  AV37GridColumnVisible_unidades_gishora_modificacion = false;
               }
               else if ( StringUtil.StrCmp(AV11GridColumn.gxTpr_Attributename, "unidades_gismodificado_por") == 0 )
               {
                  AV38GridColumnVisible_unidades_gismodificado_por = false;
               }
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "id_unidad";
         AV11GridColumn.gxTpr_Columntitle = "id_unidad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "nombre_unidad";
         AV11GridColumn.gxTpr_Columntitle = "nombre_unidad";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_gisestado";
         AV11GridColumn.gxTpr_Columntitle = "estado";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_gisfecha_creacion";
         AV11GridColumn.gxTpr_Columntitle = "fecha_creacion";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_gishora_creacion";
         AV11GridColumn.gxTpr_Columntitle = "hora_creacion";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_giscreado_por";
         AV11GridColumn.gxTpr_Columntitle = "creado_por";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_gisfecha_modificacion";
         AV11GridColumn.gxTpr_Columntitle = "fecha_modificacion";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_gishora_modificacion";
         AV11GridColumn.gxTpr_Columntitle = "hora_modificacion";
         AV11GridColumn.gxTpr_Showattribute = true;
         AV10GridColumns.Add(AV11GridColumn, 0);
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV11GridColumn.gxTpr_Attributename = "unidades_gismodificado_por";
         AV11GridColumn.gxTpr_Columntitle = "modificado_por";
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
         AV42Pgmname = "";
         AV28HttpResponse = new GxHttpResponse( context);
         AV39Context = new SdtK2BContext(context);
         AV29File = new GxFile(context.GetPhysicalPath());
         AV21ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV13nombre_unidad = "";
         lV12K2BToolsGenericSearchField = "";
         A114nombre_unidad = "";
         A116unidades_gisfecha_creacion = DateTime.MinValue;
         A119unidades_gisfecha_modificacion = DateTime.MinValue;
         A118unidades_giscreado_por = "";
         A121unidades_gismodificado_por = "";
         P005M2_A121unidades_gismodificado_por = new string[] {""} ;
         P005M2_n121unidades_gismodificado_por = new bool[] {false} ;
         P005M2_A120unidades_gishora_modificacion = new int[1] ;
         P005M2_n120unidades_gishora_modificacion = new bool[] {false} ;
         P005M2_A118unidades_giscreado_por = new string[] {""} ;
         P005M2_n118unidades_giscreado_por = new bool[] {false} ;
         P005M2_A117unidades_gishora_creacion = new int[1] ;
         P005M2_n117unidades_gishora_creacion = new bool[] {false} ;
         P005M2_A115unidades_gisestado = new int[1] ;
         P005M2_n115unidades_gisestado = new bool[] {false} ;
         P005M2_A103id_unidad = new int[1] ;
         P005M2_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         P005M2_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         P005M2_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         P005M2_n116unidades_gisfecha_creacion = new bool[] {false} ;
         P005M2_A114nombre_unidad = new string[] {""} ;
         P005M2_n114nombre_unidad = new bool[] {false} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV8GridConfiguration = new SdtK2BGridConfiguration(context);
         AV10GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV11GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.exportwwunidades_gis__datastore1(),
            new Object[][] {
                new Object[] {
               P005M2_A121unidades_gismodificado_por, P005M2_n121unidades_gismodificado_por, P005M2_A120unidades_gishora_modificacion, P005M2_n120unidades_gishora_modificacion, P005M2_A118unidades_giscreado_por, P005M2_n118unidades_giscreado_por, P005M2_A117unidades_gishora_creacion, P005M2_n117unidades_gishora_creacion, P005M2_A115unidades_gisestado, P005M2_n115unidades_gisestado,
               P005M2_A103id_unidad, P005M2_A119unidades_gisfecha_modificacion, P005M2_n119unidades_gisfecha_modificacion, P005M2_A116unidades_gisfecha_creacion, P005M2_n116unidades_gisfecha_creacion, P005M2_A114nombre_unidad, P005M2_n114nombre_unidad
               }
            }
         );
         AV42Pgmname = "ExportWWunidades_gis";
         /* GeneXus formulas. */
         AV42Pgmname = "ExportWWunidades_gis";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV20OrderedBy ;
      private short GxWebError ;
      private short AV25ColumnIndex ;
      private int AV24Random ;
      private int AV22CellRow ;
      private int AV23FirstColumn ;
      private int A103id_unidad ;
      private int A115unidades_gisestado ;
      private int A117unidades_gishora_creacion ;
      private int A120unidades_gishora_modificacion ;
      private int AV44GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV12K2BToolsGenericSearchField ;
      private string AV42Pgmname ;
      private string scmdbuf ;
      private string lV12K2BToolsGenericSearchField ;
      private DateTime GXt_dtime1 ;
      private DateTime AV15unidades_gisfecha_creacion_From ;
      private DateTime AV16unidades_gisfecha_creacion_To ;
      private DateTime AV18unidades_gisfecha_modificacion_From ;
      private DateTime AV19unidades_gisfecha_modificacion_To ;
      private DateTime A116unidades_gisfecha_creacion ;
      private DateTime A119unidades_gisfecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV30GridColumnVisible_id_unidad ;
      private bool AV31GridColumnVisible_nombre_unidad ;
      private bool AV32GridColumnVisible_unidades_gisestado ;
      private bool AV33GridColumnVisible_unidades_gisfecha_creacion ;
      private bool AV34GridColumnVisible_unidades_gishora_creacion ;
      private bool AV35GridColumnVisible_unidades_giscreado_por ;
      private bool AV36GridColumnVisible_unidades_gisfecha_modificacion ;
      private bool AV37GridColumnVisible_unidades_gishora_modificacion ;
      private bool AV38GridColumnVisible_unidades_gismodificado_por ;
      private bool n121unidades_gismodificado_por ;
      private bool n120unidades_gishora_modificacion ;
      private bool n118unidades_giscreado_por ;
      private bool n117unidades_gishora_creacion ;
      private bool n115unidades_gisestado ;
      private bool n119unidades_gisfecha_modificacion ;
      private bool n116unidades_gisfecha_creacion ;
      private bool n114nombre_unidad ;
      private string AV13nombre_unidad ;
      private string AV26Filename ;
      private string AV27ErrorMessage ;
      private string lV13nombre_unidad ;
      private string A114nombre_unidad ;
      private string A118unidades_giscreado_por ;
      private string A121unidades_gismodificado_por ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP6_OrderedBy ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P005M2_A121unidades_gismodificado_por ;
      private bool[] P005M2_n121unidades_gismodificado_por ;
      private int[] P005M2_A120unidades_gishora_modificacion ;
      private bool[] P005M2_n120unidades_gishora_modificacion ;
      private string[] P005M2_A118unidades_giscreado_por ;
      private bool[] P005M2_n118unidades_giscreado_por ;
      private int[] P005M2_A117unidades_gishora_creacion ;
      private bool[] P005M2_n117unidades_gishora_creacion ;
      private int[] P005M2_A115unidades_gisestado ;
      private bool[] P005M2_n115unidades_gisestado ;
      private int[] P005M2_A103id_unidad ;
      private DateTime[] P005M2_A119unidades_gisfecha_modificacion ;
      private bool[] P005M2_n119unidades_gisfecha_modificacion ;
      private DateTime[] P005M2_A116unidades_gisfecha_creacion ;
      private bool[] P005M2_n116unidades_gisfecha_creacion ;
      private string[] P005M2_A114nombre_unidad ;
      private bool[] P005M2_n114nombre_unidad ;
      private GxHttpResponse AV28HttpResponse ;
      private ExcelDocumentI AV21ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV10GridColumns ;
      private GxFile AV29File ;
      private SdtK2BGridConfiguration AV8GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumn ;
      private SdtK2BContext AV39Context ;
   }

   public class exportwwunidades_gis__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005M2( IGxContext context ,
                                             string AV13nombre_unidad ,
                                             DateTime AV16unidades_gisfecha_creacion_To ,
                                             DateTime AV15unidades_gisfecha_creacion_From ,
                                             DateTime AV19unidades_gisfecha_modificacion_To ,
                                             DateTime AV18unidades_gisfecha_modificacion_From ,
                                             string AV12K2BToolsGenericSearchField ,
                                             string A114nombre_unidad ,
                                             DateTime A116unidades_gisfecha_creacion ,
                                             DateTime A119unidades_gisfecha_modificacion ,
                                             int A103id_unidad ,
                                             int A115unidades_gisestado ,
                                             int A117unidades_gishora_creacion ,
                                             string A118unidades_giscreado_por ,
                                             int A120unidades_gishora_modificacion ,
                                             string A121unidades_gismodificado_por ,
                                             short AV20OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [modificado_por], [hora_modificacion], [creado_por], [hora_creacion], [estado], [id_unidad], [fecha_modificacion], [fecha_creacion], [nombre_unidad] FROM dbo.[unidades_gis]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13nombre_unidad)) )
         {
            AddWhere(sWhereString, "([nombre_unidad] like @lV13nombre_unidad)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV16unidades_gisfecha_creacion_To) )
         {
            AddWhere(sWhereString, "([fecha_creacion] <= @AV16unidades_gisfecha_creacion_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV15unidades_gisfecha_creacion_From) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV15unidades_gisfecha_creacion_From)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV19unidades_gisfecha_modificacion_To) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] <= @AV19unidades_gisfecha_modificacion_To)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV18unidades_gisfecha_modificacion_From) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV18unidades_gisfecha_modificacion_From)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([id_unidad] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [nombre_unidad] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([estado] AS decimal(9,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_creacion] AS decimal(5,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [creado_por] like '%' + @lV12K2BToolsGenericSearchField + '%' or CONVERT( char(5), CAST([hora_modificacion] AS decimal(5,0))) like '%' + @lV12K2BToolsGenericSearchField + '%' or [modificado_por] like '%' + @lV12K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV20OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [id_unidad]";
         }
         else if ( AV20OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [id_unidad] DESC";
         }
         else if ( AV20OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [nombre_unidad]";
         }
         else if ( AV20OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [nombre_unidad] DESC";
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
                     return conditional_P005M2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP005M2;
          prmP005M2 = new Object[] {
          new ParDef("@lV13nombre_unidad",GXType.NVarChar,200,0) ,
          new ParDef("@AV16unidades_gisfecha_creacion_To",GXType.Date,8,0) ,
          new ParDef("@AV15unidades_gisfecha_creacion_From",GXType.Date,8,0) ,
          new ParDef("@AV19unidades_gisfecha_modificacion_To",GXType.Date,8,0) ,
          new ParDef("@AV18unidades_gisfecha_modificacion_From",GXType.Date,8,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV12K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
